using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Clasificacion.VO
{
    public class ClasificacionVO
    {
        private int cod_Competicion;
        private int cod_Equipo;
        private int jornada;
        private int posicion;
        private int ganados;
        private int perdidos;
        private int empatados;
        private int goles_Favor;
        private int goles_Contra;
        private int puntos;


        public ClasificacionVO(int cod_Competicion,int jornada, int cod_Equipo,int posicion,
            int ganados, int perdidos, int empatados,int goles_Favor, int goles_Contra, int puntos)
        {
            this.cod_Competicion=cod_Competicion;
            this.cod_Equipo=cod_Equipo;
            this.posicion=posicion;
            this.ganados = ganados;
            this.perdidos = perdidos;
            this.empatados = empatados;
            this.jornada = jornada;
            this.goles_Favor=goles_Favor;
            this.goles_Contra=goles_Contra;
            this.puntos=puntos;
        }



        public int Cod_Competicion
        {
            get { return cod_Competicion; }
            set { cod_Competicion = value; }
        }

        public int Cod_Equipo
        {
            get { return cod_Equipo; }
            set { cod_Equipo = value; }
        }

        public int Ganados
        {
            get { return ganados; }
            set { ganados = value; }
        }

        public int Perdidos
        {
            get { return perdidos; }
            set { perdidos = value; }
        }

        public int Empatados
        {
            get { return empatados; }
            set { empatados = value; }
        }

        public int Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }

        public int goal_Average()
        {
            return (goles_Favor-goles_Contra);
        }

        public int Jornada
        {
            get { return jornada; }
            set { jornada = value; }
        }

        public int Goles_Favor
        {
            get { return goles_Favor; }
            set { goles_Favor = value; }
        }

        public int Goles_Contra
        {
            get { return goles_Contra; }
            set { goles_Contra = value; }
        }


        public String toString()
        {
            return ("Competicion: "+cod_Competicion.ToString()+" | Cod equipo: "+cod_Equipo.ToString()+
                " posicion: "+posicion.ToString());
        }
    }
}
