using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Partido.VO;
using Futbol.Model.Arbitro.VO;
using Futbol.Model.Estadio.VO;

namespace Futbol.Model.Partido
{
    public class PartidoCompletoCO
    {
        private EquipoVO equipoLocal;
        private EquipoVO equipoVisitante;
        private PartidoVO partido;
        private ArrayList jugadoresTitularesLocal;
        private ArrayList jugadoresTitularesVisitante;
        private ArrayList jugadoresNoTitularesLocal;
        private ArrayList jugadoresNoTitularesVisitante;
        private ArrayList golesLocal;
        private ArrayList golesVisitante;
        private ArrayList tarjetasLocal;
        private ArrayList tarjetasVisitante;
        private ArrayList cambiosLocal;
        private ArrayList cambiosVisitante;
        private EstadioVO estadio;
        private ArbitroVO arbitro;
        private String cronica;



        public PartidoCompletoCO(EquipoVO equipoLocal,EquipoVO equipoVisitante,
            PartidoVO partido, ArrayList jugadoresTitularesLocal,
            ArrayList jugadoresTitularesVisitante,ArrayList jugadoresNoTitularesLocal,
            ArrayList jugadoresNoTitularesVisitante,ArrayList golesLocal,
            ArrayList golesVisitante,ArrayList tarjetasLocal, ArrayList tarjetasVisitante,
            EstadioVO estadio, ArbitroVO arbitro,String cronica,ArrayList cambiosLocal,
            ArrayList cambiosVisitante)
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


        public ArrayList JugadoresTitularesLocal
        {
            get { return jugadoresTitularesLocal; }
            set { jugadoresTitularesLocal = value; }
        }


        public ArrayList JugadoresTitularesVisitante
        {
            get { return jugadoresTitularesVisitante; }
            set { jugadoresTitularesVisitante = value; }
        }


        public ArrayList JugadoresNoTitularesLocal
        {
            get { return jugadoresNoTitularesLocal; }
            set { jugadoresNoTitularesLocal = value; }
        }

        public ArrayList JugadoresNoTitularesVisitante
        {
            get { return jugadoresNoTitularesVisitante; }
            set { jugadoresNoTitularesVisitante = value; }
        }


        public ArrayList GolesLocal
        {
            get { return golesLocal; }
            set { golesLocal = value; }
        }

        
        public ArrayList GolesVisitante
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

        public ArrayList CambiosLocal
        {
            get { return cambiosLocal; }
            set { cambiosLocal = value; }
        }

        public ArrayList CambiosVisitante
        {
            get { return cambiosVisitante; }
            set { cambiosVisitante = value; }
        }


    }
}