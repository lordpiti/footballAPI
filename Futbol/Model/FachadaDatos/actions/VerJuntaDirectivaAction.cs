using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Directivo.VO;
using Futbol.Model.Directivo.DAO;
using System.Collections;



namespace Futbol.Model.FachadaDatos.Actions
{
    class VerJuntaDirectivaAction : NonTransactionalPlainAction
    {

        private int cod_Equipo;

        public VerJuntaDirectivaAction(int cod_Equipo)
        {
            this.cod_Equipo = cod_Equipo;
        }

        public object execute(DbConnection connection)
        {

            DirectivoDAO directivoDAO = new DirectivoDAO();
            var listaDirectivos = directivoDAO.verDirectivosEquipo(connection, null, cod_Equipo, 0, 2);

            return listaDirectivos;
        }
    }
}