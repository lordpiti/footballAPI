using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Jugador
{
    public class JugadorPlantillaCO
    {
        private int cod_Jugador;
        private String nombre;
        private String apellidos;
        private String posicion;
        private DateTime fecha_Nacimiento;
        private String foto;
        private Int32 cod_Integrante;
        private Int32 dorsal;




        public JugadorPlantillaCO(int cod_Jugador, String nombre, String apellidos, DateTime fecha_Nacimiento, 
            String posicion, String foto,Int32 cod_Integrante,Int32 dorsal)
        {
            this.cod_Jugador=cod_Jugador;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fecha_Nacimiento = fecha_Nacimiento;
            this.foto=foto;
            this.posicion=posicion;
            this.cod_Integrante = cod_Integrante;
            this.dorsal = dorsal;
        }



        public int Cod_Jugador
        {
            get { return cod_Jugador; }
            set { cod_Jugador = value; }

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

        public String Posicion
        {
            get { return posicion; }
            set { posicion = value; }

        }

        public Int32 Dorsal
        {
            get { return dorsal; }
            set { dorsal = value; }
        }


        public String toString()
        {
            return (Cod_Jugador.ToString() + " " + nombre + " " + apellidos + " " + Fecha_Nacimiento.ToString());

        }



    }

    


}
