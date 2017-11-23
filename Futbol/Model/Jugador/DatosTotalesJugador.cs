using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Futbol.Model.Jugador
{
    public class DatosTotalesJugador
    {
        private String nombre;
        private String apellidos;
        private DateTime fecha_Nacimiento;
        private float altura;
        private String foto;
        private String posicion;
        private String pierna;
        private DateTime fecha_Fin_Contrato;
        private int sueldo;


        public DatosTotalesJugador(String nombre, String apellidos, DateTime fecha_Nacimiento, float altura, String foto,
            String posicion, String pierna,int sueldo,DateTime fecha_Fin_Contrato )
        {

            this.nombre=nombre;
            this.apellidos=apellidos;
            this.fecha_Nacimiento=fecha_Nacimiento;
            this.altura=altura;
            this.foto=foto;
            this.posicion=posicion;
            this.pierna=pierna;
            this.fecha_Fin_Contrato = fecha_Fin_Contrato;
            this.sueldo = sueldo;
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


        public float Altura
        {
            get { return altura; }
            set { altura = value; }

        }

        public String Pierna
        {
            get { return pierna; }
            set { pierna = value; }

        }



        public int Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }

        }

        public DateTime Fecha_Fin_Contrato
        {
            get { return fecha_Fin_Contrato; }
            set { fecha_Fin_Contrato = value; }

        }

    }
}
