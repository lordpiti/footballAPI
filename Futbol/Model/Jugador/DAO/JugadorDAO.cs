using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;

using Futbol.Model.Jugador.VO;
using System.Data;
using System.Data.Common;

namespace Futbol.Model.Jugador.DAO
{
    public class JugadorDAO
    {


         public JugadorVO create(DbConnection connection, DbTransaction transaction, JugadorVO jugadorVO)
         {
             try
             {
                 DbCommand command = connection.CreateCommand();

                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }
                 
                 command.CommandText = "INSERT INTO Jugador (cod_Integrante,cod_Equipo,version_Integrante,altura,posicion,pierna) values (@cod_Integrante,@cod_Equipo,@version_Integrante,@altura,@posicion,@pierna)";

                 DbParameter cod_IntegranteParam = command.CreateParameter();
                 cod_IntegranteParam.ParameterName = "@cod_Integrante";
                 cod_IntegranteParam.DbType = DbType.Int32;
                 cod_IntegranteParam.Value = jugadorVO.Cod_Integrante;
                 cod_IntegranteParam.Size = 32;
                 command.Parameters.Add(cod_IntegranteParam);


                 DbParameter cod_EquipoParam = command.CreateParameter();
                 cod_EquipoParam.ParameterName = "@cod_Equipo";
                 cod_EquipoParam.DbType = DbType.Int32;
                 cod_EquipoParam.Value = jugadorVO.Cod_Equipo;
                 cod_EquipoParam.Size = 32;
                 command.Parameters.Add(cod_EquipoParam);


                 DbParameter version_IntegranteParam = command.CreateParameter();
                 version_IntegranteParam.ParameterName = "@version_Integrante";
                 version_IntegranteParam.DbType = DbType.Int32;
                 version_IntegranteParam.Value = jugadorVO.Version_Integrante;
                 version_IntegranteParam.Size = 32;
                 command.Parameters.Add(version_IntegranteParam);


                 DbParameter alturaParam = command.CreateParameter();
                 alturaParam.ParameterName = "@altura";
                 alturaParam.DbType = DbType.Double;
                 alturaParam.Value = jugadorVO.Altura;
                 alturaParam.Size = 32;
                 command.Parameters.Add(alturaParam);


                 DbParameter posicionParam = command.CreateParameter();
                 posicionParam.ParameterName = "@posicion";
                 posicionParam.DbType = DbType.String;
                 posicionParam.Size = 50;
                 if (jugadorVO.Posicion == null) posicionParam.Value = DBNull.Value;
                 else posicionParam.Value = jugadorVO.Posicion;
                 command.Parameters.Add(posicionParam);


                 DbParameter piernaParam = command.CreateParameter();
                 piernaParam.ParameterName = "@pierna";
                 piernaParam.DbType = DbType.String;
                 piernaParam.Size = 50;
                 if (jugadorVO.Pierna == null) piernaParam.Value = DBNull.Value;
                 else piernaParam.Value = jugadorVO.Pierna;
                 command.Parameters.Add(piernaParam);

                 command.Prepare();
                 
                 int insertedRows = command.ExecuteNonQuery();
                 
                 if (insertedRows == 0)
                 {
                     
                     throw new SQLException("errorrrrrrr");
                 }
                 
                 IJugadorIdentifierRetriever jugadorIdentifierRetriever = JugadorIdentifierRetrieverFactory.GetRetriever();

                 Int64 jugadorIdentifier = jugadorIdentifierRetriever.GetGeneratedIdentifier(connection,transaction);

                 return new JugadorVO((int)jugadorIdentifier, jugadorVO.Cod_Integrante,jugadorVO.Cod_Equipo,
                     jugadorVO.Version_Integrante, jugadorVO.Altura,jugadorVO.Posicion, jugadorVO.Pierna);
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);

             }
         }


         public ArrayList listarJugadoresEquipo(DbConnection connection, DbTransaction transaction,int cod_Equipo,
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
                 "SELECT * FROM Jugador "+
                 "WHERE cod_Equipo="+cod_Equipo;
                 command.Prepare();

                 dataReader = command.ExecuteReader();
                 if (!dataReader.Read())
                 {
                   //  throw new InstanceNotFoundException(1, "listarJugadorsEquipo en el dao de jugadores");
                     return null;
                 }

                 var jugadores = new ArrayList();

                 do
                 {
                     int cod_Jugador = dataReader.GetInt32(0);
                     int cod_Integrante = dataReader.GetInt32(1);
                     int version = dataReader.GetInt32(3);
                     float altura = dataReader.GetFloat(4);
                     String posicion = dataReader.GetString(5);
                     String pierna = dataReader.GetString(6);

                     jugadores.Add(new JugadorVO(cod_Jugador, cod_Integrante, cod_Equipo,version,altura,posicion,pierna));
                 }
                 while (dataReader.Read());

                 return jugadores;
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);
             }
             finally { dataReader.Close(); }
         }


        public JugadorVO obtenerJugadorVO(DbConnection connection, DbTransaction transaction, int cod_Integrante,
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

                
                command.CommandText = "SELECT * from Jugador WHERE cod_Integrante="+cod_Integrante+
                    " AND cod_equipo="+cod_Equipo+" AND version_integrante="+version_Integrante;



                command.Prepare();

                dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                {
                   // throw new InstanceNotFoundException(1, "jugador");
                    return null;
                }

                int cod_Jugador = dataReader.GetInt32(0);
                float altura = dataReader.GetFloat(4);
                String posicion = dataReader.GetString(5);
                String pierna = dataReader.GetString(6);


                return new JugadorVO(cod_Jugador, cod_Integrante, cod_Equipo, version_Integrante, altura,
                    posicion, pierna);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }



        }



         public List<JugadorPlantillaCO> verPlantillaEquipo(DbConnection connection, DbTransaction transaction, int cod_Equipo,
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

                 command.CommandText = "SELECT ju.cod_jugador,i.nombre,i.apellidos,i.fecha_nac," +
                     "ju.posicion,i.foto,i.cod_int,h.dorsal from jugador ju JOIN (SELECT cod_integrante,dorsal, " +
                     "max(version_integrante)as maximo from hco_integrante where fecha_fin is null group by cod_integrante,dorsal) h " +
                     "on (ju.cod_integrante=h.cod_integrante and ju.version_integrante=h.maximo " +
                     "and ju.cod_equipo=" + cod_Equipo + ") JOIN integrante i " +
                     "on h.cod_integrante=i.cod_int";
                 command.Prepare();

                 dataReader = command.ExecuteReader();
                 

                 
                 if (!dataReader.Read())
                 {
                    // throw new InstanceNotFoundException(1, "verPlantillaEquipo en DAO de jugadores");
                     return null;
                 }

                 var jugadores = new List<JugadorPlantillaCO>();
                 

                 do
                 {
                     int cod_Jugador = dataReader.GetInt32(0);
                     String nombre = dataReader.GetString(1);
                     String apellidos = dataReader.GetString(2);
                     DateTime fechaNac= dataReader.GetDateTime(3);

                     String posicion = dataReader.GetString(4);
                     String foto;
                     if (dataReader.GetValue(5) == DBNull.Value) foto = null;
                     else foto = dataReader.GetString(5);
                     Int32 cod_Integrante = dataReader.GetInt32(6);
                     Int32 dorsal = dataReader.GetInt32(7);

                     jugadores.Add(new JugadorPlantillaCO(cod_Jugador,nombre, apellidos,fechaNac,posicion,foto,cod_Integrante,dorsal));
                 }
                 while (dataReader.Read());
                 
                 return jugadores;
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);
             }
             finally { dataReader.Close(); }
         }


         public DatosTotalesJugador verJugador(DbConnection connection, DbTransaction transaction, int cod_Jugador)
         {

             DbDataReader dataReader = null;

             try
             {

                 DbCommand command = connection.CreateCommand();
                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }

                 command.CommandText = "SELECT i.nombre,i.apellidos,i.fecha_nac,ju.altura,ju.posicion,ju.pierna,h.sueldo,h.fecha_fin_contrato,"+
                     "i.foto from jugador ju INNER JOIN hco_integrante h on (ju.cod_jugador="+cod_Jugador+" and h.cod_equipo=ju.cod_equipo and "+
                     "ju.cod_integrante=h.cod_integrante) INNER JOIN integrante i ON (i.cod_int=h.cod_integrante)";



                 command.Prepare();

                 dataReader = command.ExecuteReader();

                 if (!dataReader.Read())
                 {
                     throw new InstanceNotFoundException(1, "jugador");

                 }

                 String nombre = dataReader.GetString(0);
                 String apellidos = dataReader.GetString(1);
                 DateTime fecha_Nacimiento = dataReader.GetDateTime(2);
                 float altura = dataReader.GetFloat(3);
                 String posicion = dataReader.GetString(4);
                 String pierna = dataReader.GetString(5);
                 Int32 sueldo = (Int32) dataReader.GetFloat(6);
                 DateTime fecha_Fin_Contrato;
                 if (dataReader.GetValue(7) == DBNull.Value) fecha_Fin_Contrato = DateTime.MinValue;
                 else  fecha_Fin_Contrato= dataReader.GetDateTime(7);
                 String foto=null;
                 if (dataReader.GetValue(8)!=DBNull.Value) foto=dataReader.GetString(8);
                 

                 return new DatosTotalesJugador(nombre, apellidos, fecha_Nacimiento, 
                     altura, foto, posicion, pierna, sueldo, fecha_Fin_Contrato);
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);
             }
             finally { dataReader.Close(); }
         }


        public JugadorVO updateJugador(DbConnection connection, DbTransaction transaction,
            JugadorVO jugadorVO)
        {
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "UPDATE Jugador SET "+
                "altura=@altura,posicion=@posicion,pierna=@pierna "+
                "WHERE cod_Integrante=@cod_Integrante AND cod_Equipo=@cod_Equipo "+
                "AND version_Integrante=@version_Integrante";

                DbParameter cod_IntegranteParam = command.CreateParameter();
                cod_IntegranteParam.ParameterName = "@cod_Integrante";
                cod_IntegranteParam.DbType = DbType.Int32;
                cod_IntegranteParam.Value = jugadorVO.Cod_Integrante;
                cod_IntegranteParam.Size = 32;
                command.Parameters.Add(cod_IntegranteParam);


                DbParameter cod_EquipoParam = command.CreateParameter();
                cod_EquipoParam.ParameterName = "@cod_Equipo";
                cod_EquipoParam.DbType = DbType.Int32;
                cod_EquipoParam.Value = jugadorVO.Cod_Equipo;
                cod_EquipoParam.Size = 32;
                command.Parameters.Add(cod_EquipoParam);


                DbParameter version_IntegranteParam = command.CreateParameter();
                version_IntegranteParam.ParameterName = "@version_Integrante";
                version_IntegranteParam.DbType = DbType.Int32;
                version_IntegranteParam.Value = jugadorVO.Version_Integrante;
                version_IntegranteParam.Size = 32;
                command.Parameters.Add(version_IntegranteParam);


                DbParameter alturaParam = command.CreateParameter();
                alturaParam.ParameterName = "@altura";
                alturaParam.DbType = DbType.Double;
                alturaParam.Value = jugadorVO.Altura;
                alturaParam.Size = 32;
                command.Parameters.Add(alturaParam);


                DbParameter posicionParam = command.CreateParameter();
                posicionParam.ParameterName = "@posicion";
                posicionParam.DbType = DbType.String;
                posicionParam.Size = 50;
                if (jugadorVO.Posicion == null) posicionParam.Value = DBNull.Value;
                else posicionParam.Value = jugadorVO.Posicion;
                command.Parameters.Add(posicionParam);


                DbParameter piernaParam = command.CreateParameter();
                piernaParam.ParameterName = "@pierna";
                piernaParam.DbType = DbType.String;
                piernaParam.Size = 50;
                if (jugadorVO.Pierna == null) piernaParam.Value = DBNull.Value;
                else piernaParam.Value = jugadorVO.Pierna;
                command.Parameters.Add(piernaParam);

                command.Prepare();

                int insertedRows = command.ExecuteNonQuery();

                if (insertedRows == 0)
                {

                    throw new SQLException("errorrrrrrr");
                }

                return jugadorVO;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }
    }
}
