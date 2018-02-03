using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;

using Futbol.Model.HcoIntegrante.VO;
using System.Data;
using System.Data.Common;

namespace Futbol.Model.HcoIntegrante.DAO
{
     public class HcoIntegranteDAO
    {


         public HcoIntegranteVO create(DbConnection connection, DbTransaction transaction, HcoIntegranteVO hcoIntegranteVO)
         {
             try
             {
                 DbCommand command = connection.CreateCommand();

                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }

                 //vamos a obtener primero la version de integrante correcta

                 command.CommandText = "SELECT max(version_integrante) from hco_integrante " +
                     "WHERE cod_integrante=" + hcoIntegranteVO.Cod_Integrante;

                 command.Connection = connection;
                 command.Prepare();
                 Int32 versionInt=1;
                 DbDataReader dataReader = null;

                 dataReader = command.ExecuteReader();
                 
                 

                 if (!dataReader.Read())
                 {
                     versionInt = 1;
                     

                 }
                 if (dataReader.GetValue(0) == DBNull.Value)
                 {
                     versionInt = 1;
                     
                 }
                 else versionInt = dataReader.GetInt32(0) + 1;

                 
                

                 

                 dataReader.Close();




                 //realizamos ahora la insercion

                 command = connection.CreateCommand();

                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }

                                  
                 command.CommandText = "INSERT INTO Hco_Integrante (cod_Integrante,cod_Equipo,version_integrante,fecha_Inicio,fecha_Fin,"+
                     "fecha_Fin_Contrato, sueldo,dorsal) values (@cod_Int,@cod_Equipo,@version_integrante,@fecha_Inicio,@fecha_Fin,"+
                     "@fecha_Fin_Contrato,@sueldo,@dorsal)";

                 DbParameter cod_IntParam = command.CreateParameter();
                 cod_IntParam.ParameterName = "@cod_Int";
                 cod_IntParam.DbType = DbType.Int32;
                 cod_IntParam.Value = hcoIntegranteVO.Cod_Integrante;
                 cod_IntParam.Size = 20;
                 command.Parameters.Add(cod_IntParam);


                 DbParameter cod_EquipoParam = command.CreateParameter();
                 cod_EquipoParam.ParameterName = "@cod_Equipo";
                 cod_EquipoParam.DbType = DbType.Int32;
                 cod_EquipoParam.Value = hcoIntegranteVO.Cod_Equipo;
                 cod_EquipoParam.Size = 20;
                 command.Parameters.Add(cod_EquipoParam);



                 DbParameter version_integranteParam = command.CreateParameter();
                 version_integranteParam.ParameterName = "@version_integrante";
                 version_integranteParam.DbType = DbType.Int32;
                 version_integranteParam.Value = versionInt;
                 version_integranteParam.Size = 20;
                 command.Parameters.Add(version_integranteParam);


                 DbParameter fecha_InicioParam = command.CreateParameter();
                 fecha_InicioParam.ParameterName = "@fecha_Inicio";
                 fecha_InicioParam.DbType = DbType.DateTime;
                 fecha_InicioParam.Value = hcoIntegranteVO.Fecha_Inicio;
                 fecha_InicioParam.Size = 100;
                 command.Parameters.Add(fecha_InicioParam);


                 DbParameter fecha_FinParam = command.CreateParameter();
                 fecha_FinParam.ParameterName = "@fecha_Fin";
                 fecha_FinParam.DbType = DbType.DateTime;
                 if (hcoIntegranteVO.Fecha_Fin == DateTime.MinValue) fecha_FinParam.Value = DBNull.Value;
                 else fecha_FinParam.Value = hcoIntegranteVO.Fecha_Fin;
                 fecha_FinParam.Size = 100;
                 command.Parameters.Add(fecha_FinParam);


                 DbParameter fecha_Fin_ContratoParam = command.CreateParameter();
                 fecha_Fin_ContratoParam.ParameterName = "@fecha_Fin_Contrato";
                 fecha_Fin_ContratoParam.DbType = DbType.DateTime;
                 fecha_Fin_ContratoParam.Value = hcoIntegranteVO.Fecha_Fin_Contrato;
                 fecha_Fin_ContratoParam.Size = 100;
                 command.Parameters.Add(fecha_Fin_ContratoParam);


                 DbParameter sueldoParam = command.CreateParameter();
                 sueldoParam.ParameterName = "@sueldo";
                 sueldoParam.DbType = DbType.Int32;
                 sueldoParam.Value = hcoIntegranteVO.Sueldo;
                 sueldoParam.Size = 20;
                 command.Parameters.Add(sueldoParam);


                 DbParameter dorsalParam = command.CreateParameter();
                 dorsalParam.ParameterName = "@dorsal";
                 dorsalParam.DbType = DbType.Int32;
                 dorsalParam.Value = hcoIntegranteVO.Dorsal;
                 dorsalParam.Size = 20;
                 command.Parameters.Add(dorsalParam);



                 command.Prepare();

                 int insertedRows = command.ExecuteNonQuery();
                 


                 if (insertedRows == 0)
                 {
                     throw new SQLException("errorrrrrrr");
                 }

                 return new HcoIntegranteVO(hcoIntegranteVO.Cod_Integrante, hcoIntegranteVO.Cod_Equipo,
                     versionInt, hcoIntegranteVO.Fecha_Inicio, hcoIntegranteVO.Fecha_Fin,
                     hcoIntegranteVO.Fecha_Fin_Contrato, hcoIntegranteVO.Sueldo,hcoIntegranteVO.Dorsal);
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);

             }

         }

          
         public HcoIntegranteVO verHcoIntegrante(DbConnection connection, DbTransaction transaction,int cod_Integrante)
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
                    throw new InstanceNotFoundException(1, "hcoint");

                }
                    int cod_Int = dataReader.GetInt32(0);
                    int cod_Equipo = dataReader.GetInt32(1);
                    int version = dataReader.GetInt32(2);
                    DateTime fecha_Inicio = dataReader.GetDateTime(3);
                    DateTime fecha_Fin = dataReader.GetDateTime(4);
                    DateTime fecha_Fin_Contrato = dataReader.GetDateTime(5);
                    int sueldo = dataReader.GetInt32(6);
                    int dorsal = dataReader.GetInt32(7);

                    return new HcoIntegranteVO(cod_Int, cod_Equipo, version, 
                        fecha_Inicio, fecha_Fin, fecha_Fin_Contrato, sueldo,dorsal);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }


         public List<HistorialEquiposCO> verHistorialEquipos(DbConnection connection, DbTransaction transaction, int cod_Integrante)
         {

             DbDataReader dataReader = null;

             try
             {

                 DbCommand command = connection.CreateCommand();
                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }


                 command.CommandText = "SELECT e.nombre,h.fecha_inicio,h.fecha_fin from " +
                    "Hco_Integrante h INNER JOIN equipo e " +
                    "on h.cod_equipo=e.cod_equipo and h.cod_integrante=" + cod_Integrante;



                 command.Prepare();

                 dataReader = command.ExecuteReader();



                 if (!dataReader.Read())
                 {
                     throw new InstanceNotFoundException(1, "hcoint");

                 }

                 var historial = new List<HistorialEquiposCO>();


                 do
                 {
                     String nombre = dataReader.GetString(0);
                     DateTime fecha_Inicio = dataReader.GetDateTime(1);

                     DateTime fecha_Fin ;
                     if (dataReader.GetValue(2)==DBNull.Value) fecha_Fin=DateTime.MinValue;
                     else fecha_Fin = dataReader.GetDateTime(2);

                   

                     historial.Add(new HistorialEquiposCO(nombre,fecha_Inicio,fecha_Fin));
                 }
                 while (dataReader.Read());

                 return historial;
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);
             }
             finally { dataReader.Close(); }
         }


         public HcoIntegranteVO updateHcoIntegrante(DbConnection connection,
             DbTransaction transaction, HcoIntegranteVO hcoIntegranteVO)
         {
             try
             {
                 DbCommand command = connection.CreateCommand();

                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }


                 command.CommandText = "UPDATE Hco_Integrante SET "+
                     "fecha_Inicio=@fecha_Inicio,"+
                     "fecha_Fin=@fecha_Fin,fecha_Fin_Contrato=@fecha_Fin_Contrato,"+
                     "sueldo=@sueldo,dorsal=@dorsal WHERE "+
                     "cod_Integrante=@cod_Int AND cod_Equipo=@cod_Equipo "+
                     "AND version_integrante=@version_integrante";
                   

                 DbParameter cod_IntParam = command.CreateParameter();
                 cod_IntParam.ParameterName = "@cod_Int";
                 cod_IntParam.DbType = DbType.Int32;
                 cod_IntParam.Value = hcoIntegranteVO.Cod_Integrante;
                 cod_IntParam.Size = 20;
                 command.Parameters.Add(cod_IntParam);


                 DbParameter cod_EquipoParam = command.CreateParameter();
                 cod_EquipoParam.ParameterName = "@cod_Equipo";
                 cod_EquipoParam.DbType = DbType.Int32;
                 cod_EquipoParam.Value = hcoIntegranteVO.Cod_Equipo;
                 cod_EquipoParam.Size = 20;
                 command.Parameters.Add(cod_EquipoParam);



                 DbParameter version_integranteParam = command.CreateParameter();
                 version_integranteParam.ParameterName = "@version_integrante";
                 version_integranteParam.DbType = DbType.Int32;
                 version_integranteParam.Value = hcoIntegranteVO.Version_Integrante;
                 version_integranteParam.Size = 20;
                 command.Parameters.Add(version_integranteParam);


                 DbParameter fecha_InicioParam = command.CreateParameter();
                 fecha_InicioParam.ParameterName = "@fecha_Inicio";
                 fecha_InicioParam.DbType = DbType.DateTime;
                 fecha_InicioParam.Value = hcoIntegranteVO.Fecha_Inicio;
                 fecha_InicioParam.Size = 100;
                 command.Parameters.Add(fecha_InicioParam);


                 DbParameter fecha_FinParam = command.CreateParameter();
                 fecha_FinParam.ParameterName = "@fecha_Fin";
                 fecha_FinParam.DbType = DbType.DateTime;
                 if (hcoIntegranteVO.Fecha_Fin == DateTime.MinValue) fecha_FinParam.Value = DBNull.Value;
                 else fecha_FinParam.Value = hcoIntegranteVO.Fecha_Fin;
                 fecha_FinParam.Size = 100;
                 command.Parameters.Add(fecha_FinParam);


                 DbParameter fecha_Fin_ContratoParam = command.CreateParameter();
                 fecha_Fin_ContratoParam.ParameterName = "@fecha_Fin_Contrato";
                 fecha_Fin_ContratoParam.DbType = DbType.DateTime;
                 fecha_Fin_ContratoParam.Value = hcoIntegranteVO.Fecha_Fin_Contrato;
                 fecha_Fin_ContratoParam.Size = 100;
                 command.Parameters.Add(fecha_Fin_ContratoParam);


                 DbParameter sueldoParam = command.CreateParameter();
                 sueldoParam.ParameterName = "@sueldo";
                 sueldoParam.DbType = DbType.Int32;
                 sueldoParam.Value = hcoIntegranteVO.Sueldo;
                 sueldoParam.Size = 20;
                 command.Parameters.Add(sueldoParam);


                 DbParameter dorsalParam = command.CreateParameter();
                 dorsalParam.ParameterName = "@dorsal";
                 dorsalParam.DbType = DbType.Int32;
                 dorsalParam.Value = hcoIntegranteVO.Dorsal;
                 dorsalParam.Size = 20;
                 command.Parameters.Add(dorsalParam);



                 command.Prepare();

                 int insertedRows = command.ExecuteNonQuery();



                 if (insertedRows == 0)
                 {
                     throw new SQLException("errorrrrrrr");
                 }

                 return hcoIntegranteVO;
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);

             }

         }
    

         public List<HcoIntegranteVO> obtenerListaHcoIntegranteVO(DbConnection connection, 
             DbTransaction transaction,int cod_Integrante)
         {
             DbDataReader dataReader = null;

             try
             {

                 DbCommand command = connection.CreateCommand();
                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }


                 command.CommandText = "SELECT cod_equipo,version_integrante,fecha_inicio," +
                     "fecha_fin,fecha_fin_contrato,sueldo,dorsal FROM hco_integrante " +
                     "WHERE cod_integrante=" + cod_Integrante+" ORDER BY version_integrante";



                 command.Prepare();

                 dataReader = command.ExecuteReader();



                 if (!dataReader.Read())
                 {
                     throw new InstanceNotFoundException(1, "hcoint");
                 }

                 var historial = new List<HcoIntegranteVO>();
                 

                 do
                 {
                     int cod_Equipo = dataReader.GetInt32(0);
                     
                     int versionIntegrante = dataReader.GetInt32(1);
                     
                     DateTime fecha_Inicio = dataReader.GetDateTime(2);
                     
                     DateTime fecha_Fin ;
                     if (dataReader.GetValue(3)==DBNull.Value) fecha_Fin=DateTime.MinValue;
                     else fecha_Fin = dataReader.GetDateTime(3);
                     
                     DateTime fechaFinContrato = dataReader.GetDateTime(4);
                     int sueldo = (int)dataReader.GetFloat(5);
                     
                     int dorsal = dataReader.GetInt32(6);



                     historial.Add(new HcoIntegranteVO(cod_Integrante, cod_Equipo,versionIntegrante, fecha_Inicio,
                         fecha_Fin, fechaFinContrato, sueldo, dorsal));
                 }
                 while (dataReader.Read());

                 return historial;
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);
             }
             finally { dataReader.Close(); }

         }
     
     }
}
