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
using Util.Log;


namespace Futbol.Model.FachadaPartidos.Actions
{
    class VerPartidosJugadosTemporadaAction : NonTransactionalPlainAction
    {

        private int cod_Jugador;
        private String temporada;
        private int cod_Competicion;

        public VerPartidosJugadosTemporadaAction(int cod_Jugador, String temporada,
            int cod_Competicion)
        {
            this.cod_Jugador = cod_Jugador;
            this.temporada = temporada;
            this.cod_Competicion = cod_Competicion;
        }

        public object execute(DbConnection connection)
        {

            PartidoJugadoDAO partidoJugadoDAO = new PartidoJugadoDAO();
       
            return (partidoJugadoDAO.listarPartidosJugadosCompeticionJugador(connection,
                null,temporada,cod_Competicion,cod_Jugador,2,0));

        }
    }
}