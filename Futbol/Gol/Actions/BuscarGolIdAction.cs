using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Gol.DAO;
using Futbol.Model.Gol.VO;
using System.Collections;
using Es.UDC.DotNet.Util.Log;




namespace Futbol.Model.Gol.Actions
{
    class BuscarGolIdAction : NonTransactionalPlainAction
    {
        int cod_Gol;

        public BuscarGolIdAction(int cod_Gol)
        {
            this.cod_Gol = cod_Gol;
        }


        public object execute(DbConnection connection)
        {

            GolDAO golDAO = new GolDAO();

            GolVO gol = golDAO.buscarGolId(connection, null, 1);


            return gol;
        }

    }
}

