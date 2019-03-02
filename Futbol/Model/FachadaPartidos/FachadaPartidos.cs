using Futbol.ActionProcessor;
using Futbol.Model.Clasificacion.VO;
using Futbol.Model.Competicion.VO;
using Futbol.Model.FachadaPartidos.Actions;
using Futbol.Model.FachadaPartidos.COs;
using Futbol.Model.Gol.VO;
using Futbol.Model.Partido;
using Futbol.Model.Partido.VO;
using Futbol.Model.PartidoJugado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Util.Exceptions;
using Westwind.Utilities;

namespace Futbol.Model.FachadaPartidos
{
    public class FachadaPartidos
    {
        private static String providerName = "system.data.sqlclient";
     /*   private static String connectionString = "Data Source=localhost\\SQLExpress;" +
            "Initial Catalog=criticas;" +
            "User ID=user;Password=password";*/
        private DbProviderFactory dbFactory;


        public FachadaPartidos()
        {
            dbFactory = DataUtils.GetDbProviderFactory(providerName);
        }

        //Crea un partido con todos sus detalles
        public PartidoTotalCO pruebaCrearPartidoTotal(PartidoTotalCO partidoTotalCO)
         {
             try
             {
                 CrearPartidoTotalAction action = new CrearPartidoTotalAction(partidoTotalCO);   

                 return (PartidoTotalCO)PlainActionProcessor.process(dbFactory, action);                 
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

         //obtiene todos los partidos jugados por un jugador en una temporada
         public ArrayList pruebaVerPartidosJugadorTemporada(int cod_Jugador, String temporada, int cod_Competicion)
         {
             try
             {
                 VerPartidosJugadosTemporadaAction action =
                     new VerPartidosJugadosTemporadaAction(cod_Jugador, temporada,cod_Competicion);

                 return (ArrayList)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }


         public CompeticionVO buscarCompeticionId(int cod_Competicion)
         {
             try
             {
                 BuscarCompeticionIdAction action =
                     new BuscarCompeticionIdAction(cod_Competicion);

                 return (CompeticionVO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }



         public void crearClasificacionJornada(List<ClasificacionVO> clasificacion)
         {
             try
             {
                 CrearClasificacionJornadaAction action = new CrearClasificacionJornadaAction(clasificacion);
                 PlainActionProcessor.process(dbFactory, action);

                
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }


         }



         public List<ClasificacionVO> actualizarClasificacionTrasPartido(int numeroJornada, PartidoVO partido, List<ClasificacionVO> clasificacion)
         {
             int ptosLocal = 0, ptosVisitante = 0, golesFavorLocal = 0, golesContraLocal = 0;
             int golesFavorVisitante = 0, golesContraVisitante = 0;
             int ganadosLocal = 0, perdidosLocal = 0, empatadosLocal = 0;
             int ganadosVisitante = 0, perdidosVisitante = 0, empatadosVisitante = 0;

             //busca los puntos actuales de los equipos local y visitante
             foreach (ClasificacionVO item in clasificacion)
             {
                 if (item.Cod_Equipo == partido.Cod_Local)
                 {
                     ptosLocal = item.Puntos;
                     ganadosLocal = item.Ganados;
                     perdidosLocal = item.Perdidos;
                     empatadosLocal = item.Empatados;
                     golesFavorLocal = item.Goles_Favor;
                     golesContraLocal = item.Goles_Contra;

                 }
                 if (item.Cod_Equipo == partido.Cod_Visitante)
                 {
                     ptosVisitante = item.Puntos;
                     ganadosVisitante = item.Ganados;
                     perdidosVisitante = item.Perdidos;
                     empatadosVisitante = item.Empatados;
                     golesFavorVisitante = item.Goles_Favor;
                     golesContraVisitante = item.Goles_Contra;
                 }
             }


             if (partido.Goles_Local > partido.Goles_Visitante)
             {

                 clasificacion = actualizarClasificacion(new ClasificacionVO(partido.Cod_Competicion, numeroJornada,
                 partido.Cod_Local, 1, ganadosLocal + 1, perdidosLocal, empatadosLocal, golesFavorLocal + partido.Goles_Local,
                 partido.Goles_Visitante + golesContraLocal, ptosLocal + 3), clasificacion);

                 clasificacion = actualizarClasificacion(new ClasificacionVO(partido.Cod_Competicion, numeroJornada,
                 partido.Cod_Visitante, 1, ganadosVisitante, perdidosVisitante + 1, empatadosVisitante, golesFavorVisitante + partido.Goles_Visitante,
                 partido.Goles_Local + golesContraVisitante, ptosVisitante), clasificacion);
             }
             else if (partido.Goles_Visitante > partido.Goles_Local)
             {
                 actualizarClasificacion(new ClasificacionVO(partido.Cod_Competicion, numeroJornada,
                 partido.Cod_Local, 1, ganadosLocal, perdidosLocal + 1, empatadosLocal, golesFavorLocal + partido.Goles_Local,
                 partido.Goles_Visitante + golesContraLocal, ptosLocal), clasificacion);

                 actualizarClasificacion(new ClasificacionVO(partido.Cod_Competicion, numeroJornada,
                 partido.Cod_Visitante, 1, ganadosVisitante + 1, perdidosVisitante, empatadosVisitante, golesFavorVisitante + partido.Goles_Visitante,
                 partido.Goles_Local + golesContraVisitante, ptosVisitante + 3), clasificacion);
             }
             else
             {
                 actualizarClasificacion(new ClasificacionVO(partido.Cod_Competicion, numeroJornada,
                 partido.Cod_Local, 1, ganadosLocal, perdidosLocal, empatadosLocal + 1, golesFavorLocal + partido.Goles_Local,
                 partido.Goles_Visitante + golesContraLocal, ptosLocal + 1), clasificacion);

                 actualizarClasificacion(new ClasificacionVO(partido.Cod_Competicion, numeroJornada,
                 partido.Cod_Visitante, 1, ganadosVisitante, perdidosVisitante, empatadosVisitante + 1, golesFavorVisitante + partido.Goles_Visitante,
                 partido.Goles_Local + golesContraVisitante, ptosVisitante + 1), clasificacion);
             }

             return clasificacion;
         }


         private List<ClasificacionVO> actualizarClasificacion(ClasificacionVO e, List<ClasificacionVO> clasificacion)
         {
             
             int i = 0;
             bool insertado = false;
             int target = 0;
             ClasificacionVO aux = null;
             while (i < clasificacion.Count)
             {
                 aux = (ClasificacionVO)clasificacion[i];
                 if (e.Cod_Equipo == aux.Cod_Equipo)
                 {
                     target = i;
                     break;
                 }
                 i++;
             }
             
             clasificacion.RemoveAt(target);
             i = 0;
             while (i < clasificacion.Count)
             {
                 aux = clasificacion[i];
                 if ((aux.Puntos < e.Puntos) || ((aux.Puntos == e.Puntos) && (e.goal_Average() >= aux.goal_Average())))
                 {
                     clasificacion.Insert(i, e);
                     insertado = true;
                     break;
                 }
                 i++;
             }
             if (!insertado) clasificacion.Add(e);

             return clasificacion;
         }


         public void crearCompeticionCompleta(CompeticionVO competicionVO, ArrayList listaEquipos,ArrayList calendario)
         {
             try
             {
                 CrearCompeticionAction action = new CrearCompeticionAction(competicionVO,listaEquipos,calendario);
                 PlainActionProcessor.process(dbFactory, action);


             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }

         }


         public PartidoCompletoCO verPartidoCompleto(int cod_Partido)
         {
             try
             {
                 VerPartidoCompletoAction action =
                     new VerPartidoCompletoAction(cod_Partido);

                 return (PartidoCompletoCO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }


         public void crearCalendarioCompeticionJornada(ArrayList calendario)
         {
             try
             {
                 CrearCalendarioCompeticionJornadaAction action = 
                     new CrearCalendarioCompeticionJornadaAction(calendario);
                 PlainActionProcessor.process(dbFactory, action);


             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }


         }


         public EstadoCompeticionCO verEstadoCompeticion(int cod_Competicion, String jornada)
         {
             try
             {
                 VerEstadoCompeticionAction action =
                     new VerEstadoCompeticionAction(cod_Competicion, jornada);
                 return ((EstadoCompeticionCO)PlainActionProcessor.process(dbFactory, action));


             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }

         }


         public EstadisticasAgrupadasCO verEstadisticasAgrupadasJugador(int cod_Jugador,
             String temporada,int cod_Competicion,String tipo)
         {
             try
             {
                 VerEstadisticasJugadorAgrupadasAction action =
                     new VerEstadisticasJugadorAgrupadasAction(cod_Jugador, temporada,
                     cod_Competicion, tipo);
                 return ((EstadisticasAgrupadasCO)PlainActionProcessor.process(dbFactory, action));


             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }

         }

         public CompeticionTotalCO crearCompeticionTotal(CompeticionTotalCO competicionTotal)
         {
                    
             try
             {
                 CrearCompeticionTotalAction action = new CrearCompeticionTotalAction(competicionTotal);
                 return ((CompeticionTotalCO) PlainActionProcessor.process(dbFactory, action));

             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }

         }

         public List<ClasificacionVO> actualizarClasificacionCompeticion(int cod_Competicion)
         {
             try
             {
                 ActualizarClasificacionCompeticionAction action = new ActualizarClasificacionCompeticionAction(cod_Competicion);
                 return ((List<ClasificacionVO>)PlainActionProcessor.process(dbFactory, action));

             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }


         }

         public CompeticionVO verCompeticion(int cod_Competicion)
         {
             try
             {
                 VerCompeticionAction action = new VerCompeticionAction(cod_Competicion);
                 return ((CompeticionVO)PlainActionProcessor.process(dbFactory, action));

             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }



         }

         public List<CompeticionConNombreCO> buscarCompeticionesTemporada(String temporada)
         {
             try
             {
                 BuscarCompeticionesTemporadaAction action = new BuscarCompeticionesTemporadaAction(temporada);
                 return ((List<CompeticionConNombreCO>)PlainActionProcessor.process(dbFactory, action));

             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

         public List<string> buscarTemporadas()
         {
             try
             {
                 BuscarTemporadasAction action = new BuscarTemporadasAction();
                 return ((List<string>)PlainActionProcessor.process(dbFactory, action));

             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }

         public List<TemporadaCO> buscarJornadas(int cod_Competicion)
         {
             try
             {
                 VerJornadasCompeticionAction action = new VerJornadasCompeticionAction(cod_Competicion);
                 return ((List<TemporadaCO>)PlainActionProcessor.process(dbFactory, action));

             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }


         public EstadisticasAgrupadasCO verEstadisticasJugadorPartido(int cod_Jugador,
            int cod_Partido)
         {
             try
             {
                 VerEstadisticasJugadorPartidoAction action =
                     new VerEstadisticasJugadorPartidoAction(cod_Jugador, cod_Partido);
                 return ((EstadisticasAgrupadasCO)PlainActionProcessor.process(dbFactory, action));


             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }

         }


         public List<PartidoCompeticionJornadaCO> buscarPartidosEquipos (int codLocal,int codVisitante, int cod_Competicion,
             String jornada,int flag)
         {
             try
             {

                 VerResultadosBusquedaAction action =
                     new VerResultadosBusquedaAction(codLocal, codVisitante, cod_Competicion, jornada,flag);
                 return ((List<PartidoCompeticionJornadaCO>)PlainActionProcessor.process(dbFactory, action));


             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }

         }



         public GolVO buscarGol(int cod_Gol)
         {
             try
             {
                 VerGolAction action =
                     new VerGolAction(cod_Gol);

                 return (GolVO)PlainActionProcessor.process(dbFactory, action);
             }
             catch (InternalErrorException e) { throw e; }
             catch (Exception e) { throw new InternalErrorException(e); }
         }


     }
}