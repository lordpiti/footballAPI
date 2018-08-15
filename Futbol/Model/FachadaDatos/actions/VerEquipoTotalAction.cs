using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Equipo.DAO;
using Futbol.Model.Jugador.DAO;
using Futbol.Model.Directivo.DAO;
using Futbol.Model.Entrenador.DAO;
using Futbol.Model.Estadio.DAO;
using Futbol.Model.Estadio.VO;
using Futbol.Model.FachadaAdmin.COs;
using System.Collections;
using Futbol.Model.Directivo;

namespace Futbol.Model.FachadaDatos.Actions
{
    class VerEquipoTotalAction : NonTransactionalPlainAction
    {
        int cod_Equipo;

        public VerEquipoTotalAction(int cod_Equipo)
        {
            this.cod_Equipo = cod_Equipo;
        }

        public object execute(DbConnection connection)
        {
            var equipoDAO = EquipoDAOFactory.GetDAO();
            var jugadorDAO = JugadorDAOFactory.GetDAO();
            var entrenadorDAO = EntrenadorDAOFactory.GetDAO();
            var directivoDAO = DirectivoDAOFactory.GetDAO();
            var estadioDAO=EstadioDAOFactory.GetDAO();
            var equipo = equipoDAO.buscarEquipoId(connection, null, cod_Equipo);
            var estadio= estadioDAO.buscarEstadioId(connection,null,equipo.Cd_Estadio);
            var listaJugadores = jugadorDAO.listarJugadoresEquipo(connection, null,
                cod_Equipo, 0, 2);   
            var listaEntrenadores = entrenadorDAO.verEntrenadoresEquipo(connection, null, cod_Equipo, 0, 2);
            var listaDirectivos = directivoDAO.verDirectivosEquipo(connection, null, cod_Equipo, 0, 2);

            return new EquipoTotalCO(equipo, listaJugadores, null, listaEntrenadores, null, listaDirectivos, estadio);
        }
    }
}