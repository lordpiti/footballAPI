using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Futbol.Model.HcoIntegrante;
using Futbol.Model.Jugador;

namespace Futbol.Model.FachadaAdmin.COs
{
     public class PerfilCompletoJugador
    {
        private DatosTotalesJugador datosTotales;
        private ArrayList historial;
        private ArrayList listaTemporadas;


        public PerfilCompletoJugador(DatosTotalesJugador datosTotales, ArrayList historial,
            ArrayList listaTemporadas)
        {
            this.datosTotales = datosTotales;
            this.historial = historial;
            this.listaTemporadas = listaTemporadas;
        }


        
        public DatosTotalesJugador DatosTotales
        {
            get { return datosTotales; }
            set { datosTotales = value; }
        }

        public ArrayList Historial
        {
            get { return historial; }
            set { historial = value; }
        }


         public ArrayList ListaTemporadas
         {
             get { return listaTemporadas; }
             set { listaTemporadas = value; }
         }
    }
}
