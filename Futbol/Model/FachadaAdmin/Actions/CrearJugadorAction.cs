using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Jugador.DAO;
using Futbol.Model.Jugador.VO;
using Futbol.Model.Integrante.DAO;
using Futbol.Model.Integrante.VO;
using Futbol.Model.HcoIntegrante.DAO;
using Futbol.Model.HcoIntegrante.VO;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Equipo.DAO;
using System.Collections;

using Futbol.Model.FachadaAdmin.COs;


namespace Futbol.Model.FachadaAdmin.Actions
{
    class CrearJugadorAction : TransactionalPlainAction
    {

        private JugadorCO jugadorCO;

        public CrearJugadorAction(JugadorCO jugadorCO)
        {
            this.jugadorCO = jugadorCO;
        }

        public object execute(DbConnection connection, DbTransaction transaction)
        {

            IntegranteDAO integranteDAO = new IntegranteDAO();
            JugadorDAO jugadorDAO = new JugadorDAO();
            HcoIntegranteDAO hcoIntegranteDAO = new HcoIntegranteDAO();
            IntegranteVO integranteVO = jugadorCO.Integrante;
            int cod_Integrante = jugadorCO.Jugador.Cod_Integrante;
            
            if (integranteDAO.Exists(connection, transaction, cod_Integrante)){}
            else {
                integranteVO=integranteDAO.create(connection,transaction,jugadorCO.Integrante);
                cod_Integrante = integranteVO.Cod_Integrante;
            }

            
            HcoIntegranteVO hcoIntegranteCreado = null;
            foreach (HcoIntegranteVO hcoIntegrante in jugadorCO.ListaHcoIntegrantes)
            {
                hcoIntegrante.Cod_Integrante = cod_Integrante;
                hcoIntegranteCreado = hcoIntegranteDAO.create(connection, transaction,
                hcoIntegrante);
            }
            jugadorCO.Jugador.Cod_Integrante = cod_Integrante;
            jugadorCO.Jugador.Cod_Equipo = hcoIntegranteCreado.Cod_Equipo;
            jugadorCO.Jugador.Version_Integrante = hcoIntegranteCreado.Version_Integrante;



            JugadorVO jugadorVO = jugadorDAO.create(connection,transaction,
                jugadorCO.Jugador);

            return new JugadorCO(jugadorVO, jugadorCO.ListaHcoIntegrantes, integranteVO);
        }

    }
}