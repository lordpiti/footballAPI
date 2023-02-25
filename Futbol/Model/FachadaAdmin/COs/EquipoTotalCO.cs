using System;
using System.Collections.Generic;
using System.Text;
using Util.Exceptions;
using System.Configuration;
using System.Data.Common;
using System.Collections;
using System.Xml;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Estadio.VO;
using Futbol.Model.HcoIntegrante.VO;

namespace Futbol.Model.FachadaAdmin.COs
{
    public class EquipoTotalCO
    {
        private EquipoVO equipo;
        private ArrayList listaJugadores;
        private ArrayList listaEntrenadores;
        private ArrayList listaDirectivos;
        private EstadioVO estadio;


        public EquipoTotalCO(EquipoVO equipo, ArrayList listaJugadores,
            ArrayList listaEntrenadores, ArrayList listaDirectivos, EstadioVO estadio)
        {
            this.equipo = equipo;
            this.listaJugadores = listaJugadores;
            this.listaEntrenadores = listaEntrenadores;
            this.listaDirectivos = listaDirectivos;
            this.estadio = estadio;
        }


        public EquipoVO Equipo
        {
            get { return equipo; }
            set { equipo = value; }
        }

        public EstadioVO Estadio
        {
            get { return estadio; }
            set { estadio = value; }
        }


        public ArrayList ListaJugadores
        {
            get { return listaJugadores; }
            set { listaJugadores = value; }
        }


        public ArrayList ListaEntrenadores
        {
            get { return listaEntrenadores; }
            set { listaEntrenadores = value; }
        }


        public ArrayList ListaDirectivos
        {
            get { return listaDirectivos; }
            set { listaDirectivos = value; }
        }

    }



}