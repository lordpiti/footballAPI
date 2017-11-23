using System;
using System.Collections.Generic;
using System.Text;
using Util.Exceptions;
using Util.Log;
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
    public class PartidoTotalCO
    {
        private PartidoVO partido;
        private ArrayList partidosJugados;
        private ArrayList goles;
        private ArrayList cambios;
        private ArrayList tarjetas;


        public PartidoTotalCO(PartidoVO partidoVO, ArrayList partidosJugadosVO,
            ArrayList goles)
        {
            this.partido = partidoVO;
            this.partidosJugados = partidosJugadosVO;
            this.goles = goles;
            
        }


        public PartidoTotalCO(PartidoVO partidoVO, ArrayList partidosJugadosVO,
    ArrayList goles, ArrayList cambios)
        {
            this.partido = partidoVO;
            this.partidosJugados = partidosJugadosVO;
            this.goles = goles;
            this.cambios = cambios;
        }


        public PartidoTotalCO(PartidoVO partidoVO, ArrayList partidosJugadosVO,
ArrayList goles, ArrayList cambios, ArrayList tarjetas)
        {
            this.partido = partidoVO;
            this.partidosJugados = partidosJugadosVO;
            this.goles = goles;  
            this.cambios = cambios;            
            this.tarjetas = tarjetas;
            
        }



        public PartidoVO Partido
        {
            get { return partido; }
            set { partido = value; }
        }


        public ArrayList PartidosJugados
        {
            get { return partidosJugados; }
            set { partidosJugados = value; }
        }


        public ArrayList Goles
        {
            get { return goles; }
            set { goles = value; }
        }



        public ArrayList Cambios
        {
            get { return cambios; }
            set { cambios = value; }
        }

        

        public ArrayList Tarjetas
        {
            get { return tarjetas; }
            set { tarjetas = value; }
        }


    }
}
