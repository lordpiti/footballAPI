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
using Futbol.Model.Jugador.VO;
using Futbol.Model.Directivo;
using Futbol.Model.Entrenador;

namespace Futbol.Model.FachadaAdmin.COs
{
    public class EquipoTotalCO<T>
    {
        private EquipoVO equipo;
        private List<T> listaJugadores;
        private List<EntrenadorPlantillaCO> listaEntrenadoresView;
        private List<EntrenadorCO> listaEntrenadoresCreate;
        private List<DirectivoCO> _listaDirectivosCreate;
        private List<DirectivoPlantillaCO> _listaDirectivosView;
        private EstadioVO estadio;


        public EquipoTotalCO(EquipoVO equipo,List<T> listaJugadores, List<EntrenadorCO> listaEntrenadoresCreate,
            List<EntrenadorPlantillaCO> listaEntrenadoresView,List<DirectivoCO> listaDirectivosCreate, List<DirectivoPlantillaCO> listaDirectivosView, EstadioVO estadio)
        {
            this.equipo = equipo;
            this.listaJugadores = listaJugadores;
            this.listaEntrenadoresCreate = listaEntrenadoresCreate;
            this.listaEntrenadoresView = listaEntrenadoresView;
            this._listaDirectivosCreate = listaDirectivosCreate;
            this._listaDirectivosView = listaDirectivosView;
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


        public List<T> ListaJugadores
        {
            get { return listaJugadores; }
            set { listaJugadores = value; }
        }


        public List<EntrenadorPlantillaCO> ListaEntrenadoresView
        {
            get { return listaEntrenadoresView; }
            set { listaEntrenadoresView = value; }
        }

        public List<EntrenadorCO> ListaEntrenadoresCreate
        {
            get { return listaEntrenadoresCreate; }
            set { listaEntrenadoresCreate = value; }
        }


        public List<DirectivoCO> ListaDirectivosCreate
        {
            get { return _listaDirectivosCreate; }
            set { _listaDirectivosCreate = value; }
        }

        public List<DirectivoPlantillaCO> ListaDirectivosView
        {
            get { return _listaDirectivosView; }
            set { _listaDirectivosView = value; }
        }

    }



}
