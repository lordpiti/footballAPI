using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util;
using Futbol.Model.Integrante.VO;
using Futbol.Model.HcoIntegrante.VO;
using Futbol.Model.Jugador.VO;
using Futbol.Model.Entrenador.VO;
using Futbol.Model.Directivo.VO;
using Futbol.Model.FachadaAdmin.COs;
using Futbol;
using Util.Log;

namespace Simulador
{
    public class GeneradorJugadores
    {
        private GeneradorCosas generador=new GeneradorCosas();
        private static int contador=1;


        public ArrayList generaPlantilla(int cod_Equipo){
            contador = (cod_Equipo -1)*22;
            String posicion;
            ArrayList listaJugadores = new ArrayList();
            for(int i=1;i<23;i++){

            switch (i)
            {
                case 1:
                    posicion="Portero";
                    break;
                case 2:
                    posicion="Lateral derecho";
                    break;
                case 3:
                    posicion="Lateral izquierdo";
                    break;
                case 4:
                    posicion = "Defensa central";
                    break;
                case 5:
                    posicion = "Defensa central";
                    break;
                case 6:
                    posicion = "Mediocentro defensivo";
                    break;
                case 7:
                    posicion = "Interior derecho";
                    break;
                case 8:
                    posicion = "Mediocentro ofensivo";
                    break;
                case 9:
                    posicion = "Delantero centro";
                    break;
                case 10:
                    posicion = "Mediapunta";
                    break;
                case 11:
                    posicion = "Extremo izquierdo";
                    break;
                case 12:
                    posicion = "Lateral derecho";
                    break;
                case 13:
                    posicion = "Portero";
                    break;
                case 14:
                    posicion = "Lateral izquierdo";
                    break;
                case 15:
                    posicion = "Defensa central";
                    break;
                case 16:
                    posicion = "Defensa central";
                    break;
                case 17:
                    posicion = "Delantero centro";
                    break;
                case 18:
                    posicion = "Extremo derecho";
                    break;
                case 19:
                    posicion = "Delantero";
                    break;
                case 20:
                    posicion = "Mediocentro defensivo";
                    break;
                case 21:
                    posicion = "Mediocentro ofensivo";
                    break;
                case 22:
                    posicion = "Mediapunta";
                    break;

                default:
                    posicion = "Polivalente";
                    break;
            }

                
                
                IntegranteVO integranteVO=new IntegranteVO(contador+i,generador.generarNombreAleatorio(),generador.generarApellidoAleatorio(),
                    generador.generarFechaAleatoriaNacimiento(),null);

                HcoIntegranteVO hcoIntegranteVO = new HcoIntegranteVO(contador+i, cod_Equipo,
                    generador.generarFechaAleatoriaPartido(),DateTime.MinValue, generador.generarFechaAleatoriaPartido(),
                    20000,i);

                ArrayList listaHcoIntegrantes = new ArrayList();
                listaHcoIntegrantes.Add(hcoIntegranteVO);

                JugadorVO jugadorVO = new JugadorVO(contador+i, cod_Equipo, generador.generarAltura(), posicion, generador.generarZurdoDiestro());

                JugadorCO jugadorInsertar=new JugadorCO(jugadorVO, listaHcoIntegrantes, integranteVO);

                listaJugadores.Add(jugadorInsertar);

                

            }
            return listaJugadores;
        }




        public ArrayList generaCuerpoTécnico(int cod_Equipo)
        {
            //sustituir el 4 q multiplica al 22 de abajo por el numero de equipos
            //de la BD
            contador = 22*20+(cod_Equipo - 1) * 4;
            ArrayList listaEntrenadores = new ArrayList();
            String cargo;
            for (int i = 1; i < 5; i++)
            {

                switch (i)
                {
                    case 1:
                        cargo = "Primer entrenador";
                        break;
                    case 2:
                        cargo = "Segundo entrenador";
                        break;
                    case 3:
                        cargo = "Entrenador de porteros";
                        break;
                    case 4:
                        cargo = "Ayudante";
                        break;
                    default:
                        cargo = "Utillero";
                        break;
                }



                IntegranteVO integranteVO = new IntegranteVO(contador + i, generador.generarNombreAleatorio(), generador.generarApellidoAleatorio(),
                    generador.generarFechaAleatoriaNacimiento(), null);

                HcoIntegranteVO hcoIntegranteVO = new HcoIntegranteVO(contador + i, cod_Equipo,
                    generador.generarFechaAleatoriaPartido(), DateTime.MinValue, generador.generarFechaAleatoriaPartido(),
                    20000, i);

                ArrayList listaHcoIntegrantes = new ArrayList();
                listaHcoIntegrantes.Add(hcoIntegranteVO);

                EntrenadorVO entrenadorVO = new EntrenadorVO(contador + i, cod_Equipo, cargo, generador.generarFechaAleatoriaPartido());

                EntrenadorCO entrenadorInsertar = new EntrenadorCO(entrenadorVO, listaHcoIntegrantes, integranteVO);

                listaEntrenadores.Add(entrenadorInsertar);



            }
            return listaEntrenadores;
        }




        public ArrayList generaDirectiva(int cod_Equipo)
        {
            //sustituir el 4 q multiplica al 22 de abajo por el numero de equipos
            //de la BD
            contador = 22 * 20+20*4 + (cod_Equipo - 1) * 4;
            ArrayList listaDirectivos = new ArrayList();
            String cargo;
            for (int i = 1; i < 5; i++)
            {

                switch (i)
                {
                    case 1:
                        cargo = "Presidente";
                        break;
                    case 2:
                        cargo = "Vicepresidente";
                        break;
                    case 3:
                        cargo = "Director deportivo";
                        break;
                    case 4:
                        cargo = "Secretario general";
                        break;
                    default:
                        cargo = "Consejero";
                        break;
                }



                IntegranteVO integranteVO = new IntegranteVO(contador + i, generador.generarNombreAleatorio(), generador.generarApellidoAleatorio(),
                    generador.generarFechaAleatoriaNacimiento(), null);

                HcoIntegranteVO hcoIntegranteVO = new HcoIntegranteVO(contador + i, cod_Equipo,
                    generador.generarFechaAleatoriaPartido(), DateTime.MinValue, generador.generarFechaAleatoriaPartido(),
                    20000, i);

                ArrayList listaHcoIntegrantes = new ArrayList();
                listaHcoIntegrantes.Add(hcoIntegranteVO);

                DirectivoVO directivoVO = new DirectivoVO(contador + i, cod_Equipo, cargo,"abogao");

                DirectivoCO directivoInsertar = new DirectivoCO(directivoVO, listaHcoIntegrantes, integranteVO);

                listaDirectivos.Add(directivoInsertar);

            }
            return listaDirectivos;
        }



    }
}
