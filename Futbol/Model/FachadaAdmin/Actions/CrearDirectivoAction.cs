using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Directivo.DAO;
using Futbol.Model.Directivo.VO;
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
    class CrearDirectivoAction : TransactionalPlainAction
    {

        private DirectivoCO directivoCO;

        public CrearDirectivoAction(DirectivoCO directivoCO)
        {
            this.directivoCO = directivoCO;
        }

        public object execute(DbConnection connection, DbTransaction transaction)
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
            directivoCO.Directivo.Cod_Equipo = hcoIntegranteCreado.Cod_Equipo;
            directivoCO.Directivo.Version_Integrante = hcoIntegranteCreado.Version_Integrante;
            
            
            DirectivoVO directivoVO = directivoDAO.create(connection, transaction,
                directivoCO.Directivo);

            return new DirectivoCO(directivoVO, directivoCO.ListaHcoIntegrantes, integranteVO);
        }

    }
}