using System;
using System.Collections.Generic;
using System.Text;
using Futbol.Model.Competicion.DAO;
using Futbol.ActionProcessor;
using System.Data.Common;


namespace Futbol.Model.FachadaPartidos.Actions
{
    public class VerCompeticionAction:NonTransactionalPlainAction
    {
        private int cod_Competicion;
        

        public VerCompeticionAction(int cod_Competicion)
        {
            this.cod_Competicion = cod_Competicion;
        }

        public object execute(DbConnection connection)
        {

            var competicionDAO = new CompeticionDAO();
       
            return (competicionDAO.buscarCompeticionId(connection,null,cod_Competicion));

        }
    }
}
