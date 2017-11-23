using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Jugador;
using Futbol.Model.Jugador.DAO;
using Futbol.Model.HcoIntegrante.DAO;
using Futbol.Model.HcoIntegrante;
using Futbol.Model.PartidoJugado.DAO;
using System.Collections;
using Util.Log;


namespace Futbol.Model.FachadaDatos.Actions
{
    class VerPerfilJugadorAction : NonTransactionalPlainAction
    {
        private int cod_Jugador;

        public VerPerfilJugadorAction(int cod_Jugador)
        {
            this.cod_Jugador = cod_Jugador;
        }

        public object execute(DbConnection connection)
        {

            JugadorDAO jugadorDAO = JugadorDAOFactory.GetDAO();
            DatosTotalesJugador datosTotales = jugadorDAO.verJugador(connection, null, cod_Jugador);
            HcoIntegranteDAO hcoIntegranteDAO = HcoIntegranteDAOFactory.GetDAO();
            ArrayList historial=hcoIntegranteDAO.verHistorialEquipos(connection, null, cod_Jugador);
            PartidoJugadoDAO partidoJugadoDAO=PartidoJugadoDAOFactory.GetDAO();
            ArrayList temporadas = partidoJugadoDAO.temporadasConPartidosJugados(connection, null, cod_Jugador);

            return new PerfilCompletoJugador(datosTotales, historial,temporadas);
        }
    }
}