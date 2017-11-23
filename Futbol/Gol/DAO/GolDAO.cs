using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Es.UDC.DotNet.Util.Exceptions;
using Es.UDC.DotNet.Util.Log;
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

                command.CommandText = "INSERT INTO Gol (cod_Partido,cod_Jugador,minuto,tipo) "+
                    "values (@cod_Partido,@cod_Jugador,@minuto,@tipo)";

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



                command.Prepare();
                int insertedRows = command.ExecuteNonQuery();
                
                if (insertedRows == 0)
                {            
                    throw new SQLException("errorrrrrrr");
                }

                IGolIdentifierRetriever golIdentifierRetriever = GolIdentifierRetrieverFactory.GetRetriever();
                Int64 golIdentifier = golIdentifierRetriever.GetGeneratedIdentifier(connection);

                return new GolVO((int)golIdentifier, golVO.Cd_Partido, golVO.Cd_Jugador, 
                    golVO.Minuto, golVO.Tipo);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }

        
        
        public ArrayList listarGoles(DbConnection connection, DbTransaction transaction,
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
                "SELECT * from gol";
                command.Prepare();
                
                dataReader = command.ExecuteReader();
                if (!dataReader.Read())
                {
                    throw new InstanceNotFoundException(1, "algo");

                }

                ArrayList goles = new ArrayList();
                
                do
                {
                    int cod_Gol = dataReader.GetInt32(0);
                    int cod_Partido = dataReader.GetInt32(1);
                    int cod_Jugador = dataReader.GetInt32(2);
                    int minuto= dataReader.GetInt32(3);
                    String tipo = dataReader.GetString(4);

                    goles.Add(new GolVO(cod_Gol, cod_Partido, cod_Jugador, minuto, tipo));
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
                    throw new InstanceNotFoundException(1, "algo");

                }
                
                int cod_Gol = dataReader.GetInt32(0);
                int cod_Partido = dataReader.GetInt32(1);
                int cod_Jugador = dataReader.GetInt32(2);
                int minuto = dataReader.GetInt32(3);
                String tipo = dataReader.GetString(4);

                dataReader.Close();

                return new GolVO(cod_Gol, cod_Partido, cod_Jugador, minuto, tipo);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }
    }
}
