using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Entrenador.VO
{
    public class EntrenadorVO
    {
        private int cod_Entrenador;
        private int cod_Integrante;
        private int cod_Equipo;
        private int version_Integrante;
        private String cargo;
        private DateTime fechaProfesional;


        public EntrenadorVO(int cod_Entrenador,int cod_Integrante, int cod_Equipo, int version_Integrante,
            String cargo, DateTime fechaProfesional)
        {
            this.cod_Integrante = cod_Integrante;
            this.version_Integrante=version_Integrante;
            this.cargo=cargo;
            this.cod_Equipo=cod_Equipo;
            this.cod_Entrenador=cod_Entrenador;
            this.fechaProfesional = fechaProfesional;
        }

        public EntrenadorVO(int cod_Integrante, int cod_Equipo, int version_Integrante,
            String cargo, DateTime fechaProfesional)
        {
            this.cod_Integrante = cod_Integrante;
            this.version_Integrante = version_Integrante;
            this.cargo = cargo;
            this.cod_Equipo = cod_Equipo;
            this.fechaProfesional = fechaProfesional;          
        }


        public EntrenadorVO(int cod_Integrante, int cod_Equipo, String cargo, DateTime fechaProfesional)
        {
            this.cod_Integrante = cod_Integrante;
            this.cargo = cargo;
            this.cod_Equipo = cod_Equipo;
            this.fechaProfesional = fechaProfesional;
        }



        public int Cod_Integrante
        {
            get { return cod_Integrante; }
            set { cod_Integrante = value; }
        }


        public int Cod_Equipo
        {
            get { return cod_Equipo; }
            set { cod_Equipo = value; }
        }


        public int Version_Integrante
        {
            get { return version_Integrante; }
            set { version_Integrante = value; }
        }


        public int Cod_Entrenador
        {
            get { return cod_Entrenador; }
            set { cod_Entrenador = value; }
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


        public String toString()
        {
            return null;
        }

    }

}
