using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Estadio.VO;
using Futbol.Model.Estadio.DAO;
using System.Collections;



namespace Futbol.Model.FachadaAdmin.Actions
{
    class CrearEstadioAction : NonTransactionalPlainAction
    {

        private EstadioVO estadioVO;

        public CrearEstadioAction(EstadioVO estadioVO)
        {
            this.estadioVO = estadioVO;
        }

        public object execute(DbConnection connection)
        {

            EstadioDAO estadioDAO = EstadioDAOFactory.GetDAO();
            EstadioVO estadioVOcreado = estadioDAO.create(connection, null, estadioVO);

            return estadioVOcreado;
        }
    }
}
