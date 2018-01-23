using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Competicion.DAO;
using Futbol.Model.Competicion.VO;
using Futbol.Model.EquiposParticipan.DAO;
using Futbol.Model.EquiposParticipan.VO;
using Futbol.Model.Clasificacion.DAO;
using Futbol.Model.Clasificacion.VO;
using Futbol.Model.Calendario.DAO;
using Futbol.Model.Calendario.VO;
using System.Collections;



namespace Futbol.Model.FachadaPartidos.Actions
{
    class CrearCompeticionAction : TransactionalPlainAction
    {

        private CompeticionVO competicionVO;
        private ArrayList listaEquipos;
        private ArrayList calendario;

        public CrearCompeticionAction(CompeticionVO competicionVO,ArrayList listaEquipos,
            ArrayList calendario)
        {
            this.competicionVO = competicionVO;
            this.listaEquipos = listaEquipos;
            this.calendario = calendario;
        }

        public object execute(DbConnection connection,DbTransaction transaction)
        {

            CompeticionDAO competicionDAO = CompeticionDAOFactory.GetDAO();
            CalendarioDAO calendarioDAO = CalendarioDAOFactory.GetDAO();
            
            EquiposParticipanDAO equiposParticipanDAO = EquiposParticipanDAOFactory.GetDAO();
            
            

            competicionVO=competicionDAO.create(connection, transaction, competicionVO);

            foreach (int item in listaEquipos)
            {
                equiposParticipanDAO.create(connection, transaction, new EquiposParticipanVO(competicionVO.Cd_Competicion, item));
            }

            if (calendario != null)
            {
                foreach (CalendarioVO item in calendario)
                {
                    item.Cod_Competicion = competicionVO.Cd_Competicion;
                    calendarioDAO.create(connection, transaction, item);
                }

            }


            return null;
        }
    }
}