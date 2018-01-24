using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Partido.DAO;
using Futbol.Model.Partido.VO;
using Futbol.Model.PartidoJugado.DAO;
using Futbol.Model.PartidoJugado.VO;
using Futbol.Model.Calendario.DAO;
using Futbol.Model.Calendario.VO;
using Futbol.Model.Clasificacion.DAO;
using Futbol.Model.Clasificacion.VO;
using Futbol.Model.Competicion.VO;
using Futbol.Model.Competicion.DAO;
using Futbol.Model.Gol.VO;
using Futbol.Model.Gol.DAO;



namespace Futbol.Model.FachadaPartidos.Actions
{
    class VerEstadoCompeticionAction : NonTransactionalPlainAction
    {

        private String jornada;
        private int cod_Competicion;

        public VerEstadoCompeticionAction(int cod_Competicion, String jornada)
        {
            this.jornada = jornada;
            this.cod_Competicion = cod_Competicion;
        }

        public object execute(DbConnection connection)
        {

            PartidoDAO partidoDAO = PartidoDAOFactory.GetDAO();
            CalendarioDAO calendarioDAO = CalendarioDAOFactory.GetDAO();
            ClasificacionDAO clasificacionDAO = ClasificacionDAOFactory.GetDAO();
            CompeticionDAO competicionDAO = CompeticionDAOFactory.GetDAO();
            GolDAO golDAO = GolDAOFactory.GetDAO();
            ArrayList siguienteJornada=null;
            ArrayList clasificacion = null;
            CompeticionVO competicion=competicionDAO.buscarCompeticionId(connection,null,cod_Competicion);
            String tipoCompeticion = competicion.Tipo;
            String foto = competicion.Foto;
            

           // if (cod_Competicion != 2)
            if (tipoCompeticion.Equals("Liga"))
            {
                int jornadaNum = Int32.Parse(jornada) + 1; 
                
                siguienteJornada= calendarioDAO.verCalendarioCompeticionJornada(connection,
                    null, cod_Competicion, Convert.ToString(jornadaNum));
            }
            
            ArrayList resultados = partidoDAO.verPartidosCompeticionJornada(connection,
                null, cod_Competicion, jornada);

            //if (cod_Competicion != 2)
            if (tipoCompeticion.Equals("Liga"))
            {
                clasificacion = clasificacionDAO.clasificacionJornadaTemporada(connection,
                    null, cod_Competicion, Int32.Parse(jornada));
            }
            
            ArrayList jornadasCompeticion = partidoDAO.verJornadasCompeticion(connection,
                null, cod_Competicion);

            ArrayList goleadoresCompeticion = golDAO.listarGoleadoresCompeticion(connection, null, cod_Competicion);
           
            return (new EstadoCompeticionCO(clasificacion,siguienteJornada,jornadasCompeticion,
                resultados,foto,tipoCompeticion,goleadoresCompeticion));


        }
    }
}