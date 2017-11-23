using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Directivo.VO
{
    public class DirectivoVO
    {
        private int cod_Entrenador;
        private int cod_Integrante;
        private int cod_Equipo;
        private int version_Integrante;
        private String cargo;
        private String profesion;


        public DirectivoVO(int cod_Entrenador,int cod_Integrante, int cod_Equipo, int version_Integrante,
            String cargo, String profesion)
        {
            this.cod_Integrante = cod_Integrante;
            this.version_Integrante=version_Integrante;
            this.cargo=cargo;
            this.cod_Equipo=cod_Equipo;
            this.cod_Entrenador=cod_Entrenador;
            this.profesion=profesion;
        }

        public DirectivoVO(int cod_Integrante, int cod_Equipo, int version_Integrante,
            String cargo, String profesion)
        {
            this.cod_Integrante = cod_Integrante;
            this.version_Integrante = version_Integrante;
            this.cargo = cargo;
            this.cod_Equipo = cod_Equipo;
            this.profesion=profesion;          
        }


        public DirectivoVO(int cod_Integrante, int cod_Equipo, String cargo, String profesion)
        {
            this.cod_Integrante = cod_Integrante;
            this.cargo = cargo;
            this.cod_Equipo = cod_Equipo;
            this.profesion = profesion;
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


        public String Profesion
        {
            get { return profesion; }
            set { profesion = value; }
        }


        public String toString()
        {
            return null;
        }

    }

}
