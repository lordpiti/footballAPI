using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;

using Futbol.Model.Competicion.VO;
using System.Data;
using System.Data.Common;
using Futbol.Model.FachadaPartidos.COs;


namespace Futbol.Model.Competicion.DAO
{
    public class CompeticionDAO
    {



        public CompeticionVO create(DbConnection connection, DbTransaction transaction, CompeticionVO competicionVO)
        {
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "INSERT INTO Competicion (nombre,temporada,Fecha_Inicio,Fecha_Fin,Campeon,Foto,Tipo) "+
                    "values (@nombre,@temporada,@fecha_Inicio,@fecha_Fin,@campeon,@foto,@tipo)";
                
                DbParameter nombreParam = command.CreateParameter();
                nombreParam.ParameterName = "@nombre";
                nombreParam.DbType = DbType.String;
                nombreParam.Value = competicionVO.Nombre;
                nombreParam.Size = 50;
                command.Parameters.Add(nombreParam);


                DbParameter temporadaParam = command.CreateParameter();
                temporadaParam.ParameterName = "@temporada";
                temporadaParam.DbType = DbType.String;
                temporadaParam.Value = competicionVO.Temporada;
                temporadaParam.Size = 20;
                command.Parameters.Add(temporadaParam);


                DbParameter fecha_InicioParam = command.CreateParameter();
                fecha_InicioParam.ParameterName = "@fecha_Inicio";
                fecha_InicioParam.DbType = DbType.DateTime;
                fecha_InicioParam.Value = competicionVO.Fecha_Inicio;
                fecha_InicioParam.Size = 30;
                command.Parameters.Add(fecha_InicioParam);
                

                DbParameter fecha_FinParam = command.CreateParameter();
                fecha_FinParam.ParameterName = "@fecha_Fin";
                fecha_FinParam.DbType = DbType.DateTime;
                fecha_FinParam.Size = 50;
                if (competicionVO.Fecha_Fin == DateTime.MinValue)
                { fecha_FinParam.Value = DBNull.Value; }
                else fecha_FinParam.Value = competicionVO.Fecha_Fin;

                command.Parameters.Add(fecha_FinParam);



                DbParameter campeonParam = command.CreateParameter();
                campeonParam.ParameterName = "@campeon";
                campeonParam.DbType = DbType.String;
                campeonParam.Size = 20;
                if (competicionVO.Campeon == null) campeonParam.Value = DBNull.Value;
                else campeonParam.Value = competicionVO.Campeon;
                command.Parameters.Add(campeonParam);


                DbParameter fotoParam = command.CreateParameter();
                fotoParam.ParameterName = "@foto";
                fotoParam.DbType = DbType.String;
                fotoParam.Value = competicionVO.Foto;
                fotoParam.Size = 100;
                command.Parameters.Add(fotoParam);


                DbParameter tipoParam = command.CreateParameter();
                tipoParam.ParameterName = "@tipo";
                tipoParam.DbType = DbType.String;
                tipoParam.Value = competicionVO.Tipo;
                tipoParam.Size = 20;
                command.Parameters.Add(tipoParam);





                command.Prepare();
                int insertedRows = command.ExecuteNonQuery();
                

                if (insertedRows == 0)
                {
                    throw new SQLException("errorrrrrrr");
                }
                
                ICompeticionIdentifierRetriever competicionIdentifierRetriever = CompeticionIdentifierRetrieverFactory.GetRetriever();
                Int64 competicionIdentifier = competicionIdentifierRetriever.GetGeneratedIdentifier(connection,transaction);



                return new CompeticionVO((int)competicionIdentifier, competicionVO.Nombre, competicionVO.Temporada, 
                    competicionVO.Fecha_Inicio,competicionVO.Fecha_Fin, competicionVO.Campeon,
                    competicionVO.Foto,competicionVO.Tipo);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }



        }

        
        
        public List<CompeticionVO> listarCompeticiones(DbConnection connection, DbTransaction transaction,
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


                command.CommandText =
                    /*    "SELECT top " + count + "cod_estadio,capacidad,direccion,tipo,foto" +
                        "FROM estadio WHERE cod_estadio not in" +
                        "(select top" + startIndex + "cod_estadio from estadio order by cod_estadio) order by cod_estadio;";

                    */
                "SELECT * from competicion";
                command.Prepare();
                
                dataReader = command.ExecuteReader();
                if (!dataReader.Read())
                {
                  //  throw new InstanceNotFoundException(1, "competicion");
                    return null;
                }

                var competiciones = new List<CompeticionVO>();
                
                do
                {
                    int cod_competicion = dataReader.GetInt32(0);
                    String nombre = dataReader.GetString(1);
                    String temporada = dataReader.GetString(2);
                    DateTime fecha_Inicio = dataReader.GetDateTime(3);
                    DateTime fecha_Fin = dataReader.GetDateTime(4);
                    //aqui hay q añadir el caso de nuLL
                    String campeon = dataReader.GetString(5);
                    String foto = dataReader.GetString(6);
                    String tipo = dataReader.GetString(7);

                    competiciones.Add(new CompeticionVO(cod_competicion, nombre,
                        temporada, fecha_Inicio, fecha_Fin,campeon,foto,tipo));
                }
                while (dataReader.Read());
                
                /*no se si hay q poner el close*/
                
                dataReader.Close();
                
                return competiciones;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }



        public CompeticionVO buscarCompeticionId(DbConnection connection, DbTransaction transaction, int id_Competicion)
        {

            DbDataReader dataReader = null;

            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT * FROM Competicion where cod_competicion=" + id_Competicion;
                command.Prepare();



                dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                {
                 //   throw new InstanceNotFoundException(1, "competicion");
                    return null;


                }


                int cod_competicion = dataReader.GetInt32(0);
                String nombre = dataReader.GetString(1);
                String temporada = dataReader.GetString(2);
                DateTime fecha_Inicio = dataReader.GetDateTime(3);
                DateTime fecha_Fin = Convert.ToDateTime(dataReader.GetValue(4));
                String campeon = Convert.ToString(dataReader.GetValue(5));
                String foto = dataReader.GetString(6);
                String tipo = dataReader.GetString(7);

                dataReader.Close();

                return new CompeticionVO(cod_competicion, nombre, temporada,
                    fecha_Inicio, fecha_Fin, campeon, foto, tipo);
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






        public List<CompeticionConNombreCO> buscarCompeticionesTemporada(DbConnection connection, DbTransaction transaction,
            String temporada)
        {

            DbDataReader dataReader = null;

            try
            {

                DbCommand command = connection.CreateCommand();
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                if (temporada == "Todas")
                {
                    command.CommandText =
                        "SELECT cod_competicion,nombre from competicion";

                }
                else
                command.CommandText =
                "SELECT cod_competicion,nombre from competicion where temporada='"+temporada+"'";
                command.Prepare();

                dataReader = command.ExecuteReader();
                if (!dataReader.Read())
                {
                   // throw new InstanceNotFoundException(1, "competicion");
                       return null;
                }

                var competiciones = new List<CompeticionConNombreCO>();

                do
                {
                    Int32 cod_Competicion = dataReader.GetInt32(0);
                    String nombre = dataReader.GetString(1);

                    CompeticionConNombreCO competicion= new CompeticionConNombreCO(cod_Competicion, nombre, "", "", temporada, "");

                    competiciones.Add(competicion);
                }
                while (dataReader.Read());

                return competiciones;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }



        public List<string> buscarTemporadas(DbConnection connection, DbTransaction transaction)
        {

            DbDataReader dataReader = null;

            try
            {

                DbCommand command = connection.CreateCommand();
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }


                command.CommandText =
                "SELECT distinct temporada from competicion";
                command.Prepare();

                dataReader = command.ExecuteReader();
                if (!dataReader.Read())
                {
                    throw new InstanceNotFoundException(1, "competicion");
                    //   return null;
                }

                var competiciones = new List<string>();

                do
                {
                    var temporada = dataReader.GetString(0);

                    competiciones.Add(temporada);
                }
                while (dataReader.Read());

                return competiciones;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }


    }
}
