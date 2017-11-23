using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.PartidoJugado
{
    public class EstadisticasAgrupadasCO
    {
        private int cod_Jugador;
        private int minutos;
        private int asistencias;
        private int asistenciasGol;
        private int remates;
        private int rematesPorteria;
        private int rematesPoste;
        private int fuerasJuego;
        private int tarjetasAmarillasProvocadas;
        private int tarjetasRojasProvocadas;
        private int faltasRecibidas;
        private int faltasCometidas;
        private int corners;
        private int balonesRecuperados;
        private int balonesPerdidos;
        private int penaltisRecibidos;
        private int penaltisCometidos;



        public EstadisticasAgrupadasCO(int cod_Jugador, int minutos, 
            int asistencias, int asistenciasGol, int remates, int rematesPorteria,
            int rematesPoste, int fuerasJuego, int tarjetasAmarillasProvocadas,
            int tarjetasRojasProvocadas, int faltasRecibidas, int faltasCometidas,
            int corners, int balonesRecuperados, int balonesPerdidos,
            int penaltisRecibidos, int penaltisCometidos)
        {
            this.cod_Jugador = cod_Jugador;
            this.minutos=minutos;
            this.asistencias=asistencias;
            this.asistenciasGol=asistenciasGol;      
            this.remates=remates;
            this.rematesPorteria=rematesPorteria;
            this.rematesPoste=rematesPoste;
            this.fuerasJuego=fuerasJuego;
            this.tarjetasAmarillasProvocadas=tarjetasAmarillasProvocadas;
            this.tarjetasRojasProvocadas=tarjetasRojasProvocadas;
            this.faltasRecibidas=faltasRecibidas;
            this.faltasCometidas=faltasCometidas;
            this.corners=corners;
            this.balonesRecuperados=balonesRecuperados;
            this.balonesPerdidos=balonesPerdidos;
            this.penaltisRecibidos=penaltisRecibidos;
            this.penaltisCometidos=penaltisCometidos;
        }


        


        public int Cod_Jugador
        {
            get { return cod_Jugador; }
            set { cod_Jugador = value; }
        }


        public int Minutos
        {
            get { return minutos; }
            set { minutos = value; }
        }

        public int Asistencias
        {
            get { return asistencias; }
            set { asistencias = value; }
        }

        public int AsistenciasGol
        {
            get { return asistenciasGol; }
            set { asistenciasGol = value; }
        }

        public int Remates
        {
            get { return remates; }
            set { remates = value; }
        }

        public int RematesPorteria
        {
            get { return rematesPorteria; }
            set { rematesPorteria = value; }
        }

        public int RematesPoste
        {
            get { return rematesPoste; }
            set { rematesPoste = value; }
        }

        public int FuerasJuego
        {
            get { return fuerasJuego; }
            set { fuerasJuego = value; }
        }

        public int TarjetasAmarillasProvocadas
        {
            get { return tarjetasAmarillasProvocadas; }
            set { tarjetasAmarillasProvocadas = value; }
        }

        public int TarjetasRojasProvocadas
        {
            get { return tarjetasRojasProvocadas; }
            set { tarjetasRojasProvocadas = value; }
        }

        public int FaltasCometidas
        {
            get { return faltasCometidas; }
            set { faltasCometidas = value; }
        }

        public int FaltasRecibidas
        {
            get { return faltasRecibidas; }
            set { faltasRecibidas = value; }
        }

        public int Corners
        {
            get { return corners; }
            set { corners = value; }
        }

        public int BalonesRecuperados
        {
            get { return balonesRecuperados; }
            set { balonesRecuperados = value; }
        }

        public int BalonesPerdidos
        {
            get { return balonesPerdidos; }
            set { balonesPerdidos = value; }
        }

        public int PenaltisCometidos
        {
            get { return penaltisCometidos; }
            set { penaltisCometidos = value; }
        }

        public int PenaltisRecibidos
        {
            get { return penaltisRecibidos; }
            set { penaltisRecibidos = value; }
        }


    }
}
