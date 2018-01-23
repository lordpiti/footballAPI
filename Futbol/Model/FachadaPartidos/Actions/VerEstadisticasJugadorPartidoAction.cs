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
    public class VerEstadisticasJugadorPartidoAction : NonTransactionalPlainAction
    {

        private int cod_Jugador;
        private int cod_Partido;

        public VerEstadisticasJugadorPartidoAction(int cod_Jugador, int cod_Partido)
        {
            this.cod_Jugador = cod_Jugador;
            this.cod_Partido = cod_Partido;
        }

        public object execute(DbConnection connection)
        {

            PartidoJugadoDAO partidoJugadoDAO = new PartidoJugadoDAO();

            return (partidoJugadoDAO.verEstadisticasJugadorPartido(connection,null,
                cod_Jugador,cod_Partido));

        }
    }
}