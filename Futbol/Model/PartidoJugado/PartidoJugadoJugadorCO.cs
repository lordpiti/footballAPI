using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.PartidoJugado
{
    public class PartidoJugadoJugadorCO
    {
        private String nombreCompeticion;
        private String temporada;
        private String jornada;
        private String nombreLocal;
        private String nombreVisitante;
        private String titular;
        private int cod_Partido;
        private int minutos;
        private int faltas;
        private int goles;
        private int tarjetas;



        public PartidoJugadoJugadorCO(int cod_Partido,String nombreCompeticion, String temporada,
            String jornada, String nombreLocal, String nombreVisitante, String titular,
            int minutos, int faltas, int goles, int tarjetas)
        {
            this.nombreCompeticion = nombreCompeticion;
            this.temporada = temporada;
            this.jornada = jornada;
            this.nombreLocal = nombreLocal;
            this.nombreVisitante = nombreVisitante;
            this.titular = titular;
            this.minutos = minutos;
            this.faltas = faltas;
            this.goles = goles;
            this.tarjetas = tarjetas;
            this.cod_Partido = cod_Partido;
        }


        public String NombreCompeticion
        {
            get { return nombreCompeticion; }
            set { nombreCompeticion = value; }
        }

        public String Temporada
        {
            get { return temporada; }
            set { temporada = value; }
        }

        public String Jornada
        {
            get { return jornada; }
            set { jornada = value; }
        }

        public String NombreLocal
        {
            get { return nombreLocal; }
            set { nombreLocal = value; }
        }

        public String NombreVisitante
        {
            get { return nombreVisitante; }
            set { nombreVisitante = value; }
        }

        public String Titular
        {
            get { return titular; }
            set { titular = value; }
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

        public int Goles
        {
            get { return goles; }
            set { goles = value; }
        }

        public int Tarjetas
        {
            get { return tarjetas; }
            set { tarjetas = value; }
        }

        public int Cod_Partido
        {
            get { return cod_Partido; }
            set { cod_Partido = value; }
        }

        public String toString()
        {
            return ("Competicion: " + nombreCompeticion + " | Temporada: " + temporada +
                " | Jornada: " + jornada + " | Equipo local: " + nombreLocal +
                " | Equipo visitante: " + nombreVisitante + " | Titular: " + titular +
                " | Minutos: " + minutos + " | Faltas: " + faltas + " | Goles: " + goles +
                " | Tarjetas: " + tarjetas);

        }


    }
}