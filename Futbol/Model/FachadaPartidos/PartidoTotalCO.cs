using Futbol.Model.Cambio.VO;
using Futbol.Model.Gol.VO;
using Futbol.Model.Partido.VO;
using Futbol.Model.Tarjeta.VO;
using System.Collections;
using System.Collections.Generic;

namespace Futbol.Model.FachadaPartidos
{
    public class PartidoTotalCO
    {
        private PartidoVO partido;
        private ArrayList partidosJugados;


        public PartidoTotalCO(PartidoVO partidoVO, ArrayList partidosJugadosVO,
            List<GolVO> goles)
        {
            this.partido = partidoVO;
            this.partidosJugados = partidosJugadosVO;
            this.Goles = goles;
        }


        public PartidoTotalCO(PartidoVO partidoVO, ArrayList partidosJugadosVO,
    List<GolVO> goles, List<CambioVO> cambios)
        {
            this.partido = partidoVO;
            this.partidosJugados = partidosJugadosVO;
            this.Goles = goles;
            this.Cambios = cambios;
        }


        public PartidoTotalCO(PartidoVO partidoVO, ArrayList partidosJugadosVO,
List<GolVO> goles, List<CambioVO> cambios, List<TarjetaVO> tarjetas)
        {
            this.partido = partidoVO;
            this.partidosJugados = partidosJugadosVO;
            this.Goles = goles;  
            this.Cambios = cambios;            
            this.Tarjetas = tarjetas;
            
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


        public List<GolVO> Goles { get; set; }



        public List<CambioVO> Cambios { get; set; }

        

        public List<TarjetaVO> Tarjetas { get; set; }


    }
}
