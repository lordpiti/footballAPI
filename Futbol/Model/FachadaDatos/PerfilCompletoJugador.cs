using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Futbol.Model.HcoIntegrante;
using Futbol.Model.Jugador;
using Futbol.Model.PartidoJugado;

namespace Futbol.Model.FachadaDatos
{
     public class PerfilCompletoJugador
    {
        private DatosTotalesJugador datosTotales;
        private List<HistorialEquiposCO> historial;
        private List<TemporadaCO> listaTemporadas;


        public PerfilCompletoJugador(DatosTotalesJugador datosTotales, List<HistorialEquiposCO> historial,
            List<TemporadaCO> listaTemporadas)
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

        public List<HistorialEquiposCO> Historial
        {
            get { return historial; }
            set { historial = value; }
        }


         public List<TemporadaCO> ListaTemporadas
         {
             get { return listaTemporadas; }
             set { listaTemporadas = value; }
         }
    }
}
