using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Gol.VO
{
    public class GolVO
    {
        private int cd_Gol;
        private int cd_Partido;
        private int cd_Jugador;
        private int minuto;
        private String tipo;
        


        public GolVO(int cd_Gol, int cd_Partido, int cd_Jugador, int minuto, String tipo)
        {
            this.cd_Gol = cd_Gol;
            this.cd_Partido = cd_Partido;
            this.cd_Jugador = cd_Jugador;
            this.minuto = minuto;
            this.tipo = tipo;
        }


        public GolVO(int cd_Partido, int cd_Jugador, int minuto, String tipo)
        {            
            this.cd_Partido = cd_Partido;
            this.cd_Jugador = cd_Jugador;
            this.minuto = minuto;
            this.tipo = tipo;
        }


        public int Cd_Gol
        {
            get { return cd_Gol; }
            set { cd_Gol = value; }

        }

        public int Cd_Partido
        {
            get { return cd_Partido; }
            set { cd_Partido = value; }

        }

        public int Cd_Jugador
        {
            get { return cd_Jugador; }
            set { cd_Jugador = value; }

        }

        public int Minuto
        {
            get { return minuto; }
            set { minuto = value; }

        }


        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }

        }




        public String toString()
        {
            return (cd_Gol + " " + cd_Jugador + " " + cd_Partido + " ");
        }
    }
}
