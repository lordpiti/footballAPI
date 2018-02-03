using System;
using System.Collections.Generic;
using System.Text;
using Futbol.ActionProcessor;
using System.Data.Common;
using Futbol.Model.Partido.DAO;
using Futbol.Model.Partido.VO;
using Futbol.Model.Clasificacion.DAO;
using Futbol.Model.Clasificacion.VO;
using Futbol.Model.Gol.VO;
using Futbol.Model.Gol.DAO;
using System.Collections;



namespace Futbol.Model.FachadaPartidos.Actions
{
    class CrearClasificacionJornadaAction : TransactionalPlainAction
    {

        private List<ClasificacionVO> clasificacion;

        public CrearClasificacionJornadaAction(List<ClasificacionVO> clasificacion)
        {
            this.clasificacion = clasificacion;
        }

        public object execute(DbConnection connection, DbTransaction transaction)
        {
            ClasificacionDAO clasificacionDAO = ClasificacionDAOFactory.GetDAO();
            int contador = 1;
           foreach (ClasificacionVO item in clasificacion)
           {
               item.Posicion = contador;
               clasificacionDAO.create(connection, transaction, item);
               contador++;
           }



            return null;
        }
    }
}