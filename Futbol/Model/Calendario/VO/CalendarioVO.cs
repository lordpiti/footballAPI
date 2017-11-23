using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Calendario.VO
{
    public class CalendarioVO
    {
        private int cod_Calendario;
        private int cod_Competicion;
        private String jornada;
        private int cod_Local;
        private int cod_Visitante;
        private DateTime fecha;
        

        public CalendarioVO(int cod_Calendario, int cod_Competicion,String jornada,
        int cod_Local, int cod_Visitante, DateTime fecha)

        {
            this.cod_Calendario=cod_Calendario;
            this.cod_Competicion=cod_Competicion;
            this.jornada=jornada;
            this.cod_Local=cod_Local;
            this.cod_Visitante=cod_Visitante;
            this.fecha=fecha;
        }



        public CalendarioVO(int cod_Competicion, String jornada,
        int cod_Local, int cod_Visitante, DateTime fecha)
        {
            this.cod_Competicion = cod_Competicion;
            this.jornada = jornada;
            this.cod_Local = cod_Local;
            this.cod_Visitante = cod_Visitante;
            this.fecha = fecha;
        }




        public int Cod_Calendario
        {
            get { return cod_Calendario; }
            set { cod_Calendario = value; }
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



        public String toString()
        {
            return (Cod_Calendario.ToString() + " ");

        }
    }
}
