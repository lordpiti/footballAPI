using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol.Model.Jugador.VO
{
    public class JugadorVO
    {
        private int cod_Jugador;
        private int cod_Integrante;
        private int cod_Equipo;
        private int version_Integrante;
        private float altura;
        private String posicion;
        private String pierna;


        public JugadorVO(int cod_Jugador,int cod_Integrante, int cod_Equipo, int version_Integrante,
            float altura, String posicion, String pierna)
        {
            this.cod_Integrante = cod_Integrante;
            this.altura=altura;
            this.version_Integrante=version_Integrante;
            this.posicion=posicion;
            this.pierna=pierna;
            this.cod_Equipo=cod_Equipo;
            this.cod_Jugador=cod_Jugador;
        }

        public JugadorVO(int cod_Integrante, int cod_Equipo, int version_Integrante,
            float altura, String posicion, String pierna)
        {
            this.cod_Integrante = cod_Integrante;
            this.altura = altura;
            this.version_Integrante = version_Integrante;
            this.posicion = posicion;
            this.pierna = pierna;
            this.cod_Equipo = cod_Equipo;
            
        }


        public JugadorVO(int cod_Integrante, int cod_Equipo, float altura, String posicion, String pierna)
        {
            this.cod_Integrante = cod_Integrante;
            this.altura = altura;
            this.posicion = posicion;
            this.pierna = pierna;
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

        public int Cod_Jugador
        {
            get { return cod_Jugador; }
            set { cod_Jugador = value; }

        }


        public float Altura
        {
            get { return altura; }
            set { altura = value; }

        }


        public String Posicion
        {
            get { return posicion; }
            set { posicion = value; }

        }


        public String Pierna
        {
            get { return pierna; }
            set { pierna = value; }

        }


        public String toString()
        {
            return null;


        }



    }

    


}
