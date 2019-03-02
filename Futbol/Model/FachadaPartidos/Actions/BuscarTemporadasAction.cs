using System;
using System.Collections.Generic;
using System.Text;
using Futbol.Model.Competicion.DAO;
using System.Data.Common;
using Futbol.ActionProcessor;


namespace Futbol.Model.FachadaPartidos.Actions
{
    public class BuscarTemporadasAction : NonTransactionalPlainAction
    {


        public BuscarTemporadasAction()
        {
        }

        public object execute(DbConnection connection)
        {

            CompeticionDAO competicionDAO = new CompeticionDAO();

            return (competicionDAO.buscarTemporadas(connection,null));

        }
    }
}