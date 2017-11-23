using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;
using Util.Log;
using Futbol.Model.Clasificacion.VO;
using System.Data;
using System.Data.Common;








namespace Futbol.Model.Clasificacion.DAO
{
    public class ClasificacionDAO
    {

        public ClasificacionVO create(DbConnection connection, DbTransaction transaction, ClasificacionVO clasificacionVO)
        {
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }



                command.CommandText = "INSERT INTO Clasificacion(cod_Competicion,jornada,cod_Equipo,"+
                    "posicion,ganados,empatados,perdidos,goles_favor,goles_contra, puntos) "+
                    "VALUES (@cod_Competicion,@jornada,@cod_Equipo,@posicion,@ganados,@empatados,@perdidos,"+
                    "@goles_favor,@goles_contra,@puntos)";

                DbParameter cod_CompeticionParam = command.CreateParameter();
                cod_CompeticionParam.ParameterName = "@cod_Competicion";
                cod_CompeticionParam.DbType = DbType.Int32;
                cod_CompeticionParam.Value = clasificacionVO.Cod_Competicion;
                cod_CompeticionParam.Size = 32;
                command.Parameters.Add(cod_CompeticionParam);


                DbParameter jornadaParam = command.CreateParameter();
                jornadaParam.ParameterName = "@jornada";
                jornadaParam.DbType = DbType.Int32;
                jornadaParam.Value = clasificacionVO.Jornada;
                jornadaParam.Size = 32;
                command.Parameters.Add(jornadaParam);


                DbParameter cod_EquipoParam = command.CreateParameter();
                cod_EquipoParam.ParameterName = "@cod_Equipo";
                cod_EquipoParam.DbType = DbType.Int32;
                cod_EquipoParam.Value = clasificacionVO.Cod_Equipo;
                cod_EquipoParam.Size = 32;
                command.Parameters.Add(cod_EquipoParam);


                DbParameter posicionParam = command.CreateParameter();
                posicionParam.ParameterName = "@posicion";
                posicionParam.DbType = DbType.String;
                posicionParam.Size = 32;
                posicionParam.Value = clasificacionVO.Posicion;
                command.Parameters.Add(posicionParam);


                DbParameter ganadosParam = command.CreateParameter();
                ganadosParam.ParameterName = "@ganados";
                ganadosParam.DbType = DbType.Int32;
                ganadosParam.Size = 32;
                ganadosParam.Value = clasificacionVO.Ganados;
                command.Parameters.Add(ganadosParam);


                DbParameter perdidosParam = command.CreateParameter();
                perdidosParam.ParameterName = "@perdidos";
                perdidosParam.DbType = DbType.Int32;
                perdidosParam.Size = 32;
                perdidosParam.Value = clasificacionVO.Perdidos;
                command.Parameters.Add(perdidosParam);


                DbParameter empatadosParam = command.CreateParameter();
                empatadosParam.ParameterName = "@empatados";
                empatadosParam.DbType = DbType.Int32;
                empatadosParam.Size = 32;
                empatadosParam.Value = clasificacionVO.Empatados;
                command.Parameters.Add(empatadosParam);


                DbParameter goles_FavorParam = command.CreateParameter();
                goles_FavorParam.ParameterName = "@goles_Favor";
                goles_FavorParam.DbType = DbType.Int32;
                goles_FavorParam.Value = clasificacionVO.Goles_Favor;
                goles_FavorParam.Size = 32;
                command.Parameters.Add(goles_FavorParam);


                DbParameter goles_ContraParam = command.CreateParameter();
                goles_ContraParam.ParameterName = "@goles_Contra";
                goles_ContraParam.DbType = DbType.Int32;
                goles_ContraParam.Value = clasificacionVO.Goles_Contra;
                goles_ContraParam.Size = 32;
                command.Parameters.Add(goles_ContraParam);


                DbParameter puntosParam = command.CreateParameter();
                puntosParam.ParameterName = "@puntos";
                puntosParam.DbType = DbType.Int32;
                puntosParam.Value = clasificacionVO.Puntos;
                puntosParam.Size = 32;
                command.Parameters.Add(puntosParam);


