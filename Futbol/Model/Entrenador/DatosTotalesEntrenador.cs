using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Futbol.Model.Entrenador
{
    public class DatosTotalesEntrenador
    {
        private String nombre;
        private String apellidos;
        private DateTime fecha_Nacimiento;
        private String foto;
        private String cargo;
        private DateTime fechaProfesional;
        private DateTime fecha_Fin_Contrato;
        private int sueldo;


        public DatosTotalesEntrenador(String nombre, String apellidos, DateTime fecha_Nacimiento, String foto,
            String cargo,DateTime fechaProfesional,int sueldo,DateTime fecha_Fin_Contrato )
        {

            this.nombre=nombre;
            this.apellidos=apellidos;
            this.fecha_Nacimiento=fecha_Nacimiento;
            this.foto=foto;
            this.cargo = cargo;
            this.fecha_Fin_Contrato = fecha_Fin_Contrato;
            this.fechaProfesional = fechaProfesional;
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


        public String Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }




        public DateTime FechaProfesional
        {
            get { return fechaProfesional; }
            set { fechaProfesional = value; }
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
