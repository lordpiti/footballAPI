using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;
using Util.Log;
using Futbol.Model.Partido.VO;
using Futbol.Model.PartidoJugado;
using System.Data;
using System.Data.Common;

namespace Futbol.Model.Partido.DAO
{
     public class PartidoDAO
    {

         public PartidoVO create(DbConnection connection, DbTransaction transaction, PartidoVO partidoVO)
         {
             try
             {
                 DbCommand command = connection.CreateCommand();

                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                     
                 }

                

                 command.CommandText = "INSERT INTO Partido (cod_competicion, jornada, cod_Local, cod_Visitante, fecha," +
                 "clima, goles_Local, goles_Visitante, posesion_Local, posesion_Visitante," +
                 "corners_Local, corners_Visitante, fueras_Juego_Local, fueras_Juego_Visitante," +
                 "asistencia, cod_Arbitro, cod_Estadio) values " +
                 "(@cod_competicion, @jornada, @cod_Local, @cod_Visitante, @fecha," +
                 "@clima, @goles_Local, @goles_Visitante, @posesion_Local, @posesion_Visitante," +
                 "@corners_Local, @corners_Visitante, @fueras_Juego_Local, @fueras_Juego_Visitante," +
                 "@asistencia, @cod_Arbitro, @cod_Estadio)";

                 DbParameter cod_competicionParam = command.CreateParameter();
                 cod_competicionParam.ParameterName = "@cod_competicion";
                 cod_competicionParam.DbType = DbType.Int32;
                 cod_competicionParam.Value = partidoVO.Cod_Competicion;
                 cod_competicionParam.Size = 32;
                 command.Parameters.Add(cod_competicionParam);


                 DbParameter jornadaParam = command.CreateParameter();
                 jornadaParam.ParameterName = "@jornada";
                 jornadaParam.DbType = DbType.String;
                 jornadaParam.Value = partidoVO.Jornada;
                 jornadaParam.Size = 32;
                 command.Parameters.Add(jornadaParam);


                 DbParameter cod_LocalParam = command.CreateParameter();
                 cod_LocalParam.ParameterName = "@cod_Local";
                 cod_LocalParam.DbType = DbType.Int32;
                 cod_LocalParam.Value = partidoVO.Cod_Local;
                 cod_LocalParam.Size = 32;
                 command.Parameters.Add(cod_LocalParam);


                 DbParameter cod_VisitanteParam = command.CreateParameter();
                 cod_VisitanteParam.ParameterName = "@cod_Visitante";
                 cod_VisitanteParam.DbType = DbType.Int32;
                 cod_VisitanteParam.Value = partidoVO.Cod_Visitante;
                 cod_VisitanteParam.Size = 32;
                 command.Parameters.Add(cod_VisitanteParam);


                 DbParameter goles_LocalParam = command.CreateParameter();
                 goles_LocalParam.ParameterName = "@goles_Local";
                 goles_LocalParam.DbType = DbType.Int32;
                 goles_LocalParam.Value = partidoVO.Goles_Local;
                 goles_LocalParam.Size = 32;
                 command.Parameters.Add(goles_LocalParam);


                 DbParameter goles_VisitanteParam = command.CreateParameter();
                 goles_VisitanteParam.ParameterName = "@goles_Visitante";
                 goles_VisitanteParam.DbType = DbType.Int32;
                 goles_VisitanteParam.Value = partidoVO.Goles_Visitante;
                 goles_VisitanteParam.Size = 32;
                 command.Parameters.Add(goles_VisitanteParam);


                 DbParameter posesion_LocalParam = command.CreateParameter();
                 posesion_LocalParam.ParameterName = "@posesion_Local";
                 posesion_LocalParam.DbType = DbType.Double;
                 posesion_LocalParam.Value = partidoVO.Posesion_Local;
                 posesion_LocalParam.Size = 30;
                 command.Parameters.Add(posesion_LocalParam);


                 DbParameter posesion_VisitanteParam = command.CreateParameter();
                 posesion_VisitanteParam.ParameterName = "@posesion_Visitante";
                 posesion_VisitanteParam.DbType = DbType.Double;
                 posesion_VisitanteParam.Value = partidoVO.Posesion_Visitante;
                 posesion_VisitanteParam.Size = 30;
                 command.Parameters.Add(posesion_VisitanteParam);


                 DbParameter corners_LocalParam = command.CreateParameter();
                 corners_LocalParam.ParameterName = "@corners_Local";
                 corners_LocalParam.DbType = DbType.Int32;
                 corners_LocalParam.Value = partidoVO.Corners_Local;
                 corners_LocalParam.Size = 32;
                 command.Parameters.Add(corners_LocalParam);


                 DbParameter corners_VisitanteParam = command.CreateParameter();
                 corners_VisitanteParam.ParameterName = "@corners_Visitante";
                 corners_VisitanteParam.DbType = DbType.Int32;
                 corners_VisitanteParam.Value = partidoVO.Corners_Visitante;
                 corners_VisitanteParam.Size = 32;
                 command.Parameters.Add(corners_VisitanteParam);


                 DbParameter fueras_Juego_LocalParam = command.CreateParameter();
                 fueras_Juego_LocalParam.ParameterName = "@fueras_Juego_Local";
                 fueras_Juego_LocalParam.DbType = DbType.Int32;
                 fueras_Juego_LocalParam.Value = partidoVO.FuerasJuego_Local;
                 fueras_Juego_LocalParam.Size = 32;
                 command.Parameters.Add(fueras_Juego_LocalParam);


                 DbParameter fueras_Juego_VisitanteParam = command.CreateParameter();
                 fueras_Juego_VisitanteParam.ParameterName = "@fueras_Juego_Visitante";
                 fueras_Juego_VisitanteParam.DbType = DbType.Int32;
                 fueras_Juego_VisitanteParam.Value = partidoVO.FuerasJuego_Visitante;
                 fueras_Juego_VisitanteParam.Size = 32;
                 command.Parameters.Add(fueras_Juego_VisitanteParam);


                 DbParameter climaParam = command.CreateParameter();
                 climaParam.ParameterName = "@clima";
                 climaParam.DbType = DbType.String;
                 climaParam.Value = partidoVO.Clima;
                 climaParam.Size = 20;
                 command.Parameters.Add(climaParam);

                 DbParameter fechaParam = command.CreateParameter();
                 fechaParam.ParameterName = "@fecha";
                 fechaParam.DbType = DbType.DateTime;
                 fechaParam.Value = partidoVO.Fecha;
                 fechaParam.Size = 100;
                 command.Parameters.Add(fechaParam);


                 DbParameter asistenciaParam = command.CreateParameter();
                 asistenciaParam.ParameterName = "@asistencia";
                 asistenciaParam.DbType = DbType.Int32;
                 asistenciaParam.Value = partidoVO.Asistencia;
                 asistenciaParam.Size = 32;
                 command.Parameters.Add(asistenciaParam);


                 DbParameter cod_ArbitroParam = command.CreateParameter();
                 cod_ArbitroParam.ParameterName = "@cod_Arbitro";
                 cod_ArbitroParam.DbType = DbType.Int32;
                 cod_ArbitroParam.Value = partidoVO.Cod_Arbitro;
                 cod_ArbitroParam.Size = 32;
                 command.Parameters.Add(cod_ArbitroParam);


                 DbParameter cod_EstadioParam = command.CreateParameter();
                 cod_EstadioParam.ParameterName = "@cod_Estadio";
                 cod_EstadioParam.DbType = DbType.Int32;
                 cod_EstadioParam.Value = partidoVO.Cod_Estadio;
                 cod_EstadioParam.Size = 32;
                 command.Parameters.Add(cod_EstadioParam);


                 command.Prepare();
                 
                 int insertedRows = command.ExecuteNonQuery();
                 

                 if (insertedRows == 0)
                 {
                     throw new SQLException("errorrrrrrr");
                 }

                 IPartidoIdentifierRetriever partidoIdentifierRetriever = PartidoIdentifierRetrieverFactory.GetRetriever();

                 Int64 partidoIdentifier = partidoIdentifierRetriever.GetGeneratedIdentifier(connection,transaction);




                 return new PartidoVO((int)partidoIdentifier, partidoVO.Cod_Competicion,partidoVO.Jornada, partidoVO.Cod_Local,
                     partidoVO.Cod_Visitante, partidoVO.Fecha, partidoVO.Clima,
                     partidoVO.Goles_Local, partidoVO.Goles_Visitante, partidoVO.Posesion_Local,
                     partidoVO.Posesion_Visitante, partidoVO.Corners_Local, partidoVO.Corners_Visitante,
                     partidoVO.FuerasJuego_Local, partidoVO.FuerasJuego_Visitante, partidoVO.Asistencia,
                     partidoVO.Cod_Arbitro, partidoVO.Cod_Estadio);
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);

             }
         }
         

         
         
         public PartidoVO verPartido(DbConnection connection, DbTransaction transaction,int cod_Partido)
        {

            DbDataReader dataReader = null;
            
            try
            {

                DbCommand command = connection.CreateCommand();
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }


                command.CommandText = "SELECT * from Partido where Cod_Partido="+cod_Partido;
                command.Prepare();
                
                dataReader = command.ExecuteReader();
                
                if (!dataReader.Read())
                {
                    throw new InstanceNotFoundException(1, "partido");

                }


                
                int cod_Competicion = dataReader.GetInt32(1);
                String jornada = dataReader.GetString(2);
                int cod_Local = dataReader.GetInt32(3);
                int cod_Visitante = dataReader.GetInt32(4);
                DateTime fecha = dataReader.GetDateTime(5);
                String clima = dataReader.GetString(6);
                int goles_Local = dataReader.GetInt32(7);
                int goles_Visitante = dataReader.GetInt32(8);
                float posesion_Local = dataReader.GetFloat(9);
                float posesion_Visitante = dataReader.GetFloat(10);
                int corners_Local = dataReader.GetInt32(11);
                int corners_Visitante = dataReader.GetInt32(12);
                int fuerasJuego_Local = dataReader.GetInt32(13);
                int fuerasJuego_Visitante = dataReader.GetInt32(14);
                int asistencia = dataReader.GetInt32(15);
                int cod_Arbitro = dataReader.GetInt32(16);
                int cod_Estadio = dataReader.GetInt32(17);




                return new PartidoVO(cod_Partido, cod_Competicion, jornada, cod_Local,
                cod_Visitante, fecha, clima, goles_Local, goles_Visitante, posesion_Local,
                posesion_Visitante, corners_Local, corners_Visitante, fuerasJuego_Local,
                fuerasJuego_Visitante, asistencia, cod_Arbitro, cod_Estadio);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }



         public ArrayList verPartidosCompeticionJornada(DbConnection connection, DbTransaction transaction,
             int cod_Competicion, String jornada)
         {

            DbDataReader dataReader = null;

            try
            {
                DbCommand command = connection.CreateCommand();
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT p.cod_partido,e1.nombre,e2.nombre,p.goles_Local,p.goles_visitante,c.temporada,c.nombre,p.jornada FROM "+
                "partido p INNER JOIN equipo e1 on (p.cod_competicion="+cod_Competicion+" and "+
                "p.jornada='"+jornada+"' and p.cod_local=e1.cod_equipo) INNER JOIN equipo e2 "+
                "on (p.cod_visitante=e2.cod_equipo) INNER JOIN competicion c on (c.cod_competicion=p.cod_competicion) ";

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
                    String jor = dataReader.GetString(7);
                    

                    partidosJugadosCompeticionJugador.Add(
                        new PartidoCompeticionJornadaCO(cod_Partido, nombreLocal, 
                        nombreVisitante,golesLocal,golesVisitante,temporada,nombreCompeticion,cod_Competicion,jor));

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


         public ArrayList verJornadasCompeticion(DbConnection connection, DbTransaction transaction,
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

                 command.CommandText = "SELECT  co.tipo from " +
                    "competicion co where cod_competicion=" + cod_Competicion;

                 command.Connection = connection;
                 command.Prepare();
                 String tipo = "Liga";
                 

                 dataReader = command.ExecuteReader();



                 if (!dataReader.Read())
                 {
                     tipo = "Liga";


                 }
                 if (dataReader.GetValue(0) == DBNull.Value)
                 {
                     tipo = "Liga";

                 }
                 else tipo = dataReader.GetString(0);

                 dataReader.Close();


                 command = connection.CreateCommand();


                 command.CommandText = "SELECT distinct pa.jornada from partido pa " +
                     "where pa.cod_competicion=" + cod_Competicion;

                 command.Prepare();

                 dataReader = command.ExecuteReader();


                 if (!dataReader.Read())
                 {
                   //  throw new InstanceNotFoundException(1, "partido");
                     return null;
                 }

                 ArrayList jornadasCompeticion = new ArrayList();

                 do
                 {
                     String jornada = dataReader.GetString(0);
                     TemporadaCO jornadaAgregar = new TemporadaCO(jornada);
                     jornadasCompeticion.Add(jornadaAgregar);
                     
                     

                 }
                 while (dataReader.Read());

                 //Esto es para ordenar bien la lista de jornadas
                 if (tipo.Equals("Liga"))
                 {
                     ArrayList listatemp = new ArrayList();
                     foreach (TemporadaCO item in jornadasCompeticion)
                     {
                         listatemp.Add(Int32.Parse(item.Temporada));
                     }
                     listatemp.Sort();
                     jornadasCompeticion.Clear();
                     foreach (Int32 item in listatemp)
                     {
                         jornadasCompeticion.Add(new TemporadaCO(Convert.ToString(item)));
                     }
                 }
                 else { }

                 return jornadasCompeticion;
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);
             }
             finally { dataReader.Close(); }

         }





         public ArrayList verPartidosVOCompeticionJornada(DbConnection connection, DbTransaction transaction,
             int cod_Competicion, String jornada)
         {

             DbDataReader dataReader = null;

             try
             {
                 DbCommand command = connection.CreateCommand();
                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }

                 command.CommandText = "SELECT cod_partido,cod_Local,cod_Visitante,fecha,clima," +
                     "goles_Local,goles_Visitante,posesion_Local,posesion_Visitante,corners_local," +
                     "corners_Visitante,fueras_Juego_Local,fueras_Juego_Visitante,asistencia," +
                     "cod_arbitro,cod_estadio FROM partido WHERE cod_competicion=" + cod_Competicion + " AND " +
                     "jornada='" + jornada + "'";
                 command.Prepare();

                 dataReader = command.ExecuteReader();


                 if (!dataReader.Read())
                 {
                     return null;

                 }

                 ArrayList listaPartidoVOs = new ArrayList();

                 do
                 {
                     Int32 cod_Partido = dataReader.GetInt32(0);
                     Int32 cod_Local = dataReader.GetInt32(1);
                     Int32 cod_Visitante = dataReader.GetInt32(2);
                     DateTime fecha = dataReader.GetDateTime(3);
                     String clima = dataReader.GetString(4);
                     Int32 golesLocal = dataReader.GetInt32(5);
                     Int32 golesVisitante = dataReader.GetInt32(6);
                     float posesionLocal = dataReader.GetFloat(7);
                     float posesionVisitante = dataReader.GetFloat(8);
                     Int32 cornersLocal = dataReader.GetInt32(9);
                     Int32 cornersVisitante = dataReader.GetInt32(10);
                     Int32 fuerasJuegoLocal = dataReader.GetInt32(11);
                     Int32 fuerasJuegoVisitante = dataReader.GetInt32(12);
                     Int32 asistencia = dataReader.GetInt32(13);
                     Int32 cod_Arbitro = dataReader.GetInt32(14);
                     Int32 cod_Estadio = dataReader.GetInt32(15);


                      listaPartidoVOs.Add(
                         new PartidoVO(cod_Partido,cod_Competicion,jornada,cod_Local,cod_Visitante,
                         fecha,clima,golesLocal,golesVisitante,posesionLocal,posesionVisitante,
                         cornersLocal,cornersVisitante,fuerasJuegoLocal,fuerasJuegoVisitante,
                         asistencia,cod_Arbitro,cod_Estadio));

                 }
                 while (dataReader.Read());


                 return listaPartidoVOs;
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);
             }
             finally { dataReader.Close(); }

         }



         public ArrayList buscarPartidosEquipos(DbConnection connection, DbTransaction transaction,
             int cod_Local, int cod_Visitante, int cod_Competicion,String jornada,int flag)
         {
             DbDataReader dataReader = null;

             try
             {
                 DbCommand command = connection.CreateCommand();
                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                 }

                 String jornadaAdd = "";
                 String codLocal = "";
                 String codLocal2 = "";
                 String codVisitante = "";
                 String codVisitante2 = "";
                 String codCompeticion = "";
             

                 if (jornada!=null) jornadaAdd=" and jornada='"+jornada+"'";
                 if (cod_Competicion != 0) codCompeticion = " and p.cod_competicion="+cod_Competicion;
                 if (cod_Local != 0) 
                 {
                     codLocal = " and p.cod_Local=" + cod_Local;
                     codVisitante2 = " and p.cod_Visitante=" + cod_Local;
                     
                 }
                 if (cod_Visitante != 0)
                 {
                     codVisitante = " and p.cod_Visitante=" + cod_Visitante;
                     codLocal2 = " and p.cod_Local=" + cod_Visitante;
                 }

                 command.CommandText = "SELECT p.cod_partido,e1.nombre,e2.nombre,p.goles_Local,p.goles_visitante,c.temporada,c.nombre,c.cod_Competicion,p.jornada FROM " +
                 "partido p INNER JOIN equipo e1 on (p.cod_local=e1.cod_equipo" + codCompeticion + jornadaAdd +
                 codLocal + codVisitante+" and p.cod_local=e1.cod_equipo) INNER JOIN equipo e2 " +
                 "on (p.cod_visitante=e2.cod_equipo) INNER JOIN competicion c on (c.cod_competicion=p.cod_competicion)";

                 if (flag == 1)
                 {
                     command.CommandText += " UNION SELECT p.cod_partido,e1.nombre,e2.nombre,p.goles_Local,p.goles_visitante,c.temporada,c.nombre,c.cod_Competicion,p.jornada FROM " +
                 "partido p INNER JOIN equipo e1 on (p.cod_local=e1.cod_equipo" + codCompeticion + jornadaAdd +
                 codLocal2 + codVisitante2 + " and p.cod_local=e1.cod_equipo) INNER JOIN equipo e2 " +
                 "on (p.cod_visitante=e2.cod_equipo) INNER JOIN competicion c on (c.cod_competicion=p.cod_competicion)";

                 }
                 
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
                         nombreVisitante, golesLocal, golesVisitante,temporada,nombreCompeticion,cdComp,jor));
                    

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
