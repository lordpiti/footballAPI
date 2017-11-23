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
    public class VerResultadosBusquedaAction : NonTransactionalPlainAction
    {

        private int cod_Local;
        private int cod_Visitante;
        private int cod_Competicion;
        private String jornada;
        private int flag;

        public VerResultadosBusquedaAction(int cod_Local,int cod_Visitante, int cod_Competicion,
            String jornada,int flag)
        {
            this.cod_Local = cod_Local;
            this.cod_Visitante = cod_Visitante;
            this.cod_Competicion = cod_Competicion;
            this.jornada = jornada;
            this.flag = flag;
        }

        public object execute(DbConnection connection)
        {

            PartidoDAO partidoDAO = new PartidoDAO();

            return (partidoDAO.buscarPartidosEquipos(connection,null,cod_Local,cod_Visitante,
                cod_Competicion,jornada,flag));

        }
    }
}