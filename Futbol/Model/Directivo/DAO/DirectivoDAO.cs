using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;

using Futbol.Model.Directivo.VO;
using System.Data;
using System.Data.Common;

namespace Futbol.Model.Directivo.DAO
{
    public class DirectivoDAO
    {


         public DirectivoVO create(DbConnection connection, DbTransaction transaction, DirectivoVO directivoVO)
         {
             try
             {
                 DbCommand command = connection.CreateCommand();

                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }

                 command.CommandText = "INSERT INTO Directivo (cod_Integrante,cod_Equipo,version_Integrante,cargo,profesion) "+
                     "values (@cod_Integrante,@cod_Equipo,@version_Integrante,@cargo,@profesion)";

                 DbParameter cod_IntegranteParam = command.CreateParameter();
                 cod_IntegranteParam.ParameterName = "@cod_Integrante";
                 cod_IntegranteParam.DbType = DbType.Int32;
                 cod_IntegranteParam.Value = directivoVO.Cod_Integrante;
                 cod_IntegranteParam.Size = 32;
                 command.Parameters.Add(cod_IntegranteParam);


                 DbParameter cod_EquipoParam = command.CreateParameter();
                 cod_EquipoParam.ParameterName = "@cod_Equipo";
                 cod_EquipoParam.DbType = DbType.Int32;
                 cod_EquipoParam.Value = directivoVO.Cod_Equipo;
                 cod_EquipoParam.Size = 32;
                 command.Parameters.Add(cod_EquipoParam);


                 DbParameter version_IntegranteParam = command.CreateParameter();
                 version_IntegranteParam.ParameterName = "@version_Integrante";
                 version_IntegranteParam.DbType = DbType.Int32;
                 version_IntegranteParam.Value = directivoVO.Version_Integrante;
                 version_IntegranteParam.Size = 32;
                 command.Parameters.Add(version_IntegranteParam);


                 DbParameter cargoParam = command.CreateParameter();
                 cargoParam.ParameterName = "@cargo";
                 cargoParam.DbType = DbType.String;
                 cargoParam.Size = 50;
                 if (directivoVO.Cargo == null) cargoParam.Value = DBNull.Value;
                 else cargoParam.Value = directivoVO.Cargo;
                 command.Parameters.Add(cargoParam);


                 DbParameter profesionParam = command.CreateParameter();
                 profesionParam.ParameterName = "@profesion";
                 profesionParam.DbType = DbType.String;
                 profesionParam.Size = 30;
                 profesionParam.Value = directivoVO.Profesion;
                 command.Parameters.Add(profesionParam);

                 
                 
                 command.Prepare();
                  
                 int insertedRows = command.ExecuteNonQuery();
                 
                 if (insertedRows == 0)
                 {
                     
                     throw new SQLException("errorrrrrrr");
                 }
                 
                 IDirectivoIdentifierRetriever directivoIdentifierRetriever = DirectivoIdentifierRetrieverFactory.GetRetriever();

                 Int64 directivoIdentifier = directivoIdentifierRetriever.GetGeneratedIdentifier(connection,transaction);
                 
                 
                 return new DirectivoVO((int)directivoIdentifier, directivoVO.Cod_Integrante,directivoVO.Cod_Equipo,
                     directivoVO.Version_Integrante, directivoVO.Cargo, directivoVO.Profesion);
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);

             }
         }
         
   

         public List<DirectivoPlantillaCO> verDirectivosEquipo(DbConnection connection, DbTransaction transaction, int cod_Equipo,
   int startIndex, int count)
         {
             DbDataReader dataReader = null;

             try
             {
                 DbCommand command = connection.CreateCommand();
                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }

                 command.CommandText = "SELECT di.cod_directivo,i.nombre,i.apellidos,i.fecha_nac,di.cargo," +
                     "i.foto from directivo di INNER JOIN hco_integrante h on " +
                    "(di.cod_equipo=" + cod_Equipo + " and h.cod_equipo=di.cod_equipo and di.cod_integrante=h.cod_integrante AND h.fecha_fin is null) " +
                    "INNER JOIN integrante i ON (i.cod_int=h.cod_integrante)";
                 command.Prepare();

                 dataReader = command.ExecuteReader();

                 
                 if (!dataReader.Read())
                 {
                   //  throw new InstanceNotFoundException(1, "directuvi");
                     return null;
                 }

                 var directivos = new List<DirectivoPlantillaCO>();
                 

                 do
                 {
                     int cod_Directivo = dataReader.GetInt32(0);
                     String nombre = dataReader.GetString(1);
                     String apellidos = dataReader.GetString(2);
                     DateTime fechaNac= dataReader.GetDateTime(3);

                     String cargo = dataReader.GetString(4);
                     String foto;
                     if (dataReader.GetValue(5) == DBNull.Value) foto = null;
                     else foto = dataReader.GetString(5);

                     directivos.Add(new DirectivoPlantillaCO(cod_Directivo,nombre, apellidos,fechaNac,cargo,foto));
                 }
                 while (dataReader.Read());
                 
                 return directivos;
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);
             }
             finally { dataReader.Close(); }
         }



        public DirectivoVO obtenerDirectivoVO(DbConnection connection, DbTransaction transaction, int cod_Integrante,
           int cod_Equipo, int version_Integrante)
        {
            DbDataReader dataReader = null;

            try
            {

                DbCommand command = connection.CreateCommand();
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }


                command.CommandText = "SELECT * from Directivo WHERE cod_Integrante=" + cod_Integrante +
                    " AND cod_equipo=" + cod_Equipo + " AND version_integrante=" + version_Integrante;



                command.Prepare();

                dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                {
                    // throw new InstanceNotFoundException(1, "entrenador");
                    return null;
                }

                int cod_Directivo = dataReader.GetInt32(0);
                String cargo = dataReader.GetString(4);
                String profesion = dataReader.GetString(5);



                return new DirectivoVO(cod_Directivo, cod_Integrante, cod_Equipo, version_Integrante,
                    cargo, profesion);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }



        }



        public DirectivoVO updateDirectivo(DbConnection connection, DbTransaction transaction,
    DirectivoVO directivoVO)
        {
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "UPDATE Directivo SET " +
                "cargo=@cargo,profesion=@profesion " +
                "WHERE cod_Integrante=@cod_Integrante AND cod_Equipo=@cod_Equipo " +
                "AND version_Integrante=@version_Integrante";

                DbParameter cod_IntegranteParam = command.CreateParameter();
                cod_IntegranteParam.ParameterName = "@cod_Integrante";
                cod_IntegranteParam.DbType = DbType.Int32;
                cod_IntegranteParam.Value = directivoVO.Cod_Integrante;
                cod_IntegranteParam.Size = 32;
                command.Parameters.Add(cod_IntegranteParam);


                DbParameter cod_EquipoParam = command.CreateParameter();
                cod_EquipoParam.ParameterName = "@cod_Equipo";
                cod_EquipoParam.DbType = DbType.Int32;
                cod_EquipoParam.Value = directivoVO.Cod_Equipo;
                cod_EquipoParam.Size = 32;
                command.Parameters.Add(cod_EquipoParam);


                DbParameter version_IntegranteParam = command.CreateParameter();
                version_IntegranteParam.ParameterName = "@version_Integrante";
                version_IntegranteParam.DbType = DbType.Int32;
                version_IntegranteParam.Value = directivoVO.Version_Integrante;
                version_IntegranteParam.Size = 32;
                command.Parameters.Add(version_IntegranteParam);


                DbParameter cargoParam = command.CreateParameter();
                cargoParam.ParameterName = "@cargo";
                cargoParam.DbType = DbType.String;
                cargoParam.Size = 50;
                if (directivoVO == null) cargoParam.Value = DBNull.Value;
                else cargoParam.Value = directivoVO.Cargo;
                command.Parameters.Add(cargoParam);


                DbParameter profesionParam = command.CreateParameter();
                profesionParam.ParameterName = "@profesion";
                profesionParam.DbType = DbType.DateTime;
                profesionParam.Size = 50;
                if (directivoVO.Profesion == null) profesionParam.Value = DBNull.Value;
                else profesionParam.Value = directivoVO.Profesion;
                command.Parameters.Add(profesionParam);

                command.Prepare();

                int insertedRows = command.ExecuteNonQuery();

                if (insertedRows == 0)
                {

                    throw new SQLException("errorrrrrrr");
                }

                return directivoVO;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }








