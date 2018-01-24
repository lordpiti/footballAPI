using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Partido.DAO;
using Futbol.Model.Partido.VO;
using Futbol.Model.PartidoJugado.DAO;
using Futbol.Model.PartidoJugado.VO;
using Futbol.Model.Gol.VO;
using Futbol.Model.Gol.DAO;
using System.Collections;



namespace Futbol.Model.FachadaPartidos.Actions
{
    class VerEstadisticasJugadorAgrupadasAction : NonTransactionalPlainAction
    {

        private int cod_Jugador;
        private String temporada;
        private int cod_Competicion;
        private String tipo;

        public VerEstadisticasJugadorAgrupadasAction(int cod_Jugador, String temporada,
            int cod_Competicion,String tipo)
        {
            this.cod_Jugador = cod_Jugador;
            this.temporada = temporada;
            this.cod_Competicion = cod_Competicion;
            this.tipo = tipo;
        }

        public object execute(DbConnection connection)
        {

            PartidoJugadoDAO partidoJugadoDAO = new PartidoJugadoDAO();

            return (partidoJugadoDAO.verEstadisticasTemporada(connection, null,
                cod_Jugador, temporada,cod_Competicion,tipo));

        }
    }
}