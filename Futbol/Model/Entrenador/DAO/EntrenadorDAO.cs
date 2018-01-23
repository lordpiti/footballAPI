using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;

using Futbol.Model.Entrenador.VO;
using System.Data;
using System.Data.Common;

namespace Futbol.Model.Entrenador.DAO
{
    public class EntrenadorDAO
    {


         public EntrenadorVO create(DbConnection connection, DbTransaction transaction, EntrenadorVO entrenadorVO)
         {
             try
             {
                 DbCommand command = connection.CreateCommand();

                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }

                 command.CommandText = "INSERT INTO Entrenador (cod_Integrante,cod_Equipo,version_Integrante,cargo,fecha_Profesional) "+
                     "values (@cod_Integrante,@cod_Equipo,@version_Integrante,@cargo,@fechaProfesional)";

                 DbParameter cod_IntegranteParam = command.CreateParameter();
                 cod_IntegranteParam.ParameterName = "@cod_Integrante";
                 cod_IntegranteParam.DbType = DbType.Int32;
                 cod_IntegranteParam.Value = entrenadorVO.Cod_Integrante;
                 cod_IntegranteParam.Size = 32;
                 command.Parameters.Add(cod_IntegranteParam);


                 DbParameter cod_EquipoParam = command.CreateParameter();
                 cod_EquipoParam.ParameterName = "@cod_Equipo";
                 cod_EquipoParam.DbType = DbType.Int32;
                 cod_EquipoParam.Value = entrenadorVO.Cod_Equipo;
                 cod_EquipoParam.Size = 32;
                 command.Parameters.Add(cod_EquipoParam);


                 DbParameter version_IntegranteParam = command.CreateParameter();
                 version_IntegranteParam.ParameterName = "@version_Integrante";
                 version_IntegranteParam.DbType = DbType.Int32;
                 version_IntegranteParam.Value = entrenadorVO.Version_Integrante;
                 version_IntegranteParam.Size = 32;
                 command.Parameters.Add(version_IntegranteParam);


                 DbParameter cargoParam = command.CreateParameter();
                 cargoParam.ParameterName = "@cargo";
                 cargoParam.DbType = DbType.String;
                 cargoParam.Size = 50;
                 if (entrenadorVO.Cargo == null) cargoParam.Value = DBNull.Value;
                 else cargoParam.Value = entrenadorVO.Cargo;
                 command.Parameters.Add(cargoParam);


                 DbParameter fechaProfesionalParam = command.CreateParameter();
                 fechaProfesionalParam.ParameterName = "@fechaProfesional";
                 fechaProfesionalParam.DbType = DbType.DateTime;
                 fechaProfesionalParam.Size = 100;
                 fechaProfesionalParam.Value = entrenadorVO.FechaProfesional;
                 command.Parameters.Add(fechaProfesionalParam);

                 
                 
                 command.Prepare();
                  
                 int insertedRows = command.ExecuteNonQuery();
                 
                 if (insertedRows == 0)
                 {
                     
                     throw new SQLException("errorrrrrrr");
                 }
                 
                 IEntrenadorIdentifierRetriever entrenadorIdentifierRetriever = EntrenadorIdentifierRetrieverFactory.GetRetriever();

                 Int64 entrenadorIdentifier = entrenadorIdentifierRetriever.GetGeneratedIdentifier(connection,transaction);
                 
                 
                 return new EntrenadorVO((int)entrenadorIdentifier, entrenadorVO.Cod_Integrante,entrenadorVO.Cod_Equipo,
                     entrenadorVO.Version_Integrante, entrenadorVO.Cargo, entrenadorVO.FechaProfesional);
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);

             }
         }
         
   

         public ArrayList verEntrenadoresEquipo(DbConnection connection, DbTransaction transaction, int cod_Equipo,
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

                 command.CommandText = "SELECT en.cod_entrenador,i.nombre,i.apellidos,i.fecha_nac," +
                                "en.cargo,i.foto,i.cod_int from entrenador en JOIN (SELECT cod_integrante," +
                                "max(version_integrante)as maximo from hco_integrante " +
                                "where fecha_fin is null group by cod_integrante ) h " +
                                "on (en.cod_integrante=h.cod_integrante and en.version_integrante=h.maximo " +
                                "and en.cod_equipo="+cod_Equipo+") JOIN integrante i " +
                                "on h.cod_integrante=i.cod_int";
                 command.Prepare();

                 dataReader = command.ExecuteReader();

                 
                 if (!dataReader.Read())
                 {
                   //  throw new InstanceNotFoundException(1, "entrenador");
                     return null;

                 }

                 ArrayList entrenadores = new ArrayList();
                 

                 do
                 {
                     int cod_Entrenador = dataReader.GetInt32(0);
                     String nombre = dataReader.GetString(1);
                     String apellidos = dataReader.GetString(2);
                     DateTime fechaNac= dataReader.GetDateTime(3);

                     String cargo = dataReader.GetString(4);
                     String foto;
                     if (dataReader.GetValue(5) == DBNull.Value) foto = null;
                     else foto = dataReader.GetString(5);
                     int cod_Integrante = dataReader.GetInt32(6);

                     entrenadores.Add(new EntrenadorPlantillaCO(cod_Entrenador,nombre, apellidos,fechaNac,cargo,foto,cod_Integrante));
                 }
                 while (dataReader.Read());
                 
                 return entrenadores;
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);
             }
             finally { dataReader.Close(); }
         }



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
                     throw new InstanceNotFoundException(1, "entrenador");

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



        public EntrenadorVO updateEntrenador(DbConnection connection, DbTransaction transaction,
    EntrenadorVO entrenadorVO)
        {
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "UPDATE Entrenador SET " +
                "cargo=@cargo,fecha_Profesional=@fechaProfesional " +
                "WHERE cod_Integrante=@cod_Integrante AND cod_Equipo=@cod_Equipo " +
                "AND version_Integrante=@version_Integrante";

                DbParameter cod_IntegranteParam = command.CreateParameter();
                cod_IntegranteParam.ParameterName = "@cod_Integrante";
                cod_IntegranteParam.DbType = DbType.Int32;
                cod_IntegranteParam.Value = entrenadorVO.Cod_Integrante;
                cod_IntegranteParam.Size = 32;
                command.Parameters.Add(cod_IntegranteParam);


                DbParameter cod_EquipoParam = command.CreateParameter();
                cod_EquipoParam.ParameterName = "@cod_Equipo";
                cod_EquipoParam.DbType = DbType.Int32;
                cod_EquipoParam.Value = entrenadorVO.Cod_Equipo;
                cod_EquipoParam.Size = 32;
                command.Parameters.Add(cod_EquipoParam);


                DbParameter version_IntegranteParam = command.CreateParameter();
                version_IntegranteParam.ParameterName = "@version_Integrante";
                version_IntegranteParam.DbType = DbType.Int32;
                version_IntegranteParam.Value = entrenadorVO.Version_Integrante;
                version_IntegranteParam.Size = 32;
                command.Parameters.Add(version_IntegranteParam);


                DbParameter cargoParam = command.CreateParameter();
                cargoParam.ParameterName = "@cargo";
                cargoParam.DbType = DbType.String;
                cargoParam.Size = 50;
                if (entrenadorVO == null) cargoParam.Value = DBNull.Value;
                else cargoParam.Value = entrenadorVO.Cargo;
                command.Parameters.Add(cargoParam);


                DbParameter fechaProfesionalParam = command.CreateParameter();
                fechaProfesionalParam.ParameterName = "@fechaProfesional";
                fechaProfesionalParam.DbType = DbType.DateTime;
                fechaProfesionalParam.Size = 50;
               /* if (entrenadorVO.FechaProfesional == null) fechaProfesionalParam.Value = DBNull.Value;
                else*/ fechaProfesionalParam.Value = entrenadorVO.FechaProfesional;
                command.Parameters.Add(fechaProfesionalParam);

                command.Prepare();

                int insertedRows = command.ExecuteNonQuery();

                if (insertedRows == 0)
                {

                    throw new SQLException("errorrrrrrr");
                }

                return entrenadorVO;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }




        public EntrenadorVO obtenerEntrenadorVO(DbConnection connection, DbTransaction transaction, int cod_Integrante,
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


                command.CommandText = "SELECT * from Entrenador WHERE cod_Integrante=" + cod_Integrante +
                    " AND cod_equipo=" + cod_Equipo + " AND version_integrante=" + version_Integrante;



                command.Prepare();

                dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                {
                    // throw new InstanceNotFoundException(1, "entrenador");
                    return null;
                }

                int cod_Entrenador = dataReader.GetInt32(0);
                String cargo = dataReader.GetString(4);
                DateTime fechaProfesional = dataReader.GetDateTime(5);



                return new EntrenadorVO(cod_Entrenador, cod_Integrante, cod_Equipo, version_Integrante,
                    cargo, fechaProfesional);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }



        }







    }
}
