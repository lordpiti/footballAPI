using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Partido
{
    public class PartidoJugadoBasicoCO
    {
        private int cod_Partido;
        private int cod_Jugador;
        private String nombre;
        private int minutos;
        private int faltas;
        private int dorsal;
        private int cod_Integrante;




        public PartidoJugadoBasicoCO(int cod_Partido, int cod_Jugador,
            String nombre, int minutos,int faltas,int dorsal,int cod_Integrante)
        {
            this.cod_Jugador = cod_Jugador;
            this.cod_Partido = cod_Partido;
            this.nombre = nombre;
            this.minutos = minutos;
            this.faltas = faltas;
            this.dorsal = dorsal;
            this.cod_Integrante = cod_Integrante;

        }


        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public int Cod_Jugador
        {
            get { return cod_Jugador; }
            set { cod_Jugador = value; }
        }

        public int Cod_Partido
        {
            get { return cod_Partido; }
            set { cod_Partido = value; }
        }

        public int Minutos
        {
            get { return minutos; }
            set { minutos = value; }
        }


        public int Faltas
        {
            get { return faltas; }
            set { faltas = value; }
        }


        public int Dorsal
        {
            get { return dorsal; }
            set { dorsal = value; }
        }


        public int Cod_Integrante
        {
            get { return cod_Integrante; }
            set { cod_Integrante = value; }
        }

        public String toString()
        {
            return ("Cod_Jugador: " + cod_Jugador + " | Cod_Partido: " + cod_Partido +
                "Nombre: "+nombre+" | Apellidos: "+
                   " | Minutos: " + minutos + " | Faltas: " + faltas);

        }


    }
}