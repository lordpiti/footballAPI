using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Equipo.DAO;
using Futbol.Model.Estadio.VO;
using Futbol.Model.Estadio.DAO;
using Futbol.Model.Integrante.VO;
using Futbol.Model.Integrante.DAO;
using Futbol.Model.Jugador.DAO;
using Futbol.Model.Jugador.VO;
using Futbol.Model.Entrenador.DAO;
using Futbol.Model.Entrenador.VO;
using Futbol.Model.Directivo.DAO;
using Futbol.Model.Directivo.VO;
using Futbol.Model.HcoIntegrante.DAO;
using Futbol.Model.HcoIntegrante.VO;
using System.Collections;

using Futbol.Model.FachadaAdmin.COs;


namespace Futbol.Model.FachadaAdmin.Actions
{
    class CrearEquipoTotalAction : TransactionalPlainAction
    {

        private EquipoTotalCO equipoTotal;

        public CrearEquipoTotalAction(EquipoTotalCO equipoTotal)
        {
            this.equipoTotal = equipoTotal;
        }

        public object execute(DbConnection connection,DbTransaction transaction)
        {

            EquipoVO equipoVO = equipoTotal.Equipo;
            EstadioVO estadioVO = equipoTotal.Estadio;
            var listaJugadores = equipoTotal.ListaJugadores;
            ArrayList listaEntrenadores = equipoTotal.ListaEntrenadores;
            ArrayList listaDirectivos = equipoTotal.ListaDirectivos;


            
            //Creamos el EquipoVO
            if (equipoVO != null)
            {
                EquipoDAO equipoDAO = new EquipoDAO();
                equipoVO = equipoDAO.create(connection, transaction, equipoVO);
            }


            //Creamos el EstadioVO
            if (estadioVO != null)
            {
                EstadioDAO estadioDAO = EstadioDAOFactory.GetDAO();
                estadioVO= estadioDAO.create(connection, transaction, estadioVO);
            }

            
            //Creamos todos los jugadoresCOs
            if (listaJugadores != null)
            {
                HcoIntegranteDAO hcoIntegranteDAO = HcoIntegranteDAOFactory.GetDAO();
                IntegranteDAO integranteDAO = IntegranteDAOFactory.GetDAO();
                JugadorDAO jugadorDAO = JugadorDAOFactory.GetDAO();
            
                foreach (JugadorCO jugadorCO in listaJugadores)
                {
                    IntegranteVO integranteVO = jugadorCO.Integrante;
                    int cod_Integrante = jugadorCO.cod_Integrante();
                    

                    if (integranteDAO.Exists(connection, transaction, cod_Integrante)) 
                    {
                        
                    }
                    else
                    {
                        
                        integranteVO = integranteDAO.create(connection, transaction, jugadorCO.Integrante);
                        cod_Integrante = integranteVO.Cod_Integrante;
                    }

                    HcoIntegranteVO hcoIntegranteCreado = null;
                    foreach (HcoIntegranteVO hcoIntegrante in jugadorCO.ListaHcoIntegrantes)
                    {
                        hcoIntegrante.Cod_Integrante = cod_Integrante;
                        hcoIntegranteCreado = hcoIntegranteDAO.create(connection, transaction,
                        hcoIntegrante);

                    }
                    


                    //linea anadida
                    if (jugadorCO.GetType().Name.Equals("JugadorCO"))
                    {
                        (jugadorCO as JugadorCO).Jugador.Cod_Integrante = cod_Integrante;
                        (jugadorCO as JugadorCO).Jugador.Version_Integrante = hcoIntegranteCreado.Version_Integrante;
                        JugadorVO jugadorVO = jugadorDAO.create(connection, transaction,
                        (jugadorCO as JugadorCO).Jugador);
                    }

                }

            }
         

            //creamos todos los EntrenadorCOs
            if (listaEntrenadores!=null)
            {
            foreach (EntrenadorCO entrenadorCO in listaEntrenadores)
            {
                IntegranteDAO integranteDAO = new IntegranteDAO();
                EntrenadorDAO entrenadorDAO = new EntrenadorDAO();
                HcoIntegranteDAO hcoIntegranteDAO = new HcoIntegranteDAO();
                IntegranteVO integranteVO = entrenadorCO.Integrante;
                int cod_Integrante = entrenadorCO.Entrenador.Cod_Integrante;

                    if (integranteDAO.Exists(connection, transaction, cod_Integrante)) { }
                    else
                    {
                        integranteVO = integranteDAO.create(connection, transaction, entrenadorCO.Integrante);
                        cod_Integrante = integranteVO.Cod_Integrante;
                    }

                    HcoIntegranteVO hcoIntegranteCreado = null;
                    foreach (HcoIntegranteVO hcoIntegrante in entrenadorCO.ListaHcoIntegrantes)
                    {
                        hcoIntegrante.Cod_Integrante = cod_Integrante;
                        hcoIntegranteCreado = hcoIntegranteDAO.create(connection, transaction,
                        hcoIntegrante);

                    }

                    entrenadorCO.Entrenador.Cod_Integrante = cod_Integrante;

                    //linea anadida
                    if (entrenadorCO.GetType().Name.Equals("EntrenadorCO"))
                    {
                        (entrenadorCO as EntrenadorCO).Entrenador.Cod_Integrante = cod_Integrante;
                        (entrenadorCO as EntrenadorCO).Entrenador.Version_Integrante = hcoIntegranteCreado.Version_Integrante;
                        EntrenadorVO entrenadorVO = entrenadorDAO.create(connection, transaction,
                        (entrenadorCO as EntrenadorCO).Entrenador);
                    }

                }

            }


            //Creamos todos los DirectivoCOs
            if (listaDirectivos != null)
            {
                foreach (DirectivoCO directivoCO in listaDirectivos)
                {
                    IntegranteDAO integranteDAO = new IntegranteDAO();
                    DirectivoDAO directivoDAO = new DirectivoDAO();
                    HcoIntegranteDAO hcoIntegranteDAO = new HcoIntegranteDAO();
                    IntegranteVO integranteVO = directivoCO.Integrante;
                    int cod_Integrante = directivoCO.Directivo.Cod_Integrante;

                    if (integranteDAO.Exists(connection, transaction, cod_Integrante)) { }
                    else
                    {
                        integranteVO = integranteDAO.create(connection, transaction, directivoCO.Integrante);
                        cod_Integrante = integranteVO.Cod_Integrante;
                    }

                    HcoIntegranteVO hcoIntegranteCreado = null;
                    foreach (HcoIntegranteVO hcoIntegrante in directivoCO.ListaHcoIntegrantes)
                    {
                        hcoIntegrante.Cod_Integrante = cod_Integrante;
                        hcoIntegranteCreado = hcoIntegranteDAO.create(connection, transaction,
                        hcoIntegrante);

                    }

                    directivoCO.Directivo.Cod_Integrante = cod_Integrante;

                    //linea anadida
                    if (directivoCO.GetType().Name.Equals("DirectivoCO"))
                    {
                        (directivoCO as DirectivoCO).Directivo.Cod_Integrante = cod_Integrante;
                        (directivoCO as DirectivoCO).Directivo.Version_Integrante = hcoIntegranteCreado.Version_Integrante;
                        DirectivoVO directivoVO = directivoDAO.create(connection, transaction,
                        (directivoCO as DirectivoCO).Directivo);
                    }

                }
            }
            return (new EquipoTotalCO(equipoVO, listaJugadores, listaEntrenadores, listaDirectivos,
                estadioVO));

        }
    }
}