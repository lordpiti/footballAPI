using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.PartidoJugado
{
    public class TemporadaCO
    {
        private String temporada;


        public TemporadaCO(String temporada)
        {
            this.temporada = temporada;
        }

        public String Temporada
        {
            get { return temporada; }
            set { temporada = value; }
        }

        
        public String toString()
        {
            return temporada;
        }
    }
}
