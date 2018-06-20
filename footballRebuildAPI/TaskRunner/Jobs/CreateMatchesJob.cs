using AspNetCoreSignalr.SignalRHubs;
using Crosscutting.ViewModels;
using Football.API.Config;
using footballRebuildAPI;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Threading;
using Simulador;
using Futbol.Model.FachadaPartidos;
using Futbol.Model.Competicion.VO;
using System.Linq;
using Football.Crosscutting.ViewModels.Match;
using System.Collections.Generic;
using Services.Interface;
using Football.Crosscutting.ViewModels;

namespace Football.API.TaskRunner.Jobs
{
    public class CreateMatchesJob : BaseJob
    {
        private readonly IOptions<AppSettings> _settings;
        private IPlayerService _playerService;
        private IHubContext<LoopyHub> _footballHub;
        private IGeneradorCosas _generadorCosas;
        private IGeneradorPartidos _generadorPartidos;

        public CreateMatchesJob(IOptions<AppSettings> settings, IPlayerService playerService, 
            IGeneradorCosas generadorCosas, IGeneradorPartidos generadorPartidos)
        {
            _settings = settings;
            _footballHub = Startup.Provider.GetService<IHubContext<LoopyHub>>();
            _generadorCosas = generadorCosas;
            _generadorPartidos = generadorPartidos;
            _playerService = playerService;
        }

        public override async Task<bool> Run()
        {
            try
            {
                const int numberOfTeams = 20;
                var teamCodeList = Enumerable.Range(1, numberOfTeams).ToList();

                var calendario = _generadorCosas.generaLiga(teamCodeList);
                var calendarioLiga = _generadorPartidos.generaListaCalendarioVOsLiga(calendario);

                var comp1 = new CompeticionTotalCO(new CompeticionVO("LFP 1ªDivision 14-15", "2014-2015", _generadorCosas.generarFechaAleatoriaPartido(),
                    _generadorCosas.generarFechaAleatoriaPartido(), "ninguno", "~/images/titulos/eurocopa.jpg", "Liga"),
                    calendarioLiga, teamCodeList);

                int numeroJornada = 1;

                var matchSet = calendario[0];

                await _footballHub.Clients.All.SendAsync("StartSimulation",
                new
                {
                    eventType = "startSimulation"
                });

                var taskList = new List<Task>();

                for (int i=1;i< numberOfTeams/2; i++)
                {
                    var cont = i;
                    var part = matchSet[cont];

                    var task = createMatchTask(comp1, part, numeroJornada, cont);
                    taskList.Add(task);
                    //task.Start();
                }

                Task.WaitAll(taskList.ToArray());
            }
            catch (Exception ex)
            {
                // We need to log this somewhere.
            }

            return true;
        }

        private async Task createMatchTask(CompeticionTotalCO competition, Jornada part, int numeroJornada, int cont)
        {
            var match = _generadorPartidos.generarPartidoCompleto(competition.Competicion.Cd_Competicion, Convert.ToString(numeroJornada), (int)part.Local, (int)part.Visitante, false);

            var events = await GenerateEventListForGame(match, cont);

            await _footballHub.Clients.All.SendAsync("SendCreateMatch",
                new
                {
                    matchToCreate = match,
                    matchId = cont,
                    events = events.Count
                });

            var currentMinute = 0;

            foreach (var item in events)
            {
                int timeToWait = (item.Minute - currentMinute) * 500;
                Thread.Sleep(timeToWait);
                await _footballHub.Clients.All.SendAsync("Send", item);
                currentMinute = item.Minute;
            }
        }

        private async Task<List<MatchEventRT>> GenerateEventListForGame(PartidoTotalCO partido, int matchId)
        {
            var serviceProvider = ServiceConfiguration.ConsoleProvider;

            var events = new List<MatchEventRT>();

            var playerIds = partido.PartidosJugados.Select(x => x.Cod_Jugador).ToList();
            var players = await _playerService.GetPlayersFromList(playerIds);

            var cards = partido.Tarjetas.Select(x => new MatchEventRT()
            {
                Description = x.Tipo + " card",
                MatchEventType = Crosscutting.Enums.MatchEventTypeEnum.RedCard,
                Minute = x.Minuto,
                MatchId = matchId,
                Player1 = players.FirstOrDefault(y => y.PlayerId == x.Cd_Jugador)
            }).ToList();

            var substitutions = partido.Cambios.Select(x => new MatchEventRT()
            {
                Description = "Substitution",
                MatchEventType = Crosscutting.Enums.MatchEventTypeEnum.Substitution,
                Minute = x.Minuto,
                MatchId = matchId,
                Player1 = players.FirstOrDefault(y => y.PlayerId == x.Cd_Jugador_Sale),
                Player2 = players.FirstOrDefault(y => y.PlayerId == x.Cd_Jugador_Entra)
            }).ToList();

            var goals = partido.Goles.Select(x => new MatchEventRT()
            {
                Description = "Goal",
                MatchEventType = Crosscutting.Enums.MatchEventTypeEnum.Goal,
                Minute = x.Minuto,
                MatchId = matchId,
                Team1 = new Team()
                {
                    Name = players.FirstOrDefault(y => y.PlayerId == x.Cd_Jugador).TeamName,
                    Id = players.FirstOrDefault(y => y.PlayerId == x.Cd_Jugador).TeamId
                },
                Player1 = players.FirstOrDefault(y => y.PlayerId == x.Cd_Jugador)
            }).ToList();

            events.AddRange(cards);
            events.AddRange(substitutions);
            events.AddRange(goals);
            events.Add(new MatchEventRT()
            {
                Description = "",
                MatchEventType = Crosscutting.Enums.MatchEventTypeEnum.GameFinished,
                MatchId = matchId,
                Minute = 90
            });

            return events.OrderBy(x=>x.Minute).ToList();
        }
    }
}
