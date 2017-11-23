using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Futbol.Model.Calendario.VO;

namespace Futbol.Model.Calendario
{
    public class CalendarioCO
    {
        private String nombreLocal;
        private String nombreVisitante;
        private String nombreCompeticion;
        private String jornada;
        private DateTime fecha; 



        public CalendarioCO(String nombreLocal, String nombreVisitante,
            String nombreCompeticion, String jornada, DateTime fecha)
        {
            this.nombreLocal = nombreLocal;
            this.nombreVisitante = nombreVisitante;
            this.nombreCompeticion = nombreCompeticion;
            this.jornada = jornada;
            this.fecha = fecha;
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


        public String NombreCompeticion
        {
            get { return nombreCompeticion; }
            set { nombreCompeticion = value; }
        }


        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public String Jornada
        {
            get { return jornada; }
            set { jornada= value; }
        }

    }
}