using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;

using Futbol.Model.Tarjeta.VO;
using System.Data;
using System.Data.Common;








namespace Futbol.Model.Tarjeta.DAO
{
    public class TarjetaDAO
    {


        public TarjetaVO create(DbConnection connection, DbTransaction transaction, TarjetaVO tarjetaVO)
        {
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "INSERT INTO Tarjeta (cod_Partido,cod_Jugador,minuto,tipo,motivo) "+
                    "values (@cod_Partido,@cod_Jugador,@minuto,@tipo,@motivo)";

                DbParameter cod_PartidoParam = command.CreateParameter();
                cod_PartidoParam.ParameterName = "@cod_Partido";
                cod_PartidoParam.DbType = DbType.Int32;
                cod_PartidoParam.Value = tarjetaVO.Cd_Partido;
                cod_PartidoParam.Size = 32;
                command.Parameters.Add(cod_PartidoParam);


                DbParameter cod_JugadorParam = command.CreateParameter();
                cod_JugadorParam.ParameterName = "@cod_Jugador";
                cod_JugadorParam.DbType = DbType.Int32;
                cod_JugadorParam.Value = tarjetaVO.Cd_Jugador;
                cod_JugadorParam.Size = 32;
                command.Parameters.Add(cod_JugadorParam);


                DbParameter minutoParam = command.CreateParameter();
                minutoParam.ParameterName = "@minuto";
                minutoParam.DbType = DbType.Int32;
                minutoParam.Value = tarjetaVO.Minuto;
                minutoParam.Size = 32;
                command.Parameters.Add(minutoParam);


                DbParameter tipoParam = command.CreateParameter();
                tipoParam.ParameterName = "@tipo";
                tipoParam.DbType = DbType.String;
                tipoParam.Value = tarjetaVO.Tipo;
                tipoParam.Size = 20;
                command.Parameters.Add(tipoParam);


                DbParameter motivoParam = command.CreateParameter();
                motivoParam.ParameterName = "@motivo";
                motivoParam.DbType = DbType.String;
                motivoParam.Value = tarjetaVO.Motivo;
                motivoParam.Size = 50;
                command.Parameters.Add(motivoParam);



                command.Prepare();
                int insertedRows = command.ExecuteNonQuery();
                
                if (insertedRows == 0)
                {            
                    throw new SQLException("errorrrrrrr");
                }

                ITarjetaIdentifierRetriever tarjetaIdentifierRetriever = TarjetaIdentifierRetrieverFactory.GetRetriever();
                Int64 tarjetaIdentifier = tarjetaIdentifierRetriever.GetGeneratedIdentifier(connection,transaction);

                return new TarjetaVO((int)tarjetaIdentifier, tarjetaVO.Cd_Partido, tarjetaVO.Cd_Jugador, 
                    tarjetaVO.Minuto, tarjetaVO.Tipo, tarjetaVO.Motivo);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }

        
        
        public ArrayList listarTarjetasEquipoPartido(DbConnection connection, DbTransaction transaction,
            int cod_Equipo, int cod_Partido, int startIndex, int count)
        {
            DbDataReader dataReader = null;
            
            try
            {
                DbCommand command = connection.CreateCommand();
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT j.cod_jugador,h.dorsal,i.nombre,i.apellidos,t.minuto,"+
                    "t.tipo,t.motivo FROM tarjeta t JOIN jugador j on t.cod_partido="+cod_Partido+" "+
                    "and j.cod_jugador=t.cod_jugador and j.cod_equipo="+cod_Equipo+" JOIN "+
                    "hco_integrante h on j.cod_integrante=h.cod_integrante and "+
                    "j.cod_equipo=h.cod_equipo and j.version_integrante=h.version_integrante JOIN "+
                    "integrante i on i.cod_int=h.cod_integrante order by t.minuto";



                command.Prepare();
                
                dataReader = command.ExecuteReader();
                if (!dataReader.Read())
                {
                    return null;
                }

                ArrayList tarjetas = new ArrayList();
                
                do
                {
                    int cod_Jugador = dataReader.GetInt32(0);
                    int dorsal = dataReader.GetInt32(1);
                    String nombre = dataReader.GetString(2);
                    String apellidos = dataReader.GetString(3);                   
                    int minuto= dataReader.GetInt32(4);
                    String tipo = dataReader.GetString(5);
                    String motivo = dataReader.GetString(6);

                    tarjetas.Add(new TarjetaCO(cod_Jugador, dorsal, nombre + " " + apellidos,
                        minuto, tipo, motivo));
                }
                while (dataReader.Read());
                             
                return tarjetas;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }



        public TarjetaVO buscarTarjetaId(DbConnection connection, DbTransaction transaction, int id_Tarjeta)
        {
            DbDataReader dataReader = null;
            
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT * FROM Tarjeta where cod_Tarjeta=" + id_Tarjeta;
                command.Prepare();
                dataReader = command.ExecuteReader();
                
                if (!dataReader.Read())
                {
                    throw new InstanceNotFoundException(1, "tarjeta");

                }
                
                int cod_Tarjeta = dataReader.GetInt32(0);
                int cod_Partido = dataReader.GetInt32(1);
                int cod_Jugador = dataReader.GetInt32(2);
                int minuto = dataReader.GetInt32(3);
                String tipo = dataReader.GetString(4);
                String motivo = dataReader.GetString(5);

                dataReader.Close();

                return new TarjetaVO(cod_Tarjeta, cod_Partido, cod_Jugador, minuto, tipo, motivo);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }
    }
}
