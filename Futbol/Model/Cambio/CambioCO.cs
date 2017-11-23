using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Cambio
{
    public class CambioCO
    {
        private int cod_Cambio;
        private int minuto;
        private int codJugadorSale;
        private int dorsalSale;
        private String nombreJugadorSale;
        private int codJugadorEntra;
        private int dorsalEntra;
        private String nombreJugadorEntra;
        


        public CambioCO(int cod_Cambio, int minuto, int codJugadorSale,
            int dorsalSale,String nombreJugadorSale, int codJugadorEntra,
            int dorsalEntra,String nombreJugadorEntra)
        {
            this.cod_Cambio=cod_Cambio;
            this.minuto=minuto;
            this.codJugadorSale=codJugadorSale;
            this.dorsalSale=dorsalSale;
            this.nombreJugadorSale=nombreJugadorSale;
            this.codJugadorEntra=codJugadorEntra;
            this.dorsalEntra=dorsalEntra;
            this.nombreJugadorEntra=nombreJugadorEntra;
        }




        public int Cod_Cambio
        {
            get { return cod_Cambio; }
            set { cod_Cambio = value; }
        }


        public int Minuto
        {
            get { return minuto; }
            set { minuto = value; }
        }


        public int CodJugadorEntra
        {
            get { return codJugadorEntra; }
            set { codJugadorEntra = value; }
        }

        public int CodJugadorSale
        {
            get { return codJugadorSale; }
            set { codJugadorSale = value; }
        }


        public int DorsalJugadorEntra
        {
            get { return dorsalEntra; }
            set { dorsalEntra = value; }
        }

        public int DorsalJugadorSale
        {
            get { return dorsalSale; }
            set { dorsalSale = value; }
        }


        public String NombreJugadorEntra
        {
            get { return nombreJugadorEntra; }
            set { nombreJugadorEntra = value; }
        }

        public String NombreJugadorSale
        {
            get { return nombreJugadorSale; }
            set { nombreJugadorSale = value; }
        }






        public String toString()
        {
            return null;
        }
    }
}
