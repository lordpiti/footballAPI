using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;

using Futbol.Model.Gol.VO;
using System.Data;
using System.Data.Common;



namespace Futbol.Model.Gol.DAO
{
    public class GolDAO
    {


        public GolVO create(DbConnection connection, DbTransaction transaction, GolVO golVO)
        {
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "INSERT INTO Gol (cod_Partido,cod_Jugador,minuto,tipo,video) "+
                    "values (@cod_Partido,@cod_Jugador,@minuto,@tipo,@video)";

                DbParameter cod_PartidoParam = command.CreateParameter();
                cod_PartidoParam.ParameterName = "@cod_Partido";
                cod_PartidoParam.DbType = DbType.Int32;
                cod_PartidoParam.Value = golVO.Cd_Partido;
                cod_PartidoParam.Size = 32;
                command.Parameters.Add(cod_PartidoParam);


                DbParameter cod_JugadorParam = command.CreateParameter();
                cod_JugadorParam.ParameterName = "@cod_Jugador";
                cod_JugadorParam.DbType = DbType.Int32;
                cod_JugadorParam.Value = golVO.Cd_Jugador;
                cod_JugadorParam.Size = 32;
                command.Parameters.Add(cod_JugadorParam);


                DbParameter minutoParam = command.CreateParameter();
                minutoParam.ParameterName = "@minuto";
                minutoParam.DbType = DbType.Int32;
                minutoParam.Value = golVO.Minuto;
                minutoParam.Size = 32;
                command.Parameters.Add(minutoParam);


                DbParameter tipoParam = command.CreateParameter();
                tipoParam.ParameterName = "@tipo";
                tipoParam.DbType = DbType.String;
                tipoParam.Value = golVO.Tipo;
                tipoParam.Size = 20;
                command.Parameters.Add(tipoParam);


                DbParameter videoParam = command.CreateParameter();
                videoParam.ParameterName = "@video";
                videoParam.DbType = DbType.String;
                videoParam.Value = golVO.Video;
                videoParam.Size = 100;
                command.Parameters.Add(videoParam);



                command.Prepare();
                int insertedRows = command.ExecuteNonQuery();
                
                if (insertedRows == 0)
                {            
                    throw new SQLException("errorrrrrrr");
                }

                IGolIdentifierRetriever golIdentifierRetriever = GolIdentifierRetrieverFactory.GetRetriever();
                Int64 golIdentifier = golIdentifierRetriever.GetGeneratedIdentifier(connection,transaction);

                return new GolVO((int)golIdentifier, golVO.Cd_Partido, golVO.Cd_Jugador, 
                    golVO.Minuto, golVO.Tipo,golVO.Video);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }

        
        
        public ArrayList listarGolesEquipoPartido(DbConnection connection, DbTransaction transaction,
            int cod_Partido, int cod_Equipo,int startIndex, int count)
        {
            DbDataReader dataReader = null;
            
            try
            {
                DbCommand command = connection.CreateCommand();
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT gol.cod_gol,ju.Cod_Jugador, " +
                    "int.Nombre, int.Apellidos,gol.minuto,gol.tipo,gol.video " +
                    "FROM Integrante AS int INNER JOIN " +
                    "Hco_Integrante AS hi ON int.Cod_Int = hi.Cod_Integrante INNER JOIN " +
                    "Jugador AS ju ON hi.Cod_Integrante = ju.Cod_Integrante AND hi.Cod_Equipo = ju.Cod_Equipo AND " +
                    "ju.cod_equipo=" + cod_Equipo + " and hi.Version_Integrante = ju.Version_Integrante INNER JOIN " +
                    "gol ON gol.Cod_Jugador = ju.Cod_Jugador and gol.cod_partido=" + cod_Partido;



                command.Prepare();
                
                dataReader = command.ExecuteReader();
                if (!dataReader.Read())
                {
                    return null;
                    //  throw new InstanceNotFoundException(1, "algo");

                }

                ArrayList goles = new ArrayList();
                
                do
                {
                    int cod_Gol = dataReader.GetInt32(0);
                    int cod_Jugador = dataReader.GetInt32(1);
                    String nombre = dataReader.GetString(2);
                    String apellidos = dataReader.GetString(3);
                    int minuto = dataReader.GetInt32(4);
                    String tipo = dataReader.GetString(5);
                    String video = null;
                    if (dataReader.GetValue(6)!=DBNull.Value)
                        video= dataReader.GetString(6);

                    goles.Add(new GolCO(cod_Partido,cod_Gol,cod_Jugador,tipo,minuto,nombre,apellidos,video));
                    
                }
                while (dataReader.Read());
   
                return goles;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }



        public GolVO buscarGolId(DbConnection connection, DbTransaction transaction, int id_Gol)
        {
            DbDataReader dataReader = null;
            
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT * FROM Gol where cod_Gol=" + id_Gol;
                command.Prepare();
                dataReader = command.ExecuteReader();
                
                if (!dataReader.Read())
                {
                    throw new InstanceNotFoundException(1, "gol");

                }
                
                int cod_Gol = dataReader.GetInt32(0);
                int cod_Partido = dataReader.GetInt32(1);
                int cod_Jugador = dataReader.GetInt32(2);
                int minuto = dataReader.GetInt32(3);
                String tipo = dataReader.GetString(4);
                String video = dataReader.GetString(5);

                dataReader.Close();

                return new GolVO(cod_Gol, cod_Partido, cod_Jugador, minuto, tipo,video);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }


        public ArrayList listarGoleadoresCompeticion(DbConnection connection, DbTransaction transaction,
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

                command.CommandText = "select top 5 integrante.nombre,integrante.apellidos,equipo.Nombre,integrante.Cod_Int,equipo.cod_Equipo,count(*) as numeroGoles from gol " +
                            "join jugador on gol.cod_Jugador=jugador.cod_Jugador " +
                            "join integrante on jugador.cod_Integrante=Integrante.cod_Int " +
                            "join equipo on jugador.cod_Equipo=equipo.cod_Equipo " +
                            "where gol.cod_Partido in (select cod_Partido from partido where cod_Competicion="+cod_Competicion+") " +
                            "group by integrante.nombre,integrante.apellidos,jugador.cod_Integrante,equipo.Nombre,"+
                            "integrante.Cod_Int,equipo.cod_Equipo order by numeroGoles desc";



                command.Prepare();

                dataReader = command.ExecuteReader();
                if (!dataReader.Read())
                {
                    return null;
                    //  throw new InstanceNotFoundException(1, "goleadorescompeticion");

                }

                ArrayList goleadores = new ArrayList();

                do
                {
                    String nombre = dataReader.GetString(0);
                    String apellidos = dataReader.GetString(1);
                    String equipo = dataReader.GetString(2);
                    int numeroGoles = dataReader.GetInt32(5);
                    int cod_Integrante = dataReader.GetInt32(3);
                    int cod_Equipo = dataReader.GetInt32(4);

                    goleadores.Add(new GoleadorCO(nombre + " " + apellidos, equipo, numeroGoles,
                        cod_Equipo,cod_Integrante));
                }
                while (dataReader.Read());

                return goleadores;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }


    
    }
}
