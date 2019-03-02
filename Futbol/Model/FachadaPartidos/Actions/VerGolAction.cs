using System;
using System.Collections.Generic;
using System.Text;
using Futbol.Model.Gol.DAO;
using Futbol.ActionProcessor;
using System.Data.Common;


namespace Futbol.Model.FachadaPartidos.Actions
{
    public class VerGolAction : NonTransactionalPlainAction
    {
        private int cod_Gol;


        public VerGolAction(int cod_Gol)
        {
            this.cod_Gol = cod_Gol;
        }

        public object execute(DbConnection connection)
        {

            GolDAO golDAO = new GolDAO();

            return (golDAO.buscarGolId(connection, null, cod_Gol));

        }
    }
}
