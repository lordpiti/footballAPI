using System;
using System.Collections.Generic;
using System.Text;
using Futbol.Model.Clasificacion.DAO;
using Futbol.Model.Partido.DAO;
using Futbol.Model.EquiposParticipan.DAO;
using Futbol.ActionProcessor;
using System.Collections;
using System.Data.Common;
using Util.Log;


namespace Futbol.Model.FachadaAdmin.Actions
{
    public class CheckClasificacionUpdateAction:NonTransactionalPlainAction
    {
        int cod_Competicion;
        String jornada;
                
        public CheckClasificacionUpdateAction(int cod_Competicion,String jornada)
        {
            this.cod_Competicion = cod_Competicion;
            this.jornada=jornada;
        }

        
        public object execute(DbConnection connection)
        {
            LogManager.RecordMessage("" + cod_Competicion + " " + jornada, LogManager.MessageType.INFO);
            ClasificacionDAO clasificacionDAO = ClasificacionDAOFactory.GetDAO();
            PartidoDAO partidoDAO=PartidoDAOFactory.GetDAO();
            EquiposParticipanDAO equiposParticipanDAO=EquiposParticipanDAOFactory.GetDAO();
            
            ArrayList listaEquiposParticipantes=equiposParticipanDAO.verEquiposParticipan(connection,null,cod_Competicion);
            
            ArrayList listaPartidosJornada = partidoDAO.verPartidosVOCompeticionJornada(connection,
                null, cod_Competicion, Convert.ToString(jornada));
            
            ArrayList listaPartidosCompeticion = partidoDAO.buscarPartidosEquipos(connection, null, 0, 0, cod_Competicion, null, 0);
            
            int numeroPartidosCompeticion=(listaEquiposParticipantes.Count)*(listaEquiposParticipantes.Count-1);

            if (jornada == "Ninguna") return false;


            //Si ya se ha actualizado la clasificacion esa jornada, no se puede volver a actualizar
            if (clasificacionDAO.obtenerUltimaJornada(connection, null, cod_Competicion) == Int32.Parse(jornada))
                return false;



            if (listaPartidosCompeticion == null)
            {
                LogManager.RecordMessage("a1", LogManager.MessageType.INFO);
                return false;
            }
            //Si ya ha acabado la temporada , se acabó
            if (listaPartidosCompeticion.Count == numeroPartidosCompeticion)
            {
                LogManager.RecordMessage("a2", LogManager.MessageType.INFO);
                return false;
            }

            //si no ha empezado la temporada, no se puede actualizar nada
            if (listaPartidosJornada == null)
            {
                LogManager.RecordMessage("a3", LogManager.MessageType.INFO);
                return false;
            }
            
            
            if (listaPartidosJornada.Count!=(listaEquiposParticipantes.Count/2))
                return false;
            else return true;

        }

    }
}