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

namespace Futbol.Model.FachadaPartidos
{
    public class EstadoCompeticionCO
    {
        private ArrayList clasificacion;
        private ArrayList siguienteJornada;
        private ArrayList restoJornadas;
        private ArrayList resultados;
        private String foto;
        private String tipoCompeticion;
        private ArrayList listaGoleadores;




        public EstadoCompeticionCO(ArrayList clasificacion, ArrayList siguienteJornada,
            ArrayList restoJornadas,ArrayList resultados,String foto,String tipoCompeticion,
            ArrayList listaGoleadores)
        {
            this.clasificacion = clasificacion;
            this.siguienteJornada = siguienteJornada;
            this.restoJornadas = restoJornadas;
            this.resultados = resultados;
            this.foto = foto;
            this.tipoCompeticion = tipoCompeticion;
            this.listaGoleadores = listaGoleadores;
        }


        public ArrayList Clasificacion
        {
            get { return clasificacion; }
            set { clasificacion = value; }
        }


        public ArrayList Resultados
        {
            get { return resultados; }
            set { resultados = value; }
        }


        public ArrayList SiguienteJornada
        {
            get { return siguienteJornada; }
            set { siguienteJornada = value; }
        }

        public ArrayList RestoJornadas
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

        public ArrayList ListaGoleadores
        {
            get { return listaGoleadores; }
            set { listaGoleadores = value; }
        }
    }
}
