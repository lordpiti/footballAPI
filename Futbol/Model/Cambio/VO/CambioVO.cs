using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Cambio.VO
{
    public class CambioVO
    {
        private int cd_Cambio;
        private int cd_Partido;
        private int cd_Jugador_Entra;
        private int cd_Jugador_Sale;
        private int minuto;
        


        public CambioVO(int cd_Cambio, int cd_Partido, int cd_Jugador_Entra,
            int cd_Jugador_Sale, int minuto)
        {
            this.cd_Cambio = cd_Cambio;
            this.cd_Partido = cd_Partido;
            this.cd_Jugador_Entra = cd_Jugador_Entra;
            this.cd_Jugador_Sale = cd_Jugador_Sale;
            this.minuto = minuto;
        }


        public CambioVO(int cd_Partido, int cd_Jugador_Entra,
            int cd_Jugador_Sale, int minuto)
        {
            this.cd_Partido = cd_Partido;
            this.cd_Jugador_Entra = cd_Jugador_Entra;
            this.cd_Jugador_Sale = cd_Jugador_Sale;
            this.minuto = minuto;
        }


        public CambioVO(int cd_Jugador_Entra,
            int cd_Jugador_Sale, int minuto)
        {            
            this.cd_Jugador_Entra = cd_Jugador_Entra;
            this.cd_Jugador_Sale = cd_Jugador_Sale;
            this.minuto = minuto;
        }


        public int Cd_Cambio
        {
            get { return cd_Cambio; }
            set { cd_Cambio = value; }
        }


        public int Cd_Partido
        {
            get { return cd_Partido; }
            set { cd_Partido = value; }
        }


        public int Cd_Jugador_Entra
        {
            get { return cd_Jugador_Entra; }
            set { cd_Jugador_Entra = value; }
        }

        public int Cd_Jugador_Sale
        {
            get { return cd_Jugador_Sale; }
            set { cd_Jugador_Sale = value; }
        }


        public int Minuto
        {
            get { return minuto; }
            set { minuto = value; }
        }



        public String toString()
        {
            return (cd_Cambio + " " + cd_Jugador_Entra + " " + cd_Partido + " ");
        }
    }
}
