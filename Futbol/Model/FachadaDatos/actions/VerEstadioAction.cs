using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Estadio.VO;
using Futbol.Model.Estadio.DAO;
using System.Collections;
using Util.Log;


namespace Futbol.Model.FachadaDatos.Actions
{
    class VerEstadioAction : NonTransactionalPlainAction
    {

        private int cod_Estadio;

        public VerEstadioAction(int cod_Estadio)
        {
            this.cod_Estadio = cod_Estadio;
        }

        public object execute(DbConnection connection)
        {

            EstadioDAO estadioDAO = EstadioDAOFactory.GetDAO();
            EstadioVO estadioVO= estadioDAO.buscarEstadioId(connection, null, cod_Estadio);

            return estadioVO;
        }
    }
}