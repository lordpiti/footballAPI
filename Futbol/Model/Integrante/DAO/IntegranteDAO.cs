using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;

using Futbol.Model.Integrante.VO;
using System.Data;
using System.Data.Common;

namespace Futbol.Model.Integrante.DAO
{
     public class IntegranteDAO
    {

         public IntegranteVO create(DbConnection connection, DbTransaction transaction, IntegranteVO integranteVO)
         {
             
             try
             {
                 DbCommand command = connection.CreateCommand();

                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }
                 
                 command.CommandText = "INSERT INTO Integrante (cod_int,nombre,apellidos,fecha_nac,foto) values (@cod_int,@nombre,@apellidos,@fecha,@foto)";

                 DbParameter cod_IntParam = command.CreateParameter();
                 cod_IntParam.ParameterName = "@cod_Int";
                 cod_IntParam.DbType = DbType.Int32;
                 cod_IntParam.Value = integranteVO.Cod_Integrante;
                 cod_IntParam.Size = 20;
                 command.Parameters.Add(cod_IntParam);
                 
                 
                 
                 DbParameter nombreParam = command.CreateParameter();
                 nombreParam.ParameterName = "@nombre";
                 nombreParam.DbType = DbType.String;
                 nombreParam.Value = integranteVO.Nombre;
                 nombreParam.Size = 20;
                 command.Parameters.Add(nombreParam);
                 

                 DbParameter apellidosParam = command.CreateParameter();
                 apellidosParam.ParameterName = "@apellidos";
                 apellidosParam.DbType = DbType.String;
                 apellidosParam.Value = integranteVO.Apellidos;
                 apellidosParam.Size = 30;
                 command.Parameters.Add(apellidosParam);


                 DbParameter fechaParam = command.CreateParameter();
                 fechaParam.ParameterName = "@fecha";
                 fechaParam.DbType = DbType.DateTime;
                 fechaParam.Value = integranteVO.Fecha_Nacimiento;
                 fechaParam.Size = 100;
                 command.Parameters.Add(fechaParam);
                 

                 DbParameter fotoParam = command.CreateParameter();
                 fotoParam.ParameterName = "@foto";
                 fotoParam.DbType = DbType.String;
                 fotoParam.Size = 50;


                 if (integranteVO.Foto == null) fotoParam.Value = DBNull.Value;
                 else fotoParam.Value = integranteVO.Foto;
                 
                 command.Parameters.Add(fotoParam);

                 command.Prepare();
                 
                 int insertedRows = command.ExecuteNonQuery();
                 
                
                 if (insertedRows == 0)
                 {
                     throw new SQLException("errorrrrrrr");
                 }

      /*           IIntegranteIdentifierRetriever integranteIdentifierRetriever = IntegranteIdentifierRetrieverFactory.GetRetriever();

                 Int64 integranteIdentifier = integranteIdentifierRetriever.GetGeneratedIdentifier(connection);
        */
                 return new IntegranteVO(integranteVO.Cod_Integrante, integranteVO.Nombre, integranteVO.Apellidos,
                     integranteVO.Fecha_Nacimiento, integranteVO.Foto);
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);

             }



         }
         
         

         public IntegranteVO verIntegrante(DbConnection connection, DbTransaction transaction,int cod_Integrante)
        {

            DbDataReader dataReader = null;
            
            try
            {

                DbCommand command = connection.CreateCommand();
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }


                command.CommandText = "SELECT * from Integrante where Cod_Int="+cod_Integrante;
                command.Prepare();
                
                dataReader = command.ExecuteReader();
                
                if (!dataReader.Read())
                {
                    throw new InstanceNotFoundException(1, "integr");

                }

                
                    int cod_Int = dataReader.GetInt32(0);
                    String nombre = dataReader.GetString(1);
                    String apellidos = dataReader.GetString(2);
                    
                    DateTime fecha_Nacimiento;
                    if (dataReader.GetValue(3)==DBNull.Value)
                        fecha_Nacimiento=DateTime.Now;
                    else fecha_Nacimiento=dataReader.GetDateTime(3);
                    String foto;
                    if (dataReader.GetValue(4) == DBNull.Value)
                        foto = null;
                    else foto = dataReader.GetString(4);

                    


                    return new IntegranteVO(cod_Integrante, nombre, apellidos, fecha_Nacimiento, foto);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }



         public bool Exists(DbConnection connection,
             DbTransaction transaction, int cod_Int)
         {

             DbDataReader dataReader = null;

             try
             {
                 /* Creates the command. */
                 DbCommand command = connection.CreateCommand();

                 /* If transaction exists, command will be added */
                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }

                 command.CommandText =
                     "SELECT Cod_Int FROM Integrante " +
                     "WHERE Cod_Int = " + cod_Int;
                 

                 command.Prepare();

                 dataReader = command.ExecuteReader();

                 return (dataReader.Read());

             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);

             }
             finally
             {
                 dataReader.Close();
             }
         }


         public IntegranteVO updateIntegrante(DbConnection connection,
             DbTransaction transaction,IntegranteVO integranteVO)
         {
             try
             {
                 DbCommand command = connection.CreateCommand();

                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }

                 command.CommandText = "UPDATE Integrante SET nombre=@nombre,apellidos=@apellidos,fecha_nac=@fecha,foto=@foto "+
                     "WHERE cod_int=@cod_Int";

                 DbParameter cod_IntParam = command.CreateParameter();
                 cod_IntParam.ParameterName = "@cod_Int";
                 cod_IntParam.DbType = DbType.Int32;
                 cod_IntParam.Value = integranteVO.Cod_Integrante;
                 cod_IntParam.Size = 20;
                 command.Parameters.Add(cod_IntParam);



                 DbParameter nombreParam = command.CreateParameter();
                 nombreParam.ParameterName = "@nombre";
                 nombreParam.DbType = DbType.String;
                 nombreParam.Value = integranteVO.Nombre;
                 nombreParam.Size = 20;
                 command.Parameters.Add(nombreParam);


                 DbParameter apellidosParam = command.CreateParameter();
                 apellidosParam.ParameterName = "@apellidos";
                 apellidosParam.DbType = DbType.String;
                 apellidosParam.Value = integranteVO.Apellidos;
                 apellidosParam.Size = 30;
                 command.Parameters.Add(apellidosParam);


                 DbParameter fechaParam = command.CreateParameter();
                 fechaParam.ParameterName = "@fecha";
                 fechaParam.DbType = DbType.DateTime;
                 fechaParam.Value = integranteVO.Fecha_Nacimiento;
                 fechaParam.Size = 100;
                 command.Parameters.Add(fechaParam);


                 DbParameter fotoParam = command.CreateParameter();
                 fotoParam.ParameterName = "@foto";
                 fotoParam.DbType = DbType.String;
                 fotoParam.Size = 50;


                 if (integranteVO.Foto == null) fotoParam.Value = DBNull.Value;
                 else fotoParam.Value = integranteVO.Foto;

                 command.Parameters.Add(fotoParam);

                 command.Prepare();

                 int insertedRows = command.ExecuteNonQuery();



                 return new IntegranteVO(integranteVO.Cod_Integrante, integranteVO.Nombre, integranteVO.Apellidos,
                     integranteVO.Fecha_Nacimiento, integranteVO.Foto);
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);

             }


         }


    }
}
