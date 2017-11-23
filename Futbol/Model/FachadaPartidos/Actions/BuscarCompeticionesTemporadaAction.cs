using System;
using System.Collections.Generic;
using System.Text;
using Futbol.Model.Competicion.DAO;
using System.Data.Common;
using Futbol.ActionProcessor;


namespace Futbol.Model.FachadaPartidos.Actions
{
    public class BuscarCompeticionesTemporadaAction:NonTransactionalPlainAction
    {
        private String temporada;
        

        public BuscarCompeticionesTemporadaAction(String temporada)
        {
            this.temporada = temporada;
        }

        public object execute(DbConnection connection)
        {

            CompeticionDAO competicionDAO = CompeticionDAOFactory.GetDAO();
       
            return (competicionDAO.buscarCompeticionesTemporada(connection,null,temporada));

        }
    }
}
