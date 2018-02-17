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
using Football.Services.Interface;

namespace Football.API.TaskRunner.Jobs
{
    public class CreateMatchesJob : BaseJob
    {
        private readonly IOptions<AppSettings> _settings;
        private IPlayerService _playerService;
        private ITeamService _teamService;

        public CreateMatchesJob(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        public override async Task<bool> Run()
        {
            try
            {
                var bubu = Startup.Provider.GetService<IHubContext<LoopyHub>>();

                var generadorCosas = new GeneradorCosas();
                var generador = new GeneradorPartidos();

                var listaCodigosEquipos = new List<int>();

                for (int i = 1; i <= 20; i++)
                {
                    listaCodigosEquipos.Add(i);
                }

                var calendario = generadorCosas.generaLiga(listaCodigosEquipos);
                var calendarioLiga = generador.generaListaCalendarioVOsLiga(calendario);

                var comp1 = new CompeticionTotalCO(new CompeticionVO("LFP 1ªDivision 14-15", "2014-2015", generadorCosas.generarFechaAleatoriaPartido(),
                    generadorCosas.generarFechaAleatoriaPartido(), "ninguno", "~/images/titulos/eurocopa.jpg", "Liga"),
                    calendarioLiga, listaCodigosEquipos);

                int numeroJornada = 1;

                var matchSet = calendario[0];

                await bubu.Clients.All.InvokeAsync("StartSimulation",
                new
                {
                    eventType = "startSimulation"
                });

                var taskList = new List<Task>();

                for (int i=1;i<10;i++)
                {
                    var cont = i;
                    var part = matchSet[cont];
                    
                    var task = new Task(async () =>
                    {
                        //_teamService = serviceProvider.GetService<ITeamService>();
                        var match = generador.generarPartidoCompleto(comp1.Competicion.Cd_Competicion, Convert.ToString(numeroJornada), (int)part.Local, (int)part.Visitante, false);

                        var events = await GenerateEventListForGame(match, cont);

                        var serviceProvider = ServiceConfiguration.ConsoleProvider;
                        _teamService = serviceProvider.GetService<ITeamService>();
                        var localTeam = await _teamService.GetTeamByIdAndYear(match.Partido.Cod_Local, 2009);
                        var visitorTeam = await _teamService.GetTeamByIdAndYear(match.Partido.Cod_Visitante, 2009);

                        await bubu.Clients.All.InvokeAsync("SendCreateMatch", 
                            new { matchToCreate = match,
                                matchId = cont,
                                localTeam = localTeam,
                                visitorTeam = visitorTeam,
                                events = events.Count
                            });

                        var currentMinute = 0;

                        foreach(var item in events)
                        {
                            int timeToWait = (item.Minute - currentMinute) * 500;
                            Thread.Sleep(timeToWait);
                            await bubu.Clients.All.InvokeAsync("Send", item);
                            currentMinute = item.Minute;
                        }
                    });
                    taskList.Add(task);
                    task.Start();
                }

                Task.WaitAll(taskList.ToArray());
             

            }
            catch (Exception ex)
            {
                // We need to log this somewhere.
            }

            return true;
        }

        private async Task<List<MatchEventRT>> GenerateEventListForGame(PartidoTotalCO partido, int matchId)
        {
            //call server to get player list
            //var _playerService = Startup.Provider.GetService<IPlayerService>();
            var serviceProvider = ServiceConfiguration.ConsoleProvider;
            _playerService = serviceProvider.GetService<IPlayerService>();

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
