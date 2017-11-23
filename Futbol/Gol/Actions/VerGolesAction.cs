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
    class VerGolesAction : NonTransactionalPlainAction
    {

        public object execute(DbConnection connection)
        {
            
            GolDAO golDAO = new GolDAO();
            
            ArrayList goles = golDAO.listarGoles(connection,null,2,0);
            

            return goles;
        }

    }
}
