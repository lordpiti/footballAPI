using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Equipo.VO;
using Futbol.Model.Equipo.DAO;
using Futbol.Model.EquiposParticipan.DAO;
using Futbol.Model.EquiposParticipan.VO;
using System.Collections;



namespace Futbol.Model.FachadaDatos.Actions
{
    class VerEquiposCompeticionAction : NonTransactionalPlainAction
    {
        int cod_Competicion;

        public VerEquiposCompeticionAction(int cod_Competicion)
        {
            this.cod_Competicion = cod_Competicion;
        }

        public object execute(DbConnection connection)
        {

            EquipoDAO equipoDAO = EquipoDAOFactory.GetDAO();
            EquiposParticipanDAO equiposParticipanDAO = EquiposParticipanDAOFactory.GetDAO();
            var listaEquipos = equiposParticipanDAO.verEquiposParticipan(connection, null, cod_Competicion);


            return listaEquipos;
        }
    }
}