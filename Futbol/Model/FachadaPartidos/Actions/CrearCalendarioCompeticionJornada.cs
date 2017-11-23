using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Calendario.DAO;
using Futbol.Model.Calendario.VO;
using System.Collections;
using Util.Log;


namespace Futbol.Model.FachadaPartidos.Actions
{
    class CrearCalendarioCompeticionJornadaAction : TransactionalPlainAction
    {

        private ArrayList calendario;

        public CrearCalendarioCompeticionJornadaAction(ArrayList calendario)
        {
            this.calendario = calendario;
        }

        public object execute(DbConnection connection, DbTransaction transaction)
        {
            CalendarioDAO calendarioDAO = CalendarioDAOFactory.GetDAO();
            
            foreach (CalendarioVO item in calendario)
            {
                
                calendarioDAO.create(connection, transaction, item);
                
            }



            return null;
        }
    }
}