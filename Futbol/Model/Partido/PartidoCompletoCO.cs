using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Partido.VO;
using Futbol.Model.Arbitro.VO;
using Futbol.Model.Estadio.VO;
using Futbol.Model.Cambio;
using Futbol.Model.Gol;

namespace Futbol.Model.Partido
{
    public class PartidoCompletoCO
    {
        private EquipoVO equipoLocal;
        private EquipoVO equipoVisitante;
        private PartidoVO partido;
        private List<PartidoJugadoBasicoCO> jugadoresTitularesLocal;
        private List<PartidoJugadoBasicoCO> jugadoresTitularesVisitante;
        private List<PartidoJugadoBasicoCO> jugadoresNoTitularesLocal;
        private List<PartidoJugadoBasicoCO> jugadoresNoTitularesVisitante;
        private List<GolCO> golesLocal;
        private List<GolCO> golesVisitante;
        private ArrayList tarjetasLocal;
        private ArrayList tarjetasVisitante;
        private List<CambioCO> cambiosLocal;
        private List<CambioCO> cambiosVisitante;
        private EstadioVO estadio;
        private ArbitroVO arbitro;
        private String cronica;



        public PartidoCompletoCO(EquipoVO equipoLocal,EquipoVO equipoVisitante,
            PartidoVO partido, List<PartidoJugadoBasicoCO> jugadoresTitularesLocal,
            List<PartidoJugadoBasicoCO> jugadoresTitularesVisitante, List<PartidoJugadoBasicoCO> jugadoresNoTitularesLocal,
            List<PartidoJugadoBasicoCO> jugadoresNoTitularesVisitante, List<GolCO> golesLocal,
            List<GolCO> golesVisitante,ArrayList tarjetasLocal, ArrayList tarjetasVisitante,
            EstadioVO estadio, ArbitroVO arbitro,String cronica, List<CambioCO> cambiosLocal,
            List<CambioCO> cambiosVisitante)
        {
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
            this.partido = partido;
            this.jugadoresTitularesLocal=jugadoresTitularesLocal;
            this.jugadoresTitularesVisitante=jugadoresTitularesVisitante;
            this.jugadoresNoTitularesLocal=jugadoresNoTitularesLocal;
            this.jugadoresNoTitularesVisitante=jugadoresNoTitularesVisitante;
            this.golesLocal=golesLocal;
            this.golesVisitante=golesVisitante;
            this.tarjetasLocal = tarjetasLocal;
            this.tarjetasVisitante = tarjetasVisitante;
            this.arbitro = arbitro;
            this.estadio = estadio;
            this.cronica=cronica;
            this.cambiosLocal = cambiosLocal;
            this.cambiosVisitante = cambiosVisitante;
        }


        public EquipoVO EquipoLocal
        {
            get { return equipoLocal; }
            set { equipoLocal = value; }
        }
        
        
        public EquipoVO EquipoVisitante
        {
            get { return equipoVisitante; }
            set { equipoVisitante = value; }
        }


        public List<PartidoJugadoBasicoCO> JugadoresTitularesLocal
        {
            get { return jugadoresTitularesLocal; }
            set { jugadoresTitularesLocal = value; }
        }


        public List<PartidoJugadoBasicoCO> JugadoresTitularesVisitante
        {
            get { return jugadoresTitularesVisitante; }
            set { jugadoresTitularesVisitante = value; }
        }


        public List<PartidoJugadoBasicoCO> JugadoresNoTitularesLocal
        {
            get { return jugadoresNoTitularesLocal; }
            set { jugadoresNoTitularesLocal = value; }
        }

        public List<PartidoJugadoBasicoCO> JugadoresNoTitularesVisitante
        {
            get { return jugadoresNoTitularesVisitante; }
            set { jugadoresNoTitularesVisitante = value; }
        }


        public List<GolCO> GolesLocal
        {
            get { return golesLocal; }
            set { golesLocal = value; }
        }

        
        public List<GolCO> GolesVisitante
        {
            get { return golesVisitante; }
            set { golesVisitante = value; }
        }


        public ArrayList TarjetasLocal
        {
            get { return tarjetasLocal; }
            set { tarjetasLocal = value; }
        }


        public ArrayList TarjetasVisitante
        {
            get { return tarjetasVisitante; }
            set { tarjetasVisitante = value; }
        }


        public String Cronica
        {
            get { return cronica; }
            set { cronica = value; }
        }


        public PartidoVO Partido
        {
            get { return partido; }
            set { partido = value; }
        }



        public EstadioVO Estadio
        {
            get { return estadio; }
            set { estadio = value; }
        }


        public ArbitroVO Arbitro
        {
            get { return arbitro; }
            set { arbitro = value; }
        }

        public List<CambioCO> CambiosLocal
        {
            get { return cambiosLocal; }
            set { cambiosLocal = value; }
        }

        public List<CambioCO> CambiosVisitante
        {
            get { return cambiosVisitante; }
            set { cambiosVisitante = value; }
        }


    }
}