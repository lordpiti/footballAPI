using System;
using System.Collections.Generic;
using System.Text;
using Futbol.Model.Gol.VO;

namespace Futbol.Model.Gol
{
    public class GolCO
    {
        private int cod_Partido;
        private int cod_Gol;
        private int cod_Jugador;
        private String tipo;
        private int minuto;
        private String nombre;
        private String apellidos;
        private String video;




        public GolCO(int cod_Partido, int cod_Gol, int cod_Jugador, String tipo,
            int minuto, String nombre, String apellidos,String video)
        {
            this.cod_Partido = cod_Partido;
            this.cod_Gol = cod_Gol;
            this.cod_Jugador = cod_Jugador;
            this.tipo = tipo;
            this.minuto = minuto;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.video = video;
        }

        public int Cod_Gol
        {
            get { return cod_Gol; }
            set { cod_Gol = value; }
        }

        public int Cod_Partido
        {
            get { return cod_Partido; }
            set { cod_Partido = value; }
        }

        public int Cod_Jugador
        {
            get { return cod_Jugador; }
            set { cod_Jugador = value; }
        }

        public int Minuto
        {
            get { return minuto; }
            set { minuto = value; }
        }


        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public String Video
        {
            get { return video; }
            set { video = value; }
        }

    }
}
