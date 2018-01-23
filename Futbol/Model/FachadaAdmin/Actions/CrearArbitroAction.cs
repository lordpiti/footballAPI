using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Arbitro.VO;
using Futbol.Model.Arbitro.DAO;
using System.Collections;



namespace Futbol.Model.FachadaAdmin.Actions
{
    class CrearArbitroAction : NonTransactionalPlainAction
    {

        private ArbitroVO arbitroVO;

        public CrearArbitroAction(ArbitroVO arbitroVO)
        {
            this.arbitroVO = arbitroVO;
        }

        public object execute(DbConnection connection)
        {

            ArbitroDAO arbitroDAO = ArbitroDAOFactory.GetDAO();
            ArbitroVO arbitroVOcreado = arbitroDAO.create(connection, null, arbitroVO);

            return arbitroVOcreado;
        }
    }
}