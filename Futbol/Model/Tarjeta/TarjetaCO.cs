using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Tarjeta
{
    public class TarjetaCO
    {
        private int cod_Jugador;
        private int dorsal;
        private String nombre;
        private int minuto;
        private String tipo;
        private String motivo;



        public TarjetaCO(int cod_Jugador, int dorsal, String nombre,int minuto,
            String tipo, String motivo)
        {
            this.cod_Jugador = cod_Jugador;
            this.dorsal=dorsal;
            this.nombre = nombre;
            this.minuto = minuto;
            this.tipo = tipo;
            this.motivo = motivo;
        }


        public int Dorsal
        {
            get { return dorsal; }
            set { dorsal = value; }
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


        public String Motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }


    }
}
