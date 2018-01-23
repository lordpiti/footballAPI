using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Partido.DAO;
using Futbol.Model.Partido.VO;
using Futbol.Model.PartidoJugado.DAO;
using Futbol.Model.PartidoJugado.VO;
using Futbol.Model.Gol.VO;
using Futbol.Model.Gol.DAO;
using Futbol.Model.Cambio.VO;
using Futbol.Model.Cambio.DAO;
using Futbol.Model.Tarjeta.VO;
using Futbol.Model.Tarjeta.DAO;
using System.Collections;
using Util.Log;


namespace Futbol.Model.FachadaPartidos.Actions
{
    class CrearPartidoTotalAction : TransactionalPlainAction
    {

        private PartidoTotalCO partidoTotalCO;

        public CrearPartidoTotalAction(PartidoTotalCO partidoTotalCO)
        {
            this.partidoTotalCO = partidoTotalCO;
        }

        public object execute(DbConnection connection,DbTransaction transaction)
        {

            PartidoDAO partidoDAO = PartidoDAOFactory.GetDAO();
            PartidoJugadoDAO partidoJugadoDAO = PartidoJugadoDAOFactory.GetDAO();
            GolDAO golDAO = GolDAOFactory.GetDAO();
            CambioDAO cambioDAO = CambioDAOFactory.GetDAO();
            TarjetaDAO tarjetaDAO = TarjetaDAOFactory.GetDAO();
            int cod_PartidoGenerado;

            PartidoVO partidoVO = partidoTotalCO.Partido;         
            ArrayList listaPartidoJugado = partidoTotalCO.PartidosJugados;
            var listaGoles = partidoTotalCO.Goles;
            var listaCambios = partidoTotalCO.Cambios; 
            var listaTarjetas = partidoTotalCO.Tarjetas;
            
            /*se crea el partido y se obtiene su identificador*/
            partidoVO = partidoDAO.create(connection, transaction, partidoTotalCO.Partido);

        
            cod_PartidoGenerado = partidoVO.Cod_Partido;


            /*Para cada partido jugado de la lista, se asigna
             * el identificador de partido obtenido antes*/
            foreach (PartidoJugadoVO partidoJugado in listaPartidoJugado)
            {
                partidoJugado.Cod_Partido = cod_PartidoGenerado;
                partidoJugadoDAO.create(connection, transaction, partidoJugado);
            }
       

            /*Para cada gol de la lista, se asigna el
             * identificador de partido obtenido antes*/
            if (listaGoles != null)
            {
                foreach (GolVO golVO in listaGoles)
                {
                    golVO.Cd_Partido = cod_PartidoGenerado;
                    golDAO.create(connection, transaction, golVO);
                }
            }




            //ahora creamos los cambios
            if (listaCambios != null)
            {
                foreach (CambioVO item in listaCambios)
                {
                    item.Cd_Partido = cod_PartidoGenerado;
                    cambioDAO.create(connection, transaction, item);
                }
            }



            //ahora creamos las tarjetas

            if (listaTarjetas != null)
            {
                foreach (TarjetaVO item in listaTarjetas)
                {
                    item.Cd_Partido = cod_PartidoGenerado;
                    tarjetaDAO.create(connection, transaction, item);
                }
            }





            return new PartidoTotalCO(partidoVO, listaPartidoJugado, listaGoles,
                listaCambios,listaTarjetas);
        }
    }
}