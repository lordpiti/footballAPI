using System;
using System.Collections.Generic;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Partido.VO;
using Futbol.Model.Arbitro.VO;
using Futbol.Model.Estadio.VO;
using Futbol.Model.Cambio;
using Futbol.Model.Gol;
using Futbol.Model.Tarjeta;

namespace Futbol.Model.Partido
{
    public class PartidoCompletoCO
    {
        public PartidoCompletoCO(EquipoVO equipoLocal,EquipoVO equipoVisitante,
            PartidoVO partido, List<PartidoJugadoBasicoCO> jugadoresTitularesLocal,
            List<PartidoJugadoBasicoCO> jugadoresTitularesVisitante, List<PartidoJugadoBasicoCO> jugadoresNoTitularesLocal,
            List<PartidoJugadoBasicoCO> jugadoresNoTitularesVisitante, List<GolCO> golesLocal,
            List<GolCO> golesVisitante, List<TarjetaCO> tarjetasLocal, List<TarjetaCO> tarjetasVisitante,
            EstadioVO estadio, ArbitroVO arbitro,String cronica, List<CambioCO> cambiosLocal,
            List<CambioCO> cambiosVisitante)
        {
            this.EquipoLocal = equipoLocal;
            this.EquipoVisitante = equipoVisitante;
            this.Partido = partido;
            this.JugadoresTitularesLocal=jugadoresTitularesLocal;
            this.JugadoresTitularesVisitante=jugadoresTitularesVisitante;
            this.JugadoresNoTitularesLocal=jugadoresNoTitularesLocal;
            this.JugadoresNoTitularesVisitante=jugadoresNoTitularesVisitante;
            this.GolesLocal=golesLocal;
            this.GolesVisitante=golesVisitante;
            this.TarjetasLocal = tarjetasLocal;
            this.TarjetasVisitante = tarjetasVisitante;
            this.Arbitro = arbitro;
            this.Estadio = estadio;
            this.Cronica=cronica;
            this.CambiosLocal = cambiosLocal;
            this.CambiosVisitante = cambiosVisitante;
        }


        public EquipoVO EquipoLocal { get; set; }


        public EquipoVO EquipoVisitante { get; set; }


        public List<PartidoJugadoBasicoCO> JugadoresTitularesLocal { get; set; }


        public List<PartidoJugadoBasicoCO> JugadoresTitularesVisitante { get; set; }


        public List<PartidoJugadoBasicoCO> JugadoresNoTitularesLocal { get; set; }

        public List<PartidoJugadoBasicoCO> JugadoresNoTitularesVisitante { get; set; }


        public List<GolCO> GolesLocal { get; set; }


        public List<GolCO> GolesVisitante { get; set; }


        public List<TarjetaCO> TarjetasLocal { get; set; }


        public List<TarjetaCO> TarjetasVisitante { get; set; }


        public String Cronica { get; set; }


        public PartidoVO Partido { get; set; }



        public EstadioVO Estadio { get; set; }


        public ArbitroVO Arbitro { get; set; }

        public List<CambioCO> CambiosLocal { get; set; }

        public List<CambioCO> CambiosVisitante { get; set; }


    }
}