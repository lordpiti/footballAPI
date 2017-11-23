using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Competicion.VO
{
    public class CompeticionVO
    {
        private int cd_Competicion;
        private String nombre;
        private String temporada;
        private DateTime fecha_Inicio;
        private DateTime fecha_Fin;
        private String campeon;
        private String foto;
        private String tipo;

        public CompeticionVO(int cd_Competicion, String nombre, String temporada, 
            DateTime fecha_Inicio, DateTime fecha_Fin, String campeon,String foto,String tipo)
        {
            this.cd_Competicion=cd_Competicion;
            this.nombre=nombre;
            this.temporada=temporada;
            this.fecha_Inicio=fecha_Inicio;
            this.fecha_Fin=fecha_Fin;
            this.campeon=campeon;
            this.foto = foto;
            this.tipo = tipo;

        }


        public CompeticionVO(String nombre, String temporada, DateTime fecha_Inicio,
            DateTime fecha_Fin, String campeon, String foto, String tipo)
        {
            
            this.nombre = nombre;
            this.temporada = temporada;
            this.fecha_Inicio = fecha_Inicio;
            this.fecha_Fin = fecha_Fin;
            this.campeon = campeon;
            this.foto = foto;
            this.tipo = tipo;

        }


        public int Cd_Competicion
        {
            get { return cd_Competicion; }
            set { cd_Competicion = value; }

        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Temporada
        {
            get { return temporada; }
            set { temporada = value; }

        }

        public DateTime Fecha_Inicio
        {
            get { return fecha_Inicio; }
            set { fecha_Inicio = value; }

        }

        public DateTime Fecha_Fin
        {
            get { return fecha_Fin; }
            set { fecha_Fin = value; }
        }



        public String Campeon
        {
            get { return campeon; }
            set { campeon = value; }
        }


        public String Foto
        {
            get { return foto; }
            set { foto = value; }
        }


        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public String toString()
        {
            return (cd_Competicion.ToString() + " " + nombre.ToString() + " " + campeon + " ");
        }
    }
}
