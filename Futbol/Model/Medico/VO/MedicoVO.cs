using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Medico.VO
{
    public class MedicoVO
    {
        private int cod_Medico;
        private int cod_Integrante;
        private int cod_Equipo;
        private int version_Integrante;
        private String especialidad;
        private DateTime fecha_Profesional;


        public MedicoVO(int cod_Medico,int cod_Integrante, int cod_Equipo, int version_Integrante,
            String especialidad, DateTime fecha_Profesional)
        {
            this.cod_Integrante = cod_Integrante;
            this.version_Integrante=version_Integrante;
            this.fecha_Profesional=fecha_Profesional;
            this.especialidad=especialidad;
            this.cod_Equipo=cod_Equipo;
            this.cod_Medico=cod_Medico;
        }

        public MedicoVO(int cod_Integrante, int cod_Equipo, int version_Integrante,
            String especialidad, DateTime fecha_Profesional)
        {
            this.cod_Integrante = cod_Integrante;
            this.version_Integrante = version_Integrante;
            this.fecha_Profesional = fecha_Profesional;
            this.especialidad = especialidad;
            this.cod_Equipo = cod_Equipo;       
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

        public int Cod_Medico
        {
            get { return cod_Medico; }
            set { cod_Medico = value; }
        }


        public String Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }


        public DateTime Fecha_Profesional
        {
            get { return fecha_Profesional; }
            set { fecha_Profesional = value; }
        }


        public String toString()
        {
            return null;
        }
    }
}