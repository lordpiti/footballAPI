using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util;
using Futbol.Model.Partido;
using Futbol.Model.Partido.VO;
using Futbol.Model.PartidoJugado;
using Futbol.Model.PartidoJugado.VO;
using Futbol.Model.Calendario.VO;
using Futbol.Model.Calendario.DAO;
using Futbol.Model.Jugador.DAO;
using Futbol.Model.Jugador.VO;
using Futbol.Model.Equipo.DAO;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Gol.DAO;
using Futbol.Model.Gol.VO;
using Futbol.Model.Cambio.VO;
using Futbol.Model.Tarjeta.VO;
using Futbol.Model.Clasificacion.DAO;
using Futbol.Model.Clasificacion.VO;
using Futbol.Model.FachadaPartidos;
using Futbol.Model.FachadaDatos;
using Futbol;
using Util.Log;


namespace Simulador
{
    public class GeneradorPartidos
    {
        GeneradorCosas generador = new GeneradorCosas();
        FachadaDatos fachadaDatos = new FachadaDatos();
        FachadaPartidos fachada = new FachadaPartidos();
        Random rand = new Random();

        //genera un PartidoVO aleatorio
        public PartidoVO generarPartidoSimple(int codCompeticion,String jornada,
            int codLocal, int codVisitante,int codEstadio) 
        { 
            int posesionLocal=generador.generarPosesion();
            return (new PartidoVO(codCompeticion, jornada, codLocal, codVisitante, generador.generarFechaAleatoriaPartido(),
                generador.generarClima(), generador.generarGoles(), generador.generarGoles(),
                posesionLocal, 100 - posesionLocal, generador.generarGoles(), generador.generarGoles(),
                generador.generarGoles(), generador.generarGoles(), 1000, 1, codEstadio));      
        }


        //genera un PartidoJugadoVO aleatorio
        public PartidoJugadoVO generarPartidoJugadoSimple(int codJugador,String titular)
        { 
            return (new PartidoJugadoVO(codJugador,titular,generador.generarPosesion(),
                rand.Next(0,7),0,rand.Next(0,5),rand.Next(0,1),rand.Next(0,4),rand.Next(0,5),
                rand.Next(0,3),0,rand.Next(0,4),rand.Next(0,5),rand.Next(0,1),rand.Next(0,6),
                rand.Next(0,8),rand.Next(0,1),rand.Next(0,1)));
        }


        //genera el 11 titular aleatorio de un equipo
        public ArrayList generar11Titular(int codEquipo)
        {
            
            JugadorDAO jugadorDAO = JugadorDAOFactory.GetDAO();
            ArrayList plantilla = fachadaDatos.verListaJugadoresEquipo(codEquipo);

            return (generador.generaXAleatoriosLista(plantilla, 11));
        
        }







        /*genera un PartidoTotalCO con todos los datos de un partido
         * tanto el PartidoVO como la lista de GolVOs y PartidoJugadoVOs
         * de los jugadores que participan en el
         * */
        public PartidoTotalCO generarPartidoCompleto(int codCompeticion, String jornada, 
            int codLocal, int codVisitante)
        {
            

            PartidoVO partido = generarPartidoSimple(codCompeticion, jornada, codLocal, codVisitante,1);

            ArrayList jugadoresLocal = generar11Titular(codLocal);
            ArrayList jugadoresVisitante = generar11Titular(codVisitante);
            ArrayList listaPartidosJugados = new ArrayList();
            ArrayList golesLocal=new ArrayList();
            ArrayList golesVisitante = new ArrayList();

            
           
   

            //Se crean los partidosJugados para cada jugador del equipo local
            //titulares y suplentes
            int contador = 1;
            int numeroCambios = jugadoresLocal.Count - 11;
            foreach (JugadorVO item in jugadoresLocal) 
            {
                if (contador>11) listaPartidosJugados.Add(generarPartidoJugadoSimple(item.Cod_Jugador, "Suplente"));       
                else listaPartidosJugados.Add(generarPartidoJugadoSimple(item.Cod_Jugador, "Titular"));
                contador++;
            }


            //aqui se crean los cambios equipo local
            ArrayList cambiosLocal = new ArrayList();
            for (int i = 0; i < numeroCambios; i++)
            {
                CambioVO cambio=new CambioVO(((JugadorVO)jugadoresLocal[11 + i]).Cod_Jugador,
                    ((JugadorVO)jugadoresLocal[1 + i]).Cod_Jugador, rand.Next(0, 90));
                cambiosLocal.Add(cambio);
            }
        



            //Se crean los partidosJugados para cada jugador del equipo visitante
            //titulares y suplentes
            contador = 1;
            numeroCambios = jugadoresVisitante.Count - 11;
            foreach (JugadorVO item in jugadoresVisitante)
            {
                if (contador > 11) listaPartidosJugados.Add(generarPartidoJugadoSimple(item.Cod_Jugador, "Suplente"));
                else listaPartidosJugados.Add(generarPartidoJugadoSimple(item.Cod_Jugador, "Titular"));
                contador++;
            }

            //aqui se crean los cambios equipo visitante
            ArrayList cambiosVisitante = new ArrayList();
            for (int i = 0; i < numeroCambios; i++)
            {
                CambioVO cambio = new CambioVO(((JugadorVO)jugadoresVisitante[11 + i]).Cod_Jugador,
                    ((JugadorVO)jugadoresVisitante[1 + i]).Cod_Jugador, rand.Next(0, 90));
                cambiosVisitante.Add(cambio);
            }

            //aqui generamos las tarjetas del equipo local
            ArrayList tarjetasLocal = new ArrayList();
            int numeroTarjetas = rand.Next(0, 6);
            for (int i = 0; i < numeroTarjetas; i++)
            {
                TarjetaVO tarjeta = new TarjetaVO(((JugadorVO)jugadoresLocal[i]).Cod_Jugador,
                    rand.Next(0, 90), "Amarilla", "Juego violento");
                tarjetasLocal.Add(tarjeta);
            }

            //aqui generamos las tarjetas del equipo visitante
            ArrayList tarjetasVisitante = new ArrayList();
            numeroTarjetas = rand.Next(0, 6);
            for (int i = 0; i < numeroTarjetas; i++)
            {
                TarjetaVO tarjeta = new TarjetaVO(((JugadorVO)jugadoresVisitante[i]).Cod_Jugador,
                    rand.Next(0, 90), "Amarilla", "Juego violento");
                tarjetasVisitante.Add(tarjeta);
            }


            //generamos ahora los goles concretos del partido
            
            ArrayList goleadoresLocal=generador.generaGoleadoresLista(jugadoresLocal, partido.Goles_Local);
            ArrayList goleadoresVisitante = generador.generaGoleadoresLista(jugadoresVisitante, partido.Goles_Visitante);

            foreach (JugadorVO item in goleadoresLocal) { 
               golesLocal.Add(new GolVO(item.Cod_Jugador,generador.generarPosesion(),"Pie","http://www.youtube.com/v/fV5UGc9nBAc&hl=en&fs=1"));  
            }
            
            foreach (JugadorVO item in goleadoresVisitante) {
                golesVisitante.Add(new GolVO(item.Cod_Jugador, generador.generarPosesion(), "Cabeza", "http://www.youtube.com/v/fV5UGc9nBAc&hl=en&fs=1"));  
            }


            cambiosLocal.AddRange(cambiosVisitante);
            golesLocal.AddRange(golesVisitante);
            tarjetasLocal.AddRange(tarjetasVisitante);




            PartidoTotalCO partidoCompleto = new PartidoTotalCO(partido, listaPartidosJugados,
                golesLocal,cambiosLocal,tarjetasLocal);
            
            PartidoTotalCO partidoTotal=fachada.pruebaCrearPartidoTotal(partidoCompleto);
            
            return partidoTotal;
            
        }


        //genera una liga completa
        public void generarLigaCompleta(int cod_Competicion,int numeroEquipos)
        {
            ArrayList listaCodigosEquipos = new ArrayList();
            ArrayList clasificacion = new ArrayList();

            for (int i = 1; i <= numeroEquipos; i++) 
            {
                listaCodigosEquipos.Add(i);
                clasificacion.Add(new ClasificacionVO(cod_Competicion, 0, i, i,0,0,0, 0, 0, 0));
            }


            ArrayList calendario = generador.generaLiga(listaCodigosEquipos);

            int numeroJornada = 1;
            ArrayList listaCalendarioJornada=new ArrayList();

            foreach (ArrayList jornada in calendario)
            {
                foreach (Jornada part in jornada)
                {
                    CalendarioVO calendarioJornada = new CalendarioVO(cod_Competicion,
                        Convert.ToString(numeroJornada), (int)part.Local, (int)part.Visitante, 
                        generador.generarFechaAleatoriaPartido());
                    listaCalendarioJornada.Add(calendarioJornada);
                }
                //ojo con esta linea ...
                fachada.crearCalendarioCompeticionJornada(listaCalendarioJornada);
                listaCalendarioJornada.Clear();
                numeroJornada++;
            }



            numeroJornada = 1;
            PartidoTotalCO partido;
            

            foreach (ArrayList jornada in calendario)
            {
                foreach (Jornada part in jornada)
                {
                    partido=generarPartidoCompleto(cod_Competicion, Convert.ToString(numeroJornada), (int)part.Local, (int)part.Visitante);

                    //clasificaciones
                    clasificacion=fachada.actualizarClasificacionTrasPartido(numeroJornada, partido.Partido, clasificacion);
                
                }
                //ojo con esta linea ...
                fachada.crearClasificacionJornada(clasificacion);
                numeroJornada++;
            }

        }


        //genera una copa completa con todos los partidos y rondas
        public void generarCopaCompleta(int cod_Competicion,int numeroEquipos)
        {
            ArrayList listaCodigosEquipos = new ArrayList();
            ArrayList rondaActual = new ArrayList();
            ArrayList auxiliar=new ArrayList();
            PartidoTotalCO partido;
            String nombreRonda="Fase Previa";

            for (int i = 1; i <=numeroEquipos; i++)
            {
                listaCodigosEquipos.Add(i);
            }


            /*simula el sistema de eliminatorias de copa hasta que haya un campeon
            generando los partidos de todas las rondas */

            while (listaCodigosEquipos.Count > 1)
            {
                rondaActual = generador.generarRondaCopa(listaCodigosEquipos);

                //obtenemos el nombre de la ronda actual, en funcion del numero de equipos
                nombreRonda=generador.obtenerNombreRondaCopa(listaCodigosEquipos.Count);
                

                
                //genera los partidos de la ronda de copa actual
                
                foreach (Jornada item in rondaActual)
                {
                    auxiliar.Add(item.Local);
                    auxiliar.Add(item.Visitante);
                    partido=generarPartidoCompleto(cod_Competicion, nombreRonda, (int)item.Local, (int)item.Visitante);
                    int ganador = (int)auxiliar[rand.Next(0, 2)];
                    auxiliar.Clear();
                    listaCodigosEquipos.Remove(ganador);
                }


            }

        }



        //Dado un calendario de jornadas de liga, genera una lista de CalendarioVOs
        public ArrayList generaListaCalendarioVOsLiga(ArrayList calendario)
        {

            int numeroJornada = 1;
            ArrayList listaCalendario = new ArrayList();

            foreach (ArrayList jornada in calendario)
            {
                foreach (Jornada part in jornada)
                {
                    CalendarioVO calendarioJornada = new CalendarioVO(1,Convert.ToString(numeroJornada),
                        (int)part.Local, (int)part.Visitante,generador.generarFechaAleatoriaPartido());
                    listaCalendario.Add(calendarioJornada);
                }
                //ojo con esta linea ...
                numeroJornada++;
            }

            return listaCalendario;

        }

        /*Dada una lista de CalendarioVOs y una competicion de liga, simula los partidos de
        la liga , actualiza las clasificaciones etc */
        public void simularLiga(CompeticionTotalCO competicion,ArrayList calendario)
        {
            int numeroJornada = 1;
            
            ArrayList clasificacion = new ArrayList();
            PartidoTotalCO partido;
            int cod_Competicion=competicion.Competicion.Cd_Competicion;
            int numeroEquipos = competicion.ListaEquipos.Count;
            

            for (int i = 1; i <= numeroEquipos; i++)
            {
                clasificacion.Add(new ClasificacionVO(cod_Competicion, 0, i, i, 0, 0, 0, 0, 0, 0));
            }



            foreach (ArrayList jornada in calendario)
            {
                foreach (Jornada part in jornada)
                {
                    partido = generarPartidoCompleto(cod_Competicion, Convert.ToString(numeroJornada), (int)part.Local, (int)part.Visitante);

                    //clasificaciones
                    clasificacion = fachada.actualizarClasificacionTrasPartido(numeroJornada, partido.Partido, clasificacion);
                }
                //ojo con esta linea ...
                fachada.crearClasificacionJornada(clasificacion);
                numeroJornada++;
            }


        }

    }
}
