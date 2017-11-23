using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Integrante.VO
{
    public class IntegranteVO
    {
        private int cod_Integrante;
        private String nombre;
        private String apellidos;
        private DateTime fecha_Nacimiento;
        private String foto;


        public IntegranteVO(int cod_Integrante, String nombre, String apellidos, DateTime fecha_Nacimiento, String foto)
        {
            this.cod_Integrante = cod_Integrante;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fecha_Nacimiento = fecha_Nacimiento;
            this.foto=foto;
        }

        public IntegranteVO(String nombre, String apellidos, DateTime fecha_Nacimiento, String foto)
        {
           
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fecha_Nacimiento = fecha_Nacimiento;
            this.foto = foto;
        }


        public int Cod_Integrante
        {
            get { return cod_Integrante; }
            set { cod_Integrante = value; }

        }


        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }


        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }

        }

        public DateTime Fecha_Nacimiento
        {
            get { return fecha_Nacimiento; }
            set { fecha_Nacimiento = value; }

        }

        public String Foto
        {
            get { return foto; }
            set { foto = value; }

        }


        public String toString()
        {
            return (Cod_Integrante.ToString() + " " + nombre + " " + apellidos + " " + Fecha_Nacimiento.ToString());

        }



    }

    


}
