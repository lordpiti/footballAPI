using AspNetCoreSignalr.SignalRHubs;
using Crosscutting.ViewModels;
using Football.API.Config;
using footballRebuildAPI;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using Simulador;
using System.Collections;
using Futbol.Model.FachadaPartidos;
using Futbol.Model.Competicion.VO;
using System.Linq;
using Football.Crosscutting.ViewModels.Match;
using System.Collections.Generic;

namespace Football.API.TaskRunner.Jobs
{
    public class CreateMatchesJob : BaseJob
    {
        private readonly IOptions<AppSettings> _settings;

        public CreateMatchesJob(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        public override async Task<bool> Run()
        {
            //_logger.LogInformation("AmazonCleanupBadger Run()");

            try
            {
                //TODO: create matches
                var serviceProvider = ServiceConfiguration.ConsoleProvider;

                var chatHub = serviceProvider.GetService<IHubContext<LoopyHub>>();
                var bubu = Startup.Provider.GetService<IHubContext<LoopyHub>>();

                var generadorCosas = new GeneradorCosas();
                var generador = new GeneradorPartidos();

                var listaCodigosEquipos = new ArrayList();
                var clasificacion = new ArrayList();

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

                var matchSet = (ArrayList)calendario[0];

                for (int i=1;i<10;i++)
                {
                    var cont = i;
                    var part = (Jornada)matchSet[cont];
                    
                    new Thread(async () =>
                    {
                        var match = generador.generarPartidoCompleto(comp1.Competicion.Cd_Competicion, Convert.ToString(numeroJornada), (int)part.Local, (int)part.Visitante, false);

                        var events = GenerateEventListForGame(match, cont);
                        await bubu.Clients.All.InvokeAsync("SendCreateMatch", 
                            new { matchToCreate = match,
                                matchId = cont,
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
                    }).Start();
                }



            }
            catch (Exception ex)
            {
                // We need to log this somewhere.
            }

            return true;
        }

        private List<MatchEventRT> GenerateEventListForGame(PartidoTotalCO partido, int matchId)
        {
            var events = new List<MatchEventRT>();

            var cards = partido.Tarjetas.Select(x => new MatchEventRT()
            {
                Description = "",
                MatchEventType = Crosscutting.Enums.MatchEventTypeEnum.RedCard,
                Minute = x.Minuto,
                MatchId = matchId
            });

            var substitutions = partido.Cambios.Select(x => new MatchEventRT()
            {
                Description = "",
                MatchEventType = Crosscutting.Enums.MatchEventTypeEnum.Substitution,
                Minute = x.Minuto,
                MatchId = matchId
            });

            var goals = partido.Cambios.Select(x => new MatchEventRT()
            {
                Description = "",
                MatchEventType = Crosscutting.Enums.MatchEventTypeEnum.Goal,
                Minute = x.Minuto,
                MatchId = matchId
            });

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
