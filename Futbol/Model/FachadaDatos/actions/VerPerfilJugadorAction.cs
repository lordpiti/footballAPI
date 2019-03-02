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

            var jugadorDAO = new JugadorDAO();
            var datosTotales = jugadorDAO.verJugador(connection, null, cod_Jugador);
            var hcoIntegranteDAO = new HcoIntegranteDAO();
            var historial=hcoIntegranteDAO.verHistorialEquipos(connection, null, cod_Jugador);
            var partidoJugadoDAO=new PartidoJugadoDAO();
            var temporadas = partidoJugadoDAO.temporadasConPartidosJugados(connection, null, cod_Jugador);

            return new PerfilCompletoJugador(datosTotales, historial,temporadas);
        }
    }
}