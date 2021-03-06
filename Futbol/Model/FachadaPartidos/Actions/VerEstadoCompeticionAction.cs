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
using Futbol.Model.Calendario;
using Futbol.Model.Clasificacion;

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

            PartidoDAO partidoDAO = new PartidoDAO();
            CalendarioDAO calendarioDAO = new CalendarioDAO();
            ClasificacionDAO clasificacionDAO = new ClasificacionDAO();
            CompeticionDAO competicionDAO = new CompeticionDAO();
            GolDAO golDAO = new GolDAO();
            List<CalendarioCO> siguienteJornada =null;
            List<ClasificacionCO> clasificacion = null;
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
            
            var resultados = partidoDAO.verPartidosCompeticionJornada(connection,
                null, cod_Competicion, jornada);

            //if (cod_Competicion != 2)
            if (tipoCompeticion.Equals("Liga"))
            {
                clasificacion = clasificacionDAO.clasificacionJornadaTemporada(connection,
                    null, cod_Competicion, Int32.Parse(jornada));
            }
            
            var jornadasCompeticion = partidoDAO.verJornadasCompeticion(connection,
                null, cod_Competicion);

            var goleadoresCompeticion = golDAO.listarGoleadoresCompeticion(connection, null, cod_Competicion);
           
            return (new EstadoCompeticionCO(clasificacion,siguienteJornada,jornadasCompeticion,
                resultados,foto,tipoCompeticion,goleadoresCompeticion));


        }
    }
}