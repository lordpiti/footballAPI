using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;
using Util.Log;
using Futbol.Model.Medico.VO;
using System.Data;
using System.Data.Common;

namespace Futbol.Model.Medico.DAO
{
     public class MedicoDAO
    {


         public MedicoVO create(DbConnection connection, DbTransaction transaction, MedicoVO medicoVO)
         {
             try
             {
                 DbCommand command = connection.CreateCommand();

                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }
                 
                 command.CommandText = "INSERT INTO Medico(cod_Integrante,cod_Equipo,version_Integrante,especialidad,fecha_Profesional)"+
                     "values (@cod_Integrante,@cod_Equipo,@version_Integrante,@especialidad,@fecha_Profesional)";

                 DbParameter cod_IntegranteParam = command.CreateParameter();
                 cod_IntegranteParam.ParameterName = "@cod_Integrante";
                 cod_IntegranteParam.DbType = DbType.Int32;
                 cod_IntegranteParam.Value = medicoVO.Cod_Integrante;
                 cod_IntegranteParam.Size = 32;
                 command.Parameters.Add(cod_IntegranteParam);


                 DbParameter cod_EquipoParam = command.CreateParameter();
                 cod_EquipoParam.ParameterName = "@cod_Equipo";
                 cod_EquipoParam.DbType = DbType.Int32;
                 cod_EquipoParam.Value = medicoVO.Cod_Equipo;
                 cod_EquipoParam.Size = 32;
                 command.Parameters.Add(cod_EquipoParam);


                 DbParameter version_IntegranteParam = command.CreateParameter();
                 version_IntegranteParam.ParameterName = "@version_Integrante";
                 version_IntegranteParam.DbType = DbType.Int32;
                 version_IntegranteParam.Value = medicoVO.Version_Integrante;
                 version_IntegranteParam.Size = 32;
                 command.Parameters.Add(version_IntegranteParam);


                 DbParameter especialidadParam = command.CreateParameter();
                 especialidadParam.ParameterName = "@especialidad";
                 especialidadParam.DbType = DbType.String;
                 especialidadParam.Value = medicoVO.Especialidad;
                 especialidadParam.Size = 32;
                 command.Parameters.Add(especialidadParam);


                 DbParameter fecha_ProfesionalParam = command.CreateParameter();
                 fecha_ProfesionalParam.ParameterName = "@fecha_Profesional";
                 fecha_ProfesionalParam.DbType = DbType.DateTime;
                 fecha_ProfesionalParam.Size = 50;
                 fecha_ProfesionalParam.Value = medicoVO.Fecha_Profesional;
                 command.Parameters.Add(fecha_ProfesionalParam);


                 command.Prepare();
                 
                 int insertedRows = command.ExecuteNonQuery();
                 
                 if (insertedRows == 0)
                 {
                     
                     throw new SQLException("errorrrrrrr");
                 }
                 
                 IMedicoIdentifierRetriever medicoIdentifierRetriever = MedicoIdentifierRetrieverFactory.GetRetriever();
                 Int64 medicoIdentifier = medicoIdentifierRetriever.GetGeneratedIdentifier(connection);
                 return new MedicoVO((int)medicoIdentifier, medicoVO.Cod_Integrante,medicoVO.Cod_Equipo,
                     medicoVO.Version_Integrante, medicoVO.Especialidad, medicoVO.Fecha_Profesional);
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);

             }



         }
         
         
         
         

         
         public MedicoVO verMedico(DbConnection connection, DbTransaction transaction,int cod_Medico)
        {

            DbDataReader dataReader = null;
            
            try
            {

                DbCommand command = connection.CreateCommand();
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }


                command.CommandText = "SELECT * from Medico where Cod_Medico="+cod_Medico;
                command.Prepare();
                
                dataReader = command.ExecuteReader();
                
                if (!dataReader.Read())
                {
                    throw new InstanceNotFoundException(1, "medico");

                }

                    int cod_Integrante = dataReader.GetInt32(1);
                    int cod_Equipo = dataReader.GetInt32(2);
                    int version_Integrante = dataReader.GetInt32(3);
                    String especialidad = dataReader.GetString(4);
                    DateTime fecha_Profesional = dataReader.GetDateTime(5);


                    return new MedicoVO(cod_Medico, cod_Integrante,cod_Equipo, version_Integrante, 
                        especialidad,fecha_Profesional);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }
    }
}
