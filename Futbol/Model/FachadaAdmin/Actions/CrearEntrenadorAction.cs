using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Entrenador.DAO;
using Futbol.Model.Entrenador.VO;
using Futbol.Model.Integrante.DAO;
using Futbol.Model.Integrante.VO;
using Futbol.Model.HcoIntegrante.DAO;
using Futbol.Model.HcoIntegrante.VO;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Equipo.DAO;
using System.Collections;
using Util.Log;
using Futbol.Model.FachadaAdmin.COs;


namespace Futbol.Model.FachadaAdmin.Actions
{
    class CrearEntrenadorAction : TransactionalPlainAction
    {

        private EntrenadorCO entrenadorCO;

        public CrearEntrenadorAction(EntrenadorCO entrenadorCO)
        {
            this.entrenadorCO = entrenadorCO;
        }

        public object execute(DbConnection connection, DbTransaction transaction)
        {

            IntegranteDAO integranteDAO = new IntegranteDAO();
            EntrenadorDAO entrenadorDAO = new EntrenadorDAO();
            HcoIntegranteDAO hcoIntegranteDAO = new HcoIntegranteDAO();
            IntegranteVO integranteVO = entrenadorCO.Integrante;
            int cod_Integrante = entrenadorCO.Entrenador.Cod_Integrante;
            
            if (integranteDAO.Exists(connection, transaction, cod_Integrante)){}
            else {
                integranteVO=integranteDAO.create(connection,transaction,entrenadorCO.Integrante);
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
            entrenadorCO.Entrenador.Cod_Equipo = hcoIntegranteCreado.Cod_Equipo;

            //linea anadida
            entrenadorCO.Entrenador.Version_Integrante = hcoIntegranteCreado.Version_Integrante;
            EntrenadorVO entrenadorVO = entrenadorDAO.create(connection,transaction,
                entrenadorCO.Entrenador);

            return new EntrenadorCO(entrenadorVO,entrenadorCO.ListaHcoIntegrantes, integranteVO);
        }

    }
}