using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;
using Util.Log;
using Futbol.Model.Cambio.VO;
using System.Data;
using System.Data.Common;




namespace Futbol.Model.Cambio.DAO
{
    public class CambioDAO
    {


        public CambioVO create(DbConnection connection, DbTransaction transaction, CambioVO cambioVO)
        {
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "INSERT INTO Cambio (cod_Partido,cod_Jugador_Entra, cod_Jugador_Sale,minuto) "+
                    "values (@cod_Partido,@cod_Jugador_Entra,@cod_Jugador_Sale,@minuto)";

                DbParameter cod_PartidoParam = command.CreateParameter();
                cod_PartidoParam.ParameterName = "@cod_Partido";
                cod_PartidoParam.DbType = DbType.Int32;
                cod_PartidoParam.Value = cambioVO.Cd_Partido;
                cod_PartidoParam.Size = 32;
                command.Parameters.Add(cod_PartidoParam);


                DbParameter cod_Jugador_EntraParam = command.CreateParameter();
                cod_Jugador_EntraParam.ParameterName = "@cod_Jugador_Entra";
                cod_Jugador_EntraParam.DbType = DbType.Int32;
                cod_Jugador_EntraParam.Value = cambioVO.Cd_Jugador_Entra;
                cod_Jugador_EntraParam.Size = 32;
                command.Parameters.Add(cod_Jugador_EntraParam);


                DbParameter cod_Jugador_SaleParam = command.CreateParameter();
                cod_Jugador_SaleParam.ParameterName = "@cod_Jugador_Sale";
                cod_Jugador_SaleParam.DbType = DbType.Int32;
                cod_Jugador_SaleParam.Value = cambioVO.Cd_Jugador_Sale;
                cod_Jugador_SaleParam.Size = 32;
                command.Parameters.Add(cod_Jugador_SaleParam);


                DbParameter minutoParam = command.CreateParameter();
                minutoParam.ParameterName = "@minuto";
                minutoParam.DbType = DbType.Int32;
                minutoParam.Value = cambioVO.Minuto;
                minutoParam.Size = 32;
                command.Parameters.Add(minutoParam);


                command.Prepare();
                int insertedRows = command.ExecuteNonQuery();
                
                if (insertedRows == 0)
                {            
                    throw new SQLException("errorrrrrrr");
                }

                ICambioIdentifierRetriever cambioIdentifierRetriever = CambioIdentifierRetrieverFactory.GetRetriever();
                Int64 cambioIdentifier = cambioIdentifierRetriever.GetGeneratedIdentifier(connection,transaction);

                return new CambioVO((int)cambioIdentifier, cambioVO.Cd_Partido, cambioVO.Cd_Jugador_Entra,
                    cambioVO.Cd_Jugador_Sale, cambioVO.Minuto);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }



        public ArrayList listarCambiosPartidoEquipo(DbConnection connection, DbTransaction transaction,
            int cod_Partido, int cod_Equipo, int startIndex, int count)
        {
            DbDataReader dataReader = null;
            
            try
            {
                DbCommand command = connection.CreateCommand();
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "select ca.cod_cambio,ca.minuto,h.dorsal,ju.cod_jugador," +
                    "i.nombre,i.apellidos,h2.dorsal,ju2.cod_jugador,i2.nombre," +
                "i2.apellidos from cambio ca INNER JOIN " +
                "jugador ju on ca.cod_jugador_entra=ju.cod_jugador and " +
                "ca.cod_partido="+cod_Partido+" and ju.cod_equipo="+cod_Equipo+" INNER JOIN " +
                "hco_integrante h on ju.cod_integrante=h.cod_integrante and ju.cod_equipo=h.cod_equipo " +
                "and ju.version_integrante=h.version_integrante INNER JOIN " +
                "integrante i on h.cod_integrante=i.cod_int INNER JOIN " +
                "jugador ju2 on ca.cod_jugador_sale=ju2.cod_jugador INNER JOIN " +
                "hco_integrante h2 on ju2.cod_integrante=h2.cod_integrante and ju2.cod_equipo=h2.cod_equipo " +
                "and ju2.version_integrante=h2.version_integrante INNER JOIN " +
                "integrante i2 on h2.cod_integrante=i2.cod_int order by ca.minuto";




                command.Prepare();
                
                dataReader = command.ExecuteReader();
                if (!dataReader.Read())
                {
                   // throw new InstanceNotFoundException(1, "algo");
                    return null;
                }

                ArrayList cambios = new ArrayList();
                
                do
                {
                    int cod_Cambio = dataReader.GetInt32(0);
                    int minuto=dataReader.GetInt32(1);
                    int dorsalEntra = dataReader.GetInt32(2);
                    int codJugadorEntra = dataReader.GetInt32(3);
                    String nombreEntra = dataReader.GetString(4);
                    String apellidosEntra = dataReader.GetString(5);
                    int dorsalSale = dataReader.GetInt32(6);
                    int codJugadorSale = dataReader.GetInt32(7);
                    String nombreSale = dataReader.GetString(8);
                    String apellidosSale = dataReader.GetString(9);

                    cambios.Add(new CambioCO(cod_Cambio,minuto,codJugadorSale,dorsalSale,nombreSale+" "+apellidosSale,
                        codJugadorEntra,dorsalEntra,nombreEntra+" "+apellidosEntra));
                }
                while (dataReader.Read());
                             
                return cambios;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }



        public CambioVO buscarCambioId(DbConnection connection, DbTransaction transaction, int id_Cambio)
        {
            DbDataReader dataReader = null;
            
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT * FROM Cambio where cod_Cambio=" + id_Cambio;
                command.Prepare();
                dataReader = command.ExecuteReader();
                
                if (!dataReader.Read())
                {
                    throw new InstanceNotFoundException(1, "cambio");

                }
                
                int cod_Cambio = dataReader.GetInt32(0);
                int cod_Partido = dataReader.GetInt32(1);
                int cod_Jugador_Entra = dataReader.GetInt32(2);
                int cod_Jugador_Sale = dataReader.GetInt32(3);
                int minuto = dataReader.GetInt32(4);


                dataReader.Close();

                return new CambioVO(cod_Cambio, cod_Partido, 
                    cod_Jugador_Entra, cod_Jugador_Sale, minuto);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }
    }
}