using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Jugador.VO;
using Futbol.Model.Jugador.DAO;
using System.Collections;
using Util.Log;


namespace Futbol.Model.FachadaDatos.Actions
{
    class VerPlantillaEquipoAction : NonTransactionalPlainAction
    {

        private int cod_Equipo;

        public VerPlantillaEquipoAction(int cod_Equipo)
        {
            this.cod_Equipo = cod_Equipo;
        }

        public object execute(DbConnection connection)
        {

            JugadorDAO jugadorDAO = JugadorDAOFactory.GetDAO();
            ArrayList listaJugadores = jugadorDAO.verPlantillaEquipo(connection, null, cod_Equipo, 0, 2);

            return listaJugadores;
        }
    }
}