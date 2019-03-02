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
    class CrearCompeticionTotalAction : TransactionalPlainAction
    {

        private CompeticionTotalCO competicionTotal;

        public CrearCompeticionTotalAction(CompeticionTotalCO competicionTotal)
        {
            this.competicionTotal = competicionTotal;
        }

        public object execute(DbConnection connection, DbTransaction transaction)
        {

            CompeticionDAO competicionDAO = new CompeticionDAO();
            CalendarioDAO calendarioDAO = new CalendarioDAO();
            EquiposParticipanDAO equiposParticipanDAO = new EquiposParticipanDAO();



            CompeticionVO competicionVO = competicionDAO.create(connection, transaction, competicionTotal.Competicion);
            

            foreach (int item in competicionTotal.ListaEquipos)
            {
                equiposParticipanDAO.create(connection, transaction, new EquiposParticipanVO(competicionVO.Cd_Competicion, item));
            }

            if (competicionTotal.Calendario != null)
            {
                foreach (CalendarioVO item in competicionTotal.Calendario)
                {
                    item.Cod_Competicion = competicionVO.Cd_Competicion;
                    calendarioDAO.create(connection, transaction, item);
                }

            }

            
            return new CompeticionTotalCO(competicionVO, competicionTotal.Calendario,
                competicionTotal.ListaEquipos);
        }
    }
}
