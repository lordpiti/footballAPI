using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Directivo
{
    public class DirectivoPlantillaCO
    {
        private int cod_Directivo;
        private String nombre;
        private String apellidos;
        private String cargo;
        private DateTime fecha_Nacimiento;
        private String foto;


        public DirectivoPlantillaCO(int cod_Directivo, String nombre, String apellidos, DateTime fecha_Nacimiento, String cargo, String foto)
        {
            this.cod_Directivo=cod_Directivo;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fecha_Nacimiento = fecha_Nacimiento;
            this.foto=foto;
            this.cargo = cargo;
        }



        public int Cod_Directivo
        {
            get { return cod_Directivo; }
            set { cod_Directivo = value; }

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


        public String toString()
        {
            return (Cod_Directivo.ToString() + " " + nombre + " " + apellidos + " " + Fecha_Nacimiento.ToString());

        }



    }

    


}