/*
         public DatosTotalesEntrenador verEntrenador(DbConnection connection, DbTransaction transaction, int cod_Entrenador)
         {

             DbDataReader dataReader = null;

             try
             {

                 DbCommand command = connection.CreateCommand();
                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }

                 command.CommandText = "SELECT i.nombre,i.apellidos,i.fecha_nac,en.cargo,en.fecha_profesional,h.sueldo,h.fecha_fin_contrato,"+
                     "i.foto from entrenador en INNER JOIN hco_integrante h on (en.cod_entrenador="+cod_Entrenador+" and h.cod_equipo=en.cod_equipo and "+
                     "en.cod_integrante=h.cod_integrante) INNER JOIN integrante i ON (i.cod_int=h.cod_integrante)";



                 command.Prepare();

                 dataReader = command.ExecuteReader();

                 if (!dataReader.Read())
                 {
                     throw new InstanceNotFoundException(1, "algo");

                 }

                 String nombre = dataReader.GetString(0);
                 String apellidos = dataReader.GetString(1);
                 DateTime fecha_Nacimiento = dataReader.GetDateTime(2);
                 String cargo = dataReader.GetString(3);
                 DateTime fechaProfesional = dataReader.GetDateTime(4);
                 Int32 sueldo = (Int32) dataReader.GetFloat(5);
                 DateTime fecha_Fin_Contrato;
                 if (dataReader.GetValue(6) == DBNull.Value) fecha_Fin_Contrato = DateTime.MinValue;
                 else  fecha_Fin_Contrato= dataReader.GetDateTime(6);
                 String foto=null;
                 if (dataReader.GetValue(7)!=DBNull.Value) foto=dataReader.GetString(7);


                 return new DatosTotalesEntrenador(nombre, apellidos, fecha_Nacimiento,
                     foto, cargo, fechaProfesional, sueldo, fecha_Fin_Contrato);
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);
             }
             finally { dataReader.Close(); }
         }
*/
    }
}
