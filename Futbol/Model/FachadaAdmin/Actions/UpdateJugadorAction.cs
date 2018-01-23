using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Futbol.ActionProcessor;
using Futbol.Model.Jugador.DAO;
using Futbol.Model.Entrenador.DAO;
using Futbol.Model.Directivo.DAO;
using Futbol.Model.Integrante.DAO;
using Futbol.Model.HcoIntegrante.DAO;
using Futbol.Model.FachadaAdmin.COs;

using Futbol.Model.HcoIntegrante.VO;

namespace Futbol.Model.FachadaAdmin.Actions
{
    class UpdateJugadorAction:TransactionalPlainAction
    {
        
        private MiembroCO info;

        public UpdateJugadorAction(MiembroCO info)
        {
            this.info = info;
        }

        public object execute(DbConnection connection, DbTransaction transaction)
        {

            IntegranteDAO integranteDAO = IntegranteDAOFactory.GetDAO();
            HcoIntegranteDAO hcoIntegranteDAO = HcoIntegranteDAOFactory.GetDAO();
            JugadorDAO jugadorDAO = JugadorDAOFactory.GetDAO();
            EntrenadorDAO entrenadorDAO = EntrenadorDAOFactory.GetDAO();
            DirectivoDAO directivoDAO = DirectivoDAOFactory.GetDAO();
            if (info.Integrante!=null)
                integranteDAO.updateIntegrante(connection,transaction,info.Integrante);
            HcoIntegranteVO hcoIntegranteActual = (HcoIntegranteVO) info.ListaHcoIntegrantes[info.ListaHcoIntegrantes.Count - 1];
            
            hcoIntegranteDAO.updateHcoIntegrante(connection,transaction,hcoIntegranteActual);

            if (info.GetType().Name.Equals("JugadorCO"))
            {
                if ((info as JugadorCO).Jugador!=null)
                    jugadorDAO.updateJugador(connection, transaction, (info as JugadorCO).Jugador);

            }
            else
                if (info.GetType().Name.Equals("EntrenadorCO"))
                {
                    if ((info as EntrenadorCO).Entrenador != null)
                        entrenadorDAO.updateEntrenador(connection, transaction, (info as EntrenadorCO).Entrenador);
                }
                else
                {
                    if ((info as DirectivoCO).Directivo != null)
                    directivoDAO.updateDirectivo(connection, transaction, (info as DirectivoCO).Directivo);
                }
            
            return info;
        }








    }
}
