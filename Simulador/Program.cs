using Futbol.Model.FachadaAdmin;
using Futbol.Model.FachadaDatos;
using Futbol.Model.FachadaPartidos;
using System;
using System.Collections;


namespace Simulador
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
 
            FachadaDatos fachadaDatos = new FachadaDatos();
            FachadaPartidos fachadaPartidos = new FachadaPartidos();
            FachadaAdmin fachadaAdmin = new FachadaAdmin();
            GeneradorCosas generador = new GeneradorCosas();
            GeneradorJugadores generadorJug = new GeneradorJugadores();
            GeneradorPartidos generadorPartidos = new GeneradorPartidos();


            ArrayList listaEquipos=new ArrayList();
            int numeroEquipos = 20;


            for (int i = 1; i <= numeroEquipos; i++)
            {
                listaEquipos.Add(i);
            }

            #region Referees

            ////Genera x arbitros
            //ArrayList listaArbitros = new ArrayList();
            //listaArbitros.Add(new ArbitroVO("Pierluigi","Collina","italiano",20,"~/images/arbitros/collina.jpg"));
            //listaArbitros.Add(new ArbitroVO("Anders","Frisk","sueco",20,"~/images/arbitros/frisk.jpg"));
            //listaArbitros.Add(new ArbitroVO("Markus","Merk","alemán",20,"~/images/arbitros/merk.jpg"));
            //listaArbitros.Add(new ArbitroVO("Carlos","Mejuto González","asturiano",20,"~/images/arbitros/mejuto.jpg"));
            //listaArbitros.Add(new ArbitroVO("Eduardo","Iturralde González","vasco",20,"~/images/arbitros/iturralde.jpg"));
            //foreach (ArbitroVO item in listaArbitros)
            //    fachadaAdmin.crearArbitro(item);

            #endregion

            #region Stadiums

            ////Genera x estadios
            //ArrayList listaEstadiosVO = new ArrayList();
            //listaEstadiosVO.Add(new EstadioVO("Riazor",1200,"calle tal","cesped natural","~/images/estadios/riazor.jpg"));;
            //listaEstadiosVO.Add(new EstadioVO("Camp Nou",1200,"calle tal","cesped natural","~/images/estadios/campnou.jpg"));;
            //listaEstadiosVO.Add(new EstadioVO("Allianz Arena",1200,"calle tal","cesped natural","~/images/estadios/allianzarena.jpg"));;
            //listaEstadiosVO.Add(new EstadioVO("San Siro",1200,"calle tal","cesped natural","~/images/estadios/sansiro.jpg"));;
            //listaEstadiosVO.Add(new EstadioVO("Vicente Calderón",1200,"calle tal","cesped natural","~/images/estadios/VicenteCalderon.jpg"));;
            //listaEstadiosVO.Add(new EstadioVO("Santiago Bernabeu",1200,"Paseo de la Castellana, 140, 28036, Madrid","cesped natural","~/images/estadios/bernabeu.jpg"));;
            //listaEstadiosVO.Add(new EstadioVO("Old Trafford",1200,"calle tal","cesped natural","~/images/estadios/OldTrafford.jpg"));;
            //listaEstadiosVO.Add(new EstadioVO("San Mamés",1200,"calle tal","cesped natural","~/images/estadios/sanmames.jpg"));;
            //foreach (EstadioVO item in listaEstadiosVO)
            //    fachadaAdmin.crearEstadio(item);

            #endregion

            #region Teams

            ////Genera x equipos completos
            //ArrayList listaEquiposVO = new ArrayList();
            //listaEquiposVO.Add(new EquipoVO("Deportivo A Coruña", "A Coruña", 6, "~/images/equipos/escudos/depor.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("F.C Barcelona", "Barcelona", 2, "~/images/equipos/escudos/barsa.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Real Madrid", "Madrid", 3, "~/images/equipos/escudos/mandril.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Valencia C.F", "Valencia", 4, "~/images/equipos/escudos/valencia.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Villarreal", "Villarreal", 4, "~/images/equipos/escudos/villarreal.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Atlético de Madrid", "Madrid", 4, "~/images/equipos/escudos/patetico.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Málaga", "Málaga", 4, "~/images/equipos/escudos/zaragoza.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Athletic de Bilbao", "Bilbao", 4, "~/images/equipos/escudos/bilbao.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Almería", "Almería", 4, "~/images/equipos/escudos/almeria.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Valladolid", "Palavea", 4, "~/images/equipos/escudos/valladolid.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Sporting de Gijón", "Gijón", 4, "~/images/equipos/escudos/sporting.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Numancia", "Soria", 4, "~/images/equipos/escudos/numancia.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Racing de Santander", "Santander", 4, "~/images/equipos/escudos/racing.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Osasuna", "Pamplona", 4, "~/images/equipos/escudos/osasuna.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Espanyol", "Barcelona", 4, "~/images/equipos/escudos/espanyol.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Sevilla C.F", "Sevilla", 4, "~/images/equipos/escudos/sevilla.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Betis", "Sevilla", 4, "~/images/equipos/escudos/betis.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Mallorca", "Mallorca", 4, "~/images/equipos/escudos/mallorca.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Getafe", "Getafe", 4, "~/images/equipos/escudos/getafe.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));
            //listaEquiposVO.Add(new EquipoVO("Recreativo de Huelva", "Huelva", 4, "~/images/equipos/escudos/recre.gif", "~/images/equipos/plantillas/plantilla-0708.jpg"));

            //for (int i = 1; i <= numeroEquipos; i++)
            //{
            //    EquipoTotalCO equipoTotal = new EquipoTotalCO(listaEquiposVO[i - 1] as EquipoVO, generadorJug.generaPlantilla(i),
            //        generadorJug.generaCuerpoTécnico(i), generadorJug.generaDirectiva(i),null);


            //    fachadaAdmin.crearEquipoTotal(equipoTotal);
            //}

            #endregion

            #region League

            generadorPartidos.generarLigaCompleta(20);

            #region Second League

            //ArrayList calendarioJornadas2 = generador.generaLiga(listaEquipos);

            //ArrayList calendarioLiga2 = generadorPartidos.generaListaCalendarioVOsLiga(calendarioJornadas2);
            //CompeticionTotalCO comp2 = new CompeticionTotalCO(new CompeticionVO("LFP 1ªDivision 15-16", "2015-2016", generador.generarFechaAleatoriaPartido(),
            //    generador.generarFechaAleatoriaPartido(), "ninguno", "~/images/titulos/copamundo.jpg", "Liga"),
            //    calendarioLiga2, listaEquipos);
            //comp2 = fachadaPartidos.crearCompeticionTotal(comp2);

            //numeroJornada = 1;

            //foreach (ArrayList jornada in calendarioJornadas2)
            //{
            //    foreach (Jornada part in jornada)
            //    {
            //        partido = generadorPartidos.generarPartidoCompleto(comp2.Competicion.Cd_Competicion, Convert.ToString(numeroJornada), (int)part.Local, (int)part.Visitante);
            //    }

            //    fachadaPartidos.actualizarClasificacionCompeticion(comp2.Competicion.Cd_Competicion);
            //    numeroJornada++;
            //}

            #endregion

            #endregion

            #region Cup

            //generadorPartidos.generarCopaCompleta(16);

            ////ahora creamos una competicion de copa
            //int numeroEquipos2 = 16;
            //ArrayList listaEquipos2 = new ArrayList();

            //for (int i = 1; i <= numeroEquipos2; i++)
            //{
            //    listaEquipos2.Add(i);
            //}

            //CompeticionTotalCO comp3 = new CompeticionTotalCO(new CompeticionVO("Copa del Rey", "2014-2015", generador.generarFechaAleatoriaPartido(),
            //    generador.generarFechaAleatoriaPartido(), "ninguno", "~/images/titulos/copaeuropa.jpg", "Playoff"),
            //    null, listaEquipos2);

            //comp3 = fachadaPartidos.crearCompeticionTotal(comp3);

            //ArrayList listiLLa = new ArrayList();
            //ArrayList auxiliar = new ArrayList();
            //ArrayList rondaActual = new ArrayList();
            //Random rand = new Random();
            
            //String nombreRonda = "Fase Previa";
            //foreach (int item in comp3.ListaEquipos)
            //{
            //    listiLLa.Add(item);
            //}

            //while (listiLLa.Count > 1)
            //{
            //    rondaActual = generador.generarRondaCopa(listiLLa);

            //    //obtenemos el nombre de la ronda actual, en funcion del numero de equipos
            //    nombreRonda = generador.obtenerNombreRondaCopa(listiLLa.Count);



            //    //genera los partidos de la ronda de copa actual

            //    foreach (Jornada item in rondaActual)
            //    {
            //        auxiliar.Add(item.Local);
            //        auxiliar.Add(item.Visitante);
            //        generadorPartidos.generarPartidoCompleto(comp3.Competicion.Cd_Competicion, nombreRonda, (int)item.Local, (int)item.Visitante);
            //        int ganador = (int)auxiliar[rand.Next(0, 2)];
            //        auxiliar.Clear();
            //        listiLLa.Remove(ganador);
            //    }

            //}

            #endregion

        }
    }
}