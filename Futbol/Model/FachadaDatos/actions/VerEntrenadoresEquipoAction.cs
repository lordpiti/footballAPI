using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Entrenador.VO;
using Futbol.Model.Entrenador.DAO;
using System.Collections;



namespace Futbol.Model.FachadaDatos.Actions
{
    class VerEntrenadoresEquipoAction : NonTransactionalPlainAction
    {

        private int cod_Equipo;

        public VerEntrenadoresEquipoAction(int cod_Equipo)
        {
            this.cod_Equipo = cod_Equipo;
        }

        public object execute(DbConnection connection)
        {

            EntrenadorDAO entrenadorDAO = EntrenadorDAOFactory.GetDAO();
            var listaEntrenadores = entrenadorDAO.verEntrenadoresEquipo(connection, null, cod_Equipo, 0, 2);

            return listaEntrenadores;
        }
    }
}