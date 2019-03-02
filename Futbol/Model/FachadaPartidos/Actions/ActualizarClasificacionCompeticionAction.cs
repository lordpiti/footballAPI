using System;
using System.Collections.Generic;
using Futbol.ActionProcessor;
using System.Text;
using System.Collections;
using Util.Exceptions;
using System.Data.Common;

using Futbol.Model.Partido.DAO;
using Futbol.Model.Partido.VO;
using Futbol.Model.Clasificacion.DAO;
using Futbol.Model.Clasificacion.VO;
using Futbol.Model.EquiposParticipan.DAO;
using Futbol.Model.EquiposParticipan.VO;
using Futbol.Model.Competicion.DAO;
using Futbol.Model.Competicion.VO;



namespace Futbol.Model.FachadaPartidos.Actions
{
    class ActualizarClasificacionCompeticionAction : TransactionalPlainAction
    {
        int cod_Competicion;
        
        public ActualizarClasificacionCompeticionAction(int cod_Competicion)
        {
            this.cod_Competicion = cod_Competicion;
        }

        public object execute(DbConnection connection,DbTransaction transaction)
        {
            var partidoDAO=new PartidoDAO();
            var clasificacionDAO=new ClasificacionDAO();
            var equiposParticipan= new EquiposParticipanDAO();
            var competicionDAO= new CompeticionDAO();
            var clasificacion=new List<ClasificacionVO>();

            

            int ptosLocal = 0, ptosVisitante = 0, golesFavorLocal = 0, golesContraLocal = 0;
            int golesFavorVisitante = 0, golesContraVisitante = 0;
            int ganadosLocal = 0, perdidosLocal = 0, empatadosLocal = 0;
            int ganadosVisitante = 0, perdidosVisitante = 0, empatadosVisitante = 0;
            int jornada = clasificacionDAO.obtenerUltimaJornada(connection, transaction, cod_Competicion);
            var listaEquiposParticipantes = equiposParticipan.verEquiposParticipan(connection, transaction, cod_Competicion);


            if (clasificacionDAO.listaClasificacionVOsJornadaTemporada(connection,
                transaction, cod_Competicion, jornada) == null)
            {
                
                int contador = 1;
                
                foreach (var equipo in listaEquiposParticipantes)
                {
                    clasificacion.Add(new ClasificacionVO(cod_Competicion, 0, equipo.Cod_Equipo, contador, 0, 0, 0, 0, 0, 0));
                    contador++;
                }
                jornada = 1;
                
            }
            else
            {
                
                clasificacion = clasificacionDAO.listaClasificacionVOsJornadaTemporada(connection, transaction,
                    cod_Competicion, jornada);
                int numeroEquiposParticipantes=listaEquiposParticipantes.Count;

                if (numeroEquiposParticipantes != clasificacion.Count) throw new InstanceNotFoundException(1, "no hay la clasif justa");

                jornada++;
            }

            

            
            var listaPartidosJornada = partidoDAO.verPartidosVOCompeticionJornada(connection,
                transaction, cod_Competicion, Convert.ToString(jornada));
            
            
            if (listaPartidosJornada.Count!=(listaEquiposParticipantes.Count/2))
                throw new InstanceNotFoundException(1, "no hay los partidos justos");


                
                foreach (PartidoVO partido in listaPartidosJornada)
                {
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

                        clasificacion = actualizarClasificacion(new ClasificacionVO(partido.Cod_Competicion, jornada,
                        partido.Cod_Local, 1, ganadosLocal + 1, perdidosLocal, empatadosLocal, golesFavorLocal + partido.Goles_Local,
                        partido.Goles_Visitante + golesContraLocal, ptosLocal + 3), clasificacion);

                        clasificacion = actualizarClasificacion(new ClasificacionVO(partido.Cod_Competicion, jornada,
                        partido.Cod_Visitante, 1, ganadosVisitante, perdidosVisitante + 1, empatadosVisitante, golesFavorVisitante + partido.Goles_Visitante,
                        partido.Goles_Local + golesContraVisitante, ptosVisitante), clasificacion);
                    }
                    else if (partido.Goles_Visitante > partido.Goles_Local)
                    {
                        clasificacion=actualizarClasificacion(new ClasificacionVO(partido.Cod_Competicion, jornada,
                        partido.Cod_Local, 1, ganadosLocal, perdidosLocal + 1, empatadosLocal, golesFavorLocal + partido.Goles_Local,
                        partido.Goles_Visitante + golesContraLocal, ptosLocal), clasificacion);

                        clasificacion=actualizarClasificacion(new ClasificacionVO(partido.Cod_Competicion, jornada,
                        partido.Cod_Visitante, 1, ganadosVisitante + 1, perdidosVisitante, empatadosVisitante, golesFavorVisitante + partido.Goles_Visitante,
                        partido.Goles_Local + golesContraVisitante, ptosVisitante + 3), clasificacion);
                    }
                    else
                    {
                        clasificacion=actualizarClasificacion(new ClasificacionVO(partido.Cod_Competicion, jornada,
                        partido.Cod_Local, 1, ganadosLocal, perdidosLocal, empatadosLocal + 1, golesFavorLocal + partido.Goles_Local,
                        partido.Goles_Visitante + golesContraLocal, ptosLocal + 1), clasificacion);

                        clasificacion=actualizarClasificacion(new ClasificacionVO(partido.Cod_Competicion, jornada,
                        partido.Cod_Visitante, 1, ganadosVisitante, perdidosVisitante, empatadosVisitante + 1, golesFavorVisitante + partido.Goles_Visitante,
                        partido.Goles_Local + golesContraVisitante, ptosVisitante + 1), clasificacion);
                    }

                }

                
                int posicion = 1;
                foreach (ClasificacionVO item in clasificacion)
                {
                    item.Posicion = posicion;
                    
                    clasificacionDAO.create(connection, transaction, item);
                    posicion++;
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
                aux = clasificacion[i];
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



    }
}