                command.Prepare();
                int insertedRows = command.ExecuteNonQuery();
                
                if (insertedRows == 0)
                {            
                    throw new SQLException("errorrrrrrr");
                }


                return clasificacionVO;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }



        public ArrayList clasificacionJornadaTemporada(DbConnection connection, DbTransaction transaction,
        int cod_Competicion, int jornada)
        {

            DbDataReader dataReader = null;

            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT c.Cod_Competicion, c.jornada, c.posicion, c.cod_equipo, e.Nombre," +
                    "c.ganados,c.perdidos,c.empatados,"+
                    "c.goles_favor, c.goles_contra, c.puntos FROM Clasificacion AS c INNER JOIN " +
                    "Equipo AS e ON (c.cod_competicion=" + cod_Competicion + " and c.jornada=" + jornada + " and e.Cod_Equipo = c.Cod_Equipo)" +
                    "ORDER BY c.posicion"; 
                command.Prepare();
                dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                {
                 //   throw new InstanceNotFoundException(1, "algo");
                    return null;
                }


                ArrayList clasificacionJornada = new ArrayList();

                do
                {

                    int posicion = dataReader.GetInt32(2);
                    int cod_Equipo = dataReader.GetInt32(3);
                    String nombre = dataReader.GetString(4);
                    int ganados = dataReader.GetInt32(5);
                    int perdidos = dataReader.GetInt32(6);
                    int empatados = dataReader.GetInt32(7);
                    int golesFavor = dataReader.GetInt32(8);
                    int golesContra = dataReader.GetInt32(9);
                    int puntos = dataReader.GetInt32(10);
                    ClasificacionCO clasificacionVO =
                        new ClasificacionCO(cod_Competicion, jornada, posicion, cod_Equipo,nombre,
                        ganados,perdidos,empatados,golesFavor, golesContra, puntos);
                    clasificacionJornada.Add(clasificacionVO);

                }
                while (dataReader.Read());

                return clasificacionJornada;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }




        }



        public ArrayList listaClasificacionVOsJornadaTemporada(DbConnection connection, DbTransaction transaction,
         int cod_Competicion, int jornada)
        {

            DbDataReader dataReader = null;

            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT c.cod_equipo, c.posicion," +
                    "c.ganados,c.perdidos,c.empatados," +
                    "c.goles_favor, c.goles_contra, c.puntos FROM Clasificacion AS c "+
                    "WHERE c.cod_competicion="+cod_Competicion+" AND c.jornada="+jornada+
                    " ORDER BY c.puntos";
                command.Prepare();
                dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                {
                  //  throw new InstanceNotFoundException(1, "algo");
                    return null;
                }


                ArrayList clasificacionJornada = new ArrayList();

                do
                {
                    int cod_Equipo = dataReader.GetInt32(0);
                    int posicion = dataReader.GetInt32(1); 
                    int ganados = dataReader.GetInt32(2);
                    int perdidos = dataReader.GetInt32(3);
                    int empatados = dataReader.GetInt32(4);
                    int golesFavor = dataReader.GetInt32(5);
                    int golesContra = dataReader.GetInt32(6);
                    int puntos = dataReader.GetInt32(7);
                    ClasificacionVO clasificacionVO =
                        new ClasificacionVO(cod_Competicion, jornada,cod_Equipo, posicion, 
                        ganados, perdidos, empatados, golesFavor, golesContra, puntos);
                    clasificacionJornada.Add(clasificacionVO);

                }
                while (dataReader.Read());

                return clasificacionJornada;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }




        }


        public Int32 obtenerUltimaJornada(DbConnection connection, DbTransaction transaction, int cod_Competicion)
        {

            DbDataReader dataReader = null;

            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT max(jornada) FROM Clasificacion where cod_competicion=" + cod_Competicion;
                command.Prepare();



                dataReader = command.ExecuteReader();
                
                Int32 jornada;

                if (!dataReader.Read())
                {
                    
                    return 0;
                }

                if (dataReader.GetValue(0) == DBNull.Value)
                {
                    jornada = 0;   
                }
                else jornada = dataReader.GetInt32(0);


                return jornada;
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
    
    
    
    }
}
