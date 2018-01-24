using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Arbitro;
using Futbol.Model.Arbitro.VO;
using Futbol.Model.Arbitro.DAO;
using Futbol.Model.Partido.DAO;
using System.Collections;



namespace Futbol.Model.FachadaDatos.Actions
{
    class VerPerfilArbitroAction : NonTransactionalPlainAction
    {
        private int cod_Arbitro;

        public VerPerfilArbitroAction(int cod_Arbitro)
        {
            this.cod_Arbitro = cod_Arbitro;
        }

        public object execute(DbConnection connection)
        {

            ArbitroDAO arbitroDAO = ArbitroDAOFactory.GetDAO();
            ArbitroVO infoArbitro=arbitroDAO.verArbitro(connection, null, cod_Arbitro);
            ArrayList partidosArbitro = arbitroDAO.buscarPartidosArbitro(connection, null, cod_Arbitro);

            return new ArbitroCO(infoArbitro, partidosArbitro);
        }
    }
}