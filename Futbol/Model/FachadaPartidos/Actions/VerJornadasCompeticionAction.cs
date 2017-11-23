using System;
using System.Collections.Generic;
using System.Text;
using Futbol.Model.Partido.DAO;
using System.Data.Common;
using Futbol.ActionProcessor;


namespace Futbol.Model.FachadaPartidos.Actions
{
    public class VerJornadasCompeticionAction : NonTransactionalPlainAction
    {
        private int cod_Competicion;

        public VerJornadasCompeticionAction(int cod_Competicion)
        {
            this.cod_Competicion = cod_Competicion;
        }

        public object execute(DbConnection connection)
        {

            PartidoDAO partidoDAO = PartidoDAOFactory.GetDAO();

            return (partidoDAO.verJornadasCompeticion(connection, null, cod_Competicion));

        }
    }
}
