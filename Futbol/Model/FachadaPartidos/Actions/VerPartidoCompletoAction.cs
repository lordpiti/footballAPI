using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Partido.DAO;
using Futbol.Model.Partido.VO;
using Futbol.Model.Partido;
using Futbol.Model.PartidoJugado.DAO;
using Futbol.Model.PartidoJugado.VO;
using Futbol.Model.Gol.VO;
using Futbol.Model.Gol.DAO;
using Futbol.Model.Cambio.VO;
using Futbol.Model.Cambio.DAO;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Equipo.DAO;
using Futbol.Model.Estadio.VO;
using Futbol.Model.Estadio.DAO;
using Futbol.Model.Arbitro.VO;
using Futbol.Model.Arbitro.DAO;
using Futbol.Model.Tarjeta.VO;
using Futbol.Model.Tarjeta.DAO;
using System.Collections;
using Futbol.Model.Cambio;
using Futbol.Model.Tarjeta;

namespace Futbol.Model.FachadaPartidos.Actions
{
    class VerPartidoCompletoAction : NonTransactionalPlainAction
    {

        private int cod_Partido;

        public VerPartidoCompletoAction(int cod_Partido)
        {
            this.cod_Partido = cod_Partido;
        }

        public object execute(DbConnection connection)
        {

            ArbitroVO arbitro;
            EstadioVO estadio;
            PartidoVO partido;
            List<CambioCO> listaCambiosLocal;
            List<CambioCO> listaCambiosVisitante;
            List<TarjetaCO> listaTarjetasLocal;
            List<TarjetaCO> listaTarjetasVisitante;


            //Obtenemos el VO del partido
            PartidoDAO partidoDAO = new PartidoDAO();
            partido = partidoDAO.verPartido(connection, null, cod_Partido);

            EquipoDAO equipoDAO = new EquipoDAO();
            PartidoJugadoDAO partidoJugadoDAO = new PartidoJugadoDAO();
            GolDAO golDAO = new GolDAO();
            CambioDAO cambioDAO = new CambioDAO();
            TarjetaDAO tarjetaDAO = new TarjetaDAO();
            

            
            
            //Obtenemos los VOs con los equipos que juegan el partido
            
            EquipoVO equipoLocal=equipoDAO.buscarEquipoId(connection, null, partido.Cod_Local);
            EquipoVO equipoVisitante = equipoDAO.buscarEquipoId(connection, null, partido.Cod_Visitante);
            
            
            //Obtenemos los jugadores titulares y suplentes de ambos equipos en el partido
            
            var titularesLocal=partidoJugadoDAO.buscarJugadoresTitularesEquipoPartido(connection, null,
                equipoLocal.Cd_Equipo, cod_Partido,"titular");

            var titularesVisitante = partidoJugadoDAO.buscarJugadoresTitularesEquipoPartido(connection, null,
            equipoVisitante.Cd_Equipo, cod_Partido,"titular");


            var suplentesLocal = partidoJugadoDAO.buscarJugadoresTitularesEquipoPartido(connection, null,
            equipoLocal.Cd_Equipo, cod_Partido, "suplente");


            var suplentesVisitante = partidoJugadoDAO.buscarJugadoresTitularesEquipoPartido(connection, null,
            equipoVisitante.Cd_Equipo, cod_Partido, "suplente");


            //Obtenemos los VOs del arbitro, estadio

            ArbitroDAO arbitroDAO = new ArbitroDAO();
            EstadioDAO estadioDAO = new EstadioDAO();

            arbitro = arbitroDAO.verArbitro(connection, null, partido.Cod_Arbitro);
            estadio = estadioDAO.buscarEstadioId(connection, null, partido.Cod_Estadio);

            //Obtenemos la lista de goles de ambos equipos

            var listaGolesLocal = golDAO.listarGolesEquipoPartido(connection, null,
                partido.Cod_Partido, partido.Cod_Local, 0, 2);


            var listaGolesVisitante = golDAO.listarGolesEquipoPartido(connection, null,
                partido.Cod_Partido, partido.Cod_Visitante, 0, 2);

            
            //obtenemos la lista de cambios de ambos equipos

            listaCambiosLocal = cambioDAO.listarCambiosPartidoEquipo(connection, null,
                partido.Cod_Partido, partido.Cod_Local, 0, 2);

            listaCambiosVisitante = cambioDAO.listarCambiosPartidoEquipo(connection, null,
                partido.Cod_Partido, partido.Cod_Visitante, 0, 2);
            

            //obtenemos la lista de tarjetas de ambos equipo
            listaTarjetasLocal = tarjetaDAO.listarTarjetasEquipoPartido(connection, null,
                partido.Cod_Local, partido.Cod_Partido, 0, 2);

            listaTarjetasVisitante = tarjetaDAO.listarTarjetasEquipoPartido(connection, null,
                partido.Cod_Visitante, partido.Cod_Partido, 0, 2);
            

            //Creamos el CO del partido completo
            PartidoCompletoCO partidoCompletoCO = new PartidoCompletoCO(equipoLocal, equipoVisitante,
                partido, titularesLocal, titularesVisitante, suplentesLocal, suplentesVisitante,
                listaGolesLocal,listaGolesVisitante, listaTarjetasLocal, listaTarjetasVisitante, estadio, arbitro, null,listaCambiosLocal,
                listaCambiosVisitante);


            return (partidoCompletoCO);

        }
    }
}