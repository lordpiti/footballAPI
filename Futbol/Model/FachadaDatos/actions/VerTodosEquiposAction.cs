using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Equipo.DAO;
using System.Collections;
using Util.Log;


namespace Futbol.Model.FachadaDatos.Actions
{
    class VerTodosEquiposAction : NonTransactionalPlainAction
    {

        public VerTodosEquiposAction()
        {
            
        }

        public object execute(DbConnection connection)
        {

            EquipoDAO equipoDAO = EquipoDAOFactory.GetDAO();
            ArrayList listaEquipos = equipoDAO.listarEquipos(connection,null,0,2);


            return listaEquipos;
        }
    }
}
