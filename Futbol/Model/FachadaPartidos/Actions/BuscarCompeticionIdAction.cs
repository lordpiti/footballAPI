using System;
using System.Collections.Generic;
using System.Text;
using Futbol.Model.Competicion.DAO;
using System.Data.Common;
using Futbol.ActionProcessor;


namespace Futbol.Model.FachadaPartidos.Actions
{
    public class BuscarCompeticionIdAction : NonTransactionalPlainAction
    {
        private int cod_Competicion;


        public BuscarCompeticionIdAction(int cod_Competicion)
        {
            this.cod_Competicion = cod_Competicion;
        }

        public object execute(DbConnection connection)
        {

            CompeticionDAO competicionDAO = CompeticionDAOFactory.GetDAO();

            return (competicionDAO.buscarCompeticionId(connection, null, cod_Competicion));

        }
    }
}