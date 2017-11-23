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
    class CrearGolAction : NonTransactionalPlainAction
    {

        private GolVO golVO;

        public CrearGolAction(GolVO golVO)
        {
            this.golVO = golVO;
        }

        public object execute(DbConnection connection)
        {

            GolDAO golDAO = new GolDAO();

            GolVO golVO = golDAO.create(connection, null, this.golVO);
            

            return golVO;
        }

    }
}