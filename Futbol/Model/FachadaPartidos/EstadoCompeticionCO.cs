using System;
using System.Collections.Generic;
using System.Text;
using Util.Exceptions;

using System.Configuration;
using System.Data.Common;
using System.Collections;
using System.Xml;
using Futbol.Model.Estadio.VO;
using Futbol.Model.Integrante.VO;
using Futbol.Model.Jugador.VO;
using Futbol.Model.Competicion.VO;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Partido.VO;
using Futbol.Model.PartidoJugado.VO;
using Futbol.Model.HcoIntegrante.VO;
using Futbol.Model.Calendario;
using Futbol.Model.Clasificacion;
using Futbol.Model.Gol;
using Futbol.Model.Partido;
using Futbol.Model.PartidoJugado;

namespace Futbol.Model.FachadaPartidos
{
    public class EstadoCompeticionCO
    {
        private List<ClasificacionCO> clasificacion;
        private List<CalendarioCO> siguienteJornada;
        private List<TemporadaCO> restoJornadas;
        private List<PartidoCompeticionJornadaCO> resultados;
        private String foto;
        private String tipoCompeticion;
        private List<GoleadorCO> listaGoleadores;




        public EstadoCompeticionCO(List<ClasificacionCO> clasificacion, List<CalendarioCO> siguienteJornada,
            List<TemporadaCO> restoJornadas,List<PartidoCompeticionJornadaCO> resultados,String foto,String tipoCompeticion,
            List<GoleadorCO> listaGoleadores)
        {
            this.clasificacion = clasificacion;
            this.siguienteJornada = siguienteJornada;
            this.restoJornadas = restoJornadas;
            this.resultados = resultados;
            this.foto = foto;
            this.tipoCompeticion = tipoCompeticion;
            this.listaGoleadores = listaGoleadores;
        }


        public List<ClasificacionCO> Clasificacion
        {
            get { return clasificacion; }
            set { clasificacion = value; }
        }


        public List<PartidoCompeticionJornadaCO> Resultados
        {
            get { return resultados; }
            set { resultados = value; }
        }


        public List<CalendarioCO> SiguienteJornada
        {
            get { return siguienteJornada; }
            set { siguienteJornada = value; }
        }

        public List<TemporadaCO> RestoJornadas
        {
            get { return restoJornadas; }
            set { restoJornadas = value; }
        }

        public String Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public String TipoCompeticion
        {
            get { return tipoCompeticion; }
            set { tipoCompeticion = value; }
        }

        public List<GoleadorCO> ListaGoleadores
        {
            get { return listaGoleadores; }
            set { listaGoleadores = value; }
        }
    }
}
