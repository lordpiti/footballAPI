using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;

using Futbol.Model.Arbitro.VO;
using Futbol.Model.Partido;
using System.Data;
using System.Data.Common;

namespace Futbol.Model.Arbitro.DAO
{
     public class ArbitroDAO
    {


         public ArbitroVO create(DbConnection connection, DbTransaction transaction,
             ArbitroVO arbitroVO)
         {
             try
             {
                 DbCommand command = connection.CreateCommand();

                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }
                 
                 command.CommandText = "INSERT INTO Arbitro (nombre,apellidos,anos_activo,colegio,foto)"+
                     "values (@nombre,@apellidos,@anos_activo,@colegio,@foto)";

                 DbParameter nombreParam = command.CreateParameter();
                 nombreParam.ParameterName = "@nombre";
                 nombreParam.DbType = DbType.String;
                 nombreParam.Value = arbitroVO.Nombre;
                 nombreParam.Size = 20;
                 command.Parameters.Add(nombreParam);


                 DbParameter apellidosParam = command.CreateParameter();
                 apellidosParam.ParameterName = "@apellidos";
                 apellidosParam.DbType = DbType.String;
                 apellidosParam.Value = arbitroVO.Apellidos;
                 apellidosParam.Size = 30;
                 command.Parameters.Add(apellidosParam);

                 DbParameter anos_activoParam = command.CreateParameter();
                 anos_activoParam.ParameterName = "@anos_activo";
                 anos_activoParam.DbType = DbType.Int32;
                 anos_activoParam.Value = arbitroVO.Anos_Activo;
                 anos_activoParam.Size = 100;
                 command.Parameters.Add(anos_activoParam);


                 DbParameter colegioParam = command.CreateParameter();
                 colegioParam.ParameterName = "@colegio";
                 colegioParam.DbType = DbType.String;
                 colegioParam.Value = arbitroVO.Colegio;
                 colegioParam.Size = 30;
                 command.Parameters.Add(colegioParam);
                 

                 DbParameter fotoParam = command.CreateParameter();
                 fotoParam.ParameterName = "@foto";
                 fotoParam.DbType = DbType.String;
                 fotoParam.Size = 50;
                 if (arbitroVO.Foto == null) fotoParam.Value = DBNull.Value;
                 else fotoParam.Value = arbitroVO.Foto;
                 
                 command.Parameters.Add(fotoParam);

                 command.Prepare();
                 
                 int insertedRows = command.ExecuteNonQuery();
                
                 if (insertedRows == 0)
                 {
                     throw new SQLException("errorrrrrrr");
                 }

                 IArbitroIdentifierRetriever arbitroIdentifierRetriever = ArbitroIdentifierRetrieverFactory.GetRetriever();

                 Int64 arbitroIdentifier = arbitroIdentifierRetriever.GetGeneratedIdentifier(connection);

                 return new ArbitroVO((int)arbitroIdentifier, arbitroVO.Nombre, arbitroVO.Apellidos,
                     arbitroVO.Colegio,arbitroVO.Anos_Activo, arbitroVO.Foto);
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);

             }
         }
         
         
         

         
         public ArbitroVO verArbitro(DbConnection connection, DbTransaction transaction,int cod_Arbitro)
        {

            DbDataReader dataReader = null;

            try
            {

                DbCommand command = connection.CreateCommand();
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }


                command.CommandText = "SELECT * from Arbitro where Cod_Arbitro="+cod_Arbitro;
                command.Prepare();

                dataReader = command.ExecuteReader();

                
                if (!dataReader.Read())
                {
                    throw new InstanceNotFoundException(1, "arbitro");

                }


                    
                    String nombre = dataReader.GetString(1);
                    String apellidos = dataReader.GetString(2);
                    String colegio = dataReader.GetString(3);
                    int anos_Activo = dataReader.GetInt32(4);
                    String foto=null;
                    if (dataReader.GetValue(5) != DBNull.Value)
                        foto = dataReader.GetString(5);




                    return new ArbitroVO(cod_Arbitro, nombre, apellidos, colegio, anos_Activo, foto);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }




         public bool Exists(DbConnection connection,
             DbTransaction transaction, int cod_Arbitro)
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
                     "SELECT Cod_Arbitro FROM Arbitro " +
                     "WHERE Cod_Arbitro = " + cod_Arbitro;
                 

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



         public ArrayList buscarPartidosArbitro(DbConnection connection, DbTransaction transaction,
    int cod_Arbitro)
         {
             DbDataReader dataReader = null;

             try
             {
                 DbCommand command = connection.CreateCommand();
                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }




                 command.CommandText = "SELECT p.cod_Partido,e1.nombre,e2.nombre,"+
                     "p.goles_local,p.goles_visitante,c.temporada,c.nombre,c.cod_Competicion,p.jornada " +
                     "from partido p join equipo e1 " +
                        "on (p.cod_arbitro="+cod_Arbitro+" and e1.cod_equipo=p.cod_local) join equipo e2 " +
                        "on (p.cod_visitante=e2.cod_equipo) join competicion c " +
                        "on (p.cod_competicion=c.cod_competicion)";


                 command.Prepare();

                 dataReader = command.ExecuteReader();



                 if (!dataReader.Read())
                 {
                     //  throw new InstanceNotFoundException(1, "algo");
                     return null;

                 }

                 ArrayList partidosJugadosCompeticionJugador = new ArrayList();

                 do
                 {
                     Int32 cod_Partido = dataReader.GetInt32(0);
                     String nombreLocal = dataReader.GetString(1);
                     String nombreVisitante = dataReader.GetString(2);
                     Int32 golesLocal = dataReader.GetInt32(3);
                     Int32 golesVisitante = dataReader.GetInt32(4);
                     String temporada = dataReader.GetString(5);
                     String nombreCompeticion = dataReader.GetString(6);
                     Int32 cdComp = dataReader.GetInt32(7);
                     String jor = dataReader.GetString(8);

                     partidosJugadosCompeticionJugador.Add(
                         new PartidoCompeticionJornadaCO(cod_Partido, nombreLocal,
                         nombreVisitante, golesLocal, golesVisitante, temporada, nombreCompeticion, cdComp, jor));


                 }
                 while (dataReader.Read());


                 return partidosJugadosCompeticionJugador;
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);
             }
             finally { dataReader.Close(); }


         }


    }
}
