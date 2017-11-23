using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.HcoIntegrante.VO
{
    public class HcoIntegranteVO
    {
        private int cod_Integrante;
        private int cod_Equipo;
        private int version_Integrante;
        private DateTime fecha_Inicio;
        private DateTime fecha_Fin;
        private DateTime fecha_Fin_Contrato;
        private int sueldo;
        private int dorsal;


        public HcoIntegranteVO(int cod_Integrante, int cod_Equipo, int version_Integrante,
            DateTime fecha_Inicio, DateTime fecha_Fin, DateTime fecha_Fin_Contrato, int sueldo,int dorsal)
        {
            this.cod_Integrante = cod_Integrante;
            this.cod_Equipo=cod_Equipo;
            this.version_Integrante=version_Integrante;
            this.fecha_Inicio=fecha_Inicio;
            this.fecha_Fin=fecha_Fin;
            this.fecha_Fin_Contrato=fecha_Fin_Contrato;
            this.sueldo=sueldo;
            this.dorsal = dorsal;
        }

        public HcoIntegranteVO(int cod_Integrante, int cod_Equipo,
            DateTime fecha_Inicio, DateTime fecha_Fin, DateTime fecha_Fin_Contrato, int sueldo,int dorsal)
        {
            this.cod_Integrante = cod_Integrante;
            this.cod_Equipo = cod_Equipo;
            this.fecha_Inicio = fecha_Inicio;
            this.fecha_Fin = fecha_Fin;
            this.fecha_Fin_Contrato = fecha_Fin_Contrato;
            this.sueldo = sueldo;
            this.dorsal = dorsal;
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


        public DateTime Fecha_Inicio
        {
            get { return fecha_Inicio; }
            set { fecha_Inicio = value; }
        }


        public DateTime Fecha_Fin
        {
            get { return fecha_Fin; }
            set { fecha_Fin = value; }
        }


        public DateTime Fecha_Fin_Contrato
        {
            get { return fecha_Fin_Contrato; }
            set { fecha_Fin_Contrato = value; }
        }


        public int Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }



        public int Dorsal
        {
            get { return dorsal; }
            set { dorsal = value; }
        }


        public String toString()
        {
            return ("");

        }



    }

    


}
