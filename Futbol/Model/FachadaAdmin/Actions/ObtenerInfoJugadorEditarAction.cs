using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Integrante.VO;
using Futbol.Model.Integrante.DAO;
using Futbol.Model.HcoIntegrante.VO;
using Futbol.Model.HcoIntegrante.DAO;
using Futbol.Model.Jugador.DAO;
using Futbol.Model.Jugador.VO;
using Futbol.Model.Directivo.DAO;
using Futbol.Model.Directivo.VO;
using Futbol.Model.Entrenador.VO;
using Futbol.Model.Entrenador.DAO;
using Futbol.Model.FachadaAdmin.COs;


namespace Futbol.Model.FachadaAdmin.Actions
{
    public class ObtenerInfoJugadorEditarAction : NonTransactionalPlainAction
    {
        int cod_Integrante;
        public ObtenerInfoJugadorEditarAction(int cod_Integrante)
        {
            this.cod_Integrante = cod_Integrante;
        }

        public object execute(DbConnection connection)
        {
            IntegranteDAO integranteDAO= new IntegranteDAO();
            JugadorDAO jugadorDAO = new JugadorDAO();
            EntrenadorDAO entrenadorDAO=new EntrenadorDAO();
            DirectivoDAO directivoDAO=new DirectivoDAO();
            HcoIntegranteDAO hcoIntegranteDAO = new HcoIntegranteDAO();
            JugadorVO jugadorVO;
            EntrenadorVO entrenadorVO;
            DirectivoVO directivoVO;

            IntegranteVO integranteVO = integranteDAO.verIntegrante(connection, null, cod_Integrante);
            
            var listaHcoIntegrante = hcoIntegranteDAO.obtenerListaHcoIntegranteVO(connection, null, cod_Integrante);
            
            HcoIntegranteVO hcoIntegranteVO = (HcoIntegranteVO) listaHcoIntegrante[listaHcoIntegrante.Count - 1];
            
            jugadorVO = jugadorDAO.obtenerJugadorVO(connection, null, hcoIntegranteVO.Cod_Integrante,
                hcoIntegranteVO.Cod_Equipo, hcoIntegranteVO.Version_Integrante);
            
            if (jugadorVO != null)
                return new JugadorCO(jugadorVO, listaHcoIntegrante, integranteVO);
            

            entrenadorVO = entrenadorDAO.obtenerEntrenadorVO(connection, null, cod_Integrante,
                    hcoIntegranteVO.Cod_Equipo, hcoIntegranteVO.Version_Integrante);
            if (entrenadorVO!=null)
                return new EntrenadorCO(entrenadorVO,listaHcoIntegrante,integranteVO);
            
            directivoVO=directivoDAO.obtenerDirectivoVO(connection,null,cod_Integrante,
                hcoIntegranteVO.Cod_Equipo, hcoIntegranteVO.Version_Integrante);
            if (directivoVO != null)
                return new DirectivoCO(directivoVO, listaHcoIntegrante, integranteVO);
            
            return null;

        }
    }
}
