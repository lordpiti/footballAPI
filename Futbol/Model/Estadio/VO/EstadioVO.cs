using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Estadio.VO
{
    public class EstadioVO
    {
        private int cd_Estadio;
        private String nombre;
        private int capacidad;
        private String direccion;
        private String tipo;
        private String foto;

        public EstadioVO(int cd_Estadio,String nombre, int capacidad, String direccion, String tipo, String foto)
        {
            this.cd_Estadio=cd_Estadio;
            this.capacidad = capacidad;
            this.direccion = direccion;
            this.tipo = tipo;
            this.foto = foto;
            this.nombre = nombre;

        }


        public EstadioVO(String nombre,int capacidad, String direccion, String tipo, String foto)
        {          
            this.capacidad = capacidad;
            this.direccion = direccion;
            this.tipo = tipo;
            this.foto = foto;
            this.nombre = nombre;
            

        }


        public int Cd_Estadio
        {
            get { return cd_Estadio; }
            set { cd_Estadio = value; }

        }


        public String Nombre
        {
            get { return nombre ; }
            set { nombre = value; }

        }


        public int Capacidad
        {
            get { return capacidad; }
            set { capacidad = value; }

        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }

        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }

        }

        public String Foto
        {
            get { return foto; }
            set { foto = value; }

        }

        public String toString()
        {
            return (cd_Estadio.ToString() + " " + capacidad.ToString() + " " + direccion + " " + tipo + " " + foto);
        }
    }
}
