using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Tarjeta.VO
{
    public class TarjetaVO
    {
        private int cd_Tarjeta;
        private int cd_Partido;
        private int cd_Jugador;
        private int minuto;
        private String tipo;
        private String motivo;
        


        public TarjetaVO(int cd_Tarjeta, int cd_Partido, int cd_Jugador,
            int minuto, String tipo, String motivo)
        {
            this.cd_Tarjeta = cd_Tarjeta;
            this.cd_Partido = cd_Partido;
            this.cd_Jugador = cd_Jugador;
            this.minuto = minuto;
            this.tipo = tipo;
            this.motivo = motivo;
        }


        public TarjetaVO(int cd_Partido, int cd_Jugador, int minuto, 
            String tipo, String motivo)
        {            
            this.cd_Partido = cd_Partido;
            this.cd_Jugador = cd_Jugador;
            this.minuto = minuto;
            this.tipo = tipo;
            this.motivo = motivo;
        }


        public TarjetaVO(int cd_Jugador, int minuto, String tipo, String motivo)
        {          
            this.cd_Jugador = cd_Jugador;
            this.minuto = minuto;
            this.tipo = tipo;
            this.motivo = motivo;
        }


        public int Cd_Tarjeta
        {
            get { return cd_Tarjeta; }
            set { cd_Tarjeta = value; }
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


        public String Motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }



        public String toString()
        {
            return (cd_Tarjeta + " " + cd_Jugador + " " + cd_Partido + " ");
        }
    }
}
