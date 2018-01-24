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

                //Create 10 different parallel threads to do stuff
                //for(int i = 0; i < 10; i++)
                //{
                //    new Thread(async () =>
                //    {



                //        await bubu.Clients.All.InvokeAsync("Send", "Hello folks");

                //    }).Start();
                //}


                ArrayList listaCodigosEquipos = new ArrayList();
                ArrayList clasificacion = new ArrayList();

                for (int i = 1; i <= 20; i++)
                {
                    listaCodigosEquipos.Add(i);
                }

                ArrayList calendario = generadorCosas.generaLiga(listaCodigosEquipos);
                ArrayList calendarioLiga = generador.generaListaCalendarioVOsLiga(calendario);

                var comp1 = new CompeticionTotalCO(new CompeticionVO("LFP 1ªDivision 14-15", "2014-2015", generadorCosas.generarFechaAleatoriaPartido(),
                    generadorCosas.generarFechaAleatoriaPartido(), "ninguno", "~/images/titulos/eurocopa.jpg", "Liga"),
                    calendarioLiga, listaCodigosEquipos);

                int numeroJornada = 1;
                int matchId = 1;

                var matchSet = (ArrayList)calendario[0];

                foreach (Jornada part in matchSet)
                {
                    var temp = matchId;
                    new Thread(async () =>
                    {
                        var match = generador.generarPartidoCompleto(comp1.Competicion.Cd_Competicion, Convert.ToString(numeroJornada), (int)part.Local, (int)part.Visitante, false);
                        await bubu.Clients.All.InvokeAsync("Send", new { matchToCreate = match, matchId = temp });

                        var events = GenerateEventListForGame(match, temp);

                        var currentMinute = 0;

                        foreach(var item in events)
                        {
                            int timeToWait = (item.Minute - currentMinute) * 5000;
                            Thread.Sleep(timeToWait);
                            await bubu.Clients.All.InvokeAsync("Send", item);
                            currentMinute = item.Minute;
                        }
                        
                        await bubu.Clients.All.InvokeAsync("Send", "The game is over");
                    }).Start();
                    matchId++;
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

            return events.OrderBy(x=>x.Minute).ToList();
        }
    }
}
