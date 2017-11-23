using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Partido
{
    public class PartidoCompeticionJornadaCO
    {
        private int cod_Partido;
        private String nombreLocal;
        private String nombreVisitante;
        private int golesLocal;
        private int golesVisitante;
        private String temporada;
        private String nombreCompeticion;
        private int cod_Competicion;
        private String jornada;




        public PartidoCompeticionJornadaCO(int cod_Partido, String nombreLocal,
            String nombreVisitante,int golesLocal,int golesVisitante,String temporada,
            String nombreCompeticion,int cod_Competicion,String jornada)
        {
            this.cod_Partido = cod_Partido;
            this.nombreLocal = nombreLocal;
            this.nombreVisitante = nombreVisitante;
            this.golesLocal = golesLocal;
            this.golesVisitante = golesVisitante;
            this.temporada = temporada;
            this.cod_Competicion = cod_Competicion;
            this.nombreCompeticion = nombreCompeticion;
            this.jornada = jornada;
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


        public int Cod_Partido
        {
            get { return cod_Partido; }
            set { cod_Partido = value; }
        }


        public int GolesLocal
        {
            get { return golesLocal; }
            set { golesLocal = value; }
        }


        public int GolesVisitante
        {
            get { return golesVisitante; }
            set { golesVisitante = value; }
        }

        public String Temporada
        {
            get { return temporada; }
            set { temporada = value; }
        }

        public String NombreCompeticion
        {
            get { return nombreCompeticion; }
            set { nombreCompeticion = value; }
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

    }
}
