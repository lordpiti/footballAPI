using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;

using Futbol.Model.EquiposParticipan.VO;
using System.Data;
using System.Data.Common;








namespace Futbol.Model.EquiposParticipan.DAO
{
    public class EquiposParticipanDAO
    {

        public EquiposParticipanVO create(DbConnection connection, DbTransaction transaction, EquiposParticipanVO equiposParticipanVO)
        {
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }



                command.CommandText = "INSERT INTO EquiposParticipan(cod_Competicion,cod_Equipo) "+
                    "VALUES (@cod_Competicion,@cod_Equipo)";

                DbParameter cod_CompeticionParam = command.CreateParameter();
                cod_CompeticionParam.ParameterName = "@cod_Competicion";
                cod_CompeticionParam.DbType = DbType.Int32;
                cod_CompeticionParam.Value = equiposParticipanVO.Cod_Competicion;
                cod_CompeticionParam.Size = 32;
                command.Parameters.Add(cod_CompeticionParam);



                DbParameter cod_EquipoParam = command.CreateParameter();
                cod_EquipoParam.ParameterName = "@cod_Equipo";
                cod_EquipoParam.DbType = DbType.Int32;
                cod_EquipoParam.Value = equiposParticipanVO.Cod_Equipo;
                cod_EquipoParam.Size = 32;
                command.Parameters.Add(cod_EquipoParam);




                command.Prepare();
                int insertedRows = command.ExecuteNonQuery();
                
                if (insertedRows == 0)
                {            
                    throw new SQLException("errorrrrrrr");
                }


                return equiposParticipanVO;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }



        public List<EquiposParticipanVO> verEquiposParticipan(DbConnection connection, DbTransaction transaction,
        int cod_Competicion)
        {

            DbDataReader dataReader = null;

            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT ep.Cod_Competicion, ep.cod_equipo " +
                    "FROM EquiposParticipan ep where ep.cod_Competicion=" + cod_Competicion;

                command.Prepare();
                dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                {
                  //  throw new InstanceNotFoundException(1, "algo");
                    return null;
                }


                var listaEquiposParticipan = new List<EquiposParticipanVO>();

                do
                {

                    int cod_Equipo = dataReader.GetInt32(1);
                    
                    EquiposParticipanVO equiposParticipanVO =
                        new EquiposParticipanVO(cod_Competicion, cod_Equipo);
                    listaEquiposParticipan.Add(equiposParticipanVO);

                }
                while (dataReader.Read());

                return listaEquiposParticipan;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }




        }
    
    
    
    
    
    
    
    
    
    
    }
}
