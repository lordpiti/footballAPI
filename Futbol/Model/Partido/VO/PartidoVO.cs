using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Partido.VO
{
    public class PartidoVO
    {
        private int cod_Partido;
        private int cod_Competicion;
        private String jornada;
        private int cod_Local;
        private int cod_Visitante;
        private DateTime fecha;
        private String clima;
        private int goles_Local;
        private int goles_Visitante;
        private float posesion_Local;
        private float posesion_Visitante;
        private int corners_Local;
        private int corners_Visitante;
        private int fuerasJuego_Local;
        private int fuerasJuego_Visitante;
        private int asistencia;
        private int cod_Arbitro;
        private int cod_Estadio;


        public PartidoVO(int cod_Partido, int cod_Competicion,String jornada,
        int cod_Local, int cod_Visitante, DateTime fecha, String clima,
        int goles_Local, int goles_Visitante, float posesion_Local,
        float posesion_Visitante, int corners_Local, int corners_Visitante,
        int fuerasJuego_Local, int fuerasJuego_Visitante, int asistencia,
        int cod_Arbitro, int cod_Estadio)
        
        
        
        {
            this.cod_Partido=cod_Partido;
            this.cod_Competicion=cod_Competicion;
            this.jornada=jornada;
            this.cod_Local=cod_Local;
            this.cod_Visitante=cod_Visitante;
            this.fecha=fecha;
            this.clima=clima;
            this.goles_Local=goles_Local;
            this.goles_Visitante=goles_Visitante;
            this.posesion_Local=posesion_Local;
            this.posesion_Visitante=posesion_Visitante;
            this.corners_Local=corners_Local;
            this.corners_Visitante=corners_Visitante;
            this.fuerasJuego_Local=fuerasJuego_Local;
            this.fuerasJuego_Visitante=fuerasJuego_Visitante;
            this.asistencia=asistencia;
            this.cod_Arbitro=cod_Arbitro;
            this.cod_Estadio=cod_Estadio;
        }



        public PartidoVO(int cod_Competicion, String jornada,
        int cod_Local, int cod_Visitante, DateTime fecha, String clima,
        int goles_Local, int goles_Visitante, float posesion_Local,
        float posesion_Visitante, int corners_Local, int corners_Visitante,
        int fuerasJuego_Local, int fuerasJuego_Visitante, int asistencia,
        int cod_Arbitro, int cod_Estadio)
        {
            this.cod_Competicion = cod_Competicion;
            this.jornada = jornada;
            this.cod_Local = cod_Local;
            this.cod_Visitante = cod_Visitante;
            this.fecha = fecha;
            this.clima = clima;
            this.goles_Local = goles_Local;
            this.goles_Visitante = goles_Visitante;
            this.posesion_Local = posesion_Local;
            this.posesion_Visitante = posesion_Visitante;
            this.corners_Local = corners_Local;
            this.corners_Visitante = corners_Visitante;
            this.fuerasJuego_Local = fuerasJuego_Local;
            this.fuerasJuego_Visitante = fuerasJuego_Visitante;
            this.asistencia = asistencia;
            this.cod_Arbitro = cod_Arbitro;
            this.cod_Estadio = cod_Estadio;
        }




        public int Cod_Partido
        {
            get { return cod_Partido; }
            set { cod_Partido = value; }
        }

        
        public int Cod_Competicion
        {
            get { return cod_Competicion; }
            set { cod_Competicion = value; }
        }


        public String Jornada
        {
            get { return jornada; }
            set { jornada = value; }
        }


        public int Cod_Local
        {
            get { return cod_Local; }
            set { cod_Local = value; }
        }


        public int Cod_Visitante
        {
            get { return cod_Visitante; }
            set { cod_Visitante = value; }
        }


        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public String Clima
        {
            get { return clima; }
            set { clima = value; }
        }


        public int Goles_Local
        {
            get { return goles_Local; }
            set { goles_Local = value; }
        }


        public int Goles_Visitante
        {
            get { return goles_Visitante; }
            set { goles_Visitante = value; }
        }


        public float Posesion_Local
        {
            get { return posesion_Local; }
            set { posesion_Local = value; }
        }


        public float Posesion_Visitante
        {
            get { return posesion_Visitante; }
            set { posesion_Visitante = value; }
        }


        public int Corners_Local
        {
            get { return corners_Local; }
            set { corners_Local = value; }
        }


        public int Corners_Visitante
        {
            get { return corners_Visitante; }
            set { corners_Visitante = value; }
        }


        public int FuerasJuego_Local
        {
            get { return fuerasJuego_Local; }
            set { fuerasJuego_Local = value; }
        }


        public int FuerasJuego_Visitante
        {
            get { return fuerasJuego_Visitante; }
            set { fuerasJuego_Visitante = value; }
        }


        public int Asistencia
        {
            get { return asistencia; }
            set { asistencia = value; }
        }


        public int Cod_Arbitro
        {
            get { return cod_Arbitro; }
            set { cod_Arbitro = value; }
        }


        public int Cod_Estadio
        {
            get { return cod_Estadio; }
            set { cod_Estadio = value; }
        }


        public String toString()
        {
            return (Cod_Partido.ToString() + " ");

        }
    }
}
