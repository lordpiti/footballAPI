using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.FachadaPartidos.COs
{
    public class CompeticionConNombreCO
    {
        private String nombre;
        private String jornada;
        private int cod_Competicion;
        private String tipo;
        private String temporada;
        private String foto;


        public CompeticionConNombreCO(int cod_Competicion, String nombre,String tipo,
            String jornada, String temporada, String foto)
        {
            this.nombre = nombre;
            this.jornada = jornada;
            this.cod_Competicion = cod_Competicion;
            this.tipo = tipo;
            this.temporada = temporada;
            this.foto = foto;
        }


        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Jornada
        {
            get { return jornada; }
            set { jornada = value; }
        }


        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }


        public String Temporada
        {
            get { return temporada; }
            set { temporada = value; }
        }


        public String Foto
        {
            get { return foto; }
            set { foto = value; }
        }


        public int Cod_Competicion
        {
            get { return cod_Competicion; }
            set { cod_Competicion = value; }
        }


    }
}
