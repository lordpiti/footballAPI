using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;

using Futbol.Model.PartidoJugado.VO;
using Futbol.Model.Partido;
using System.Data;
using System.Data.Common;




namespace Futbol.Model.PartidoJugado.DAO
{
    public class PartidoJugadoDAO
    {

        public PartidoJugadoVO create(DbConnection connection, DbTransaction transaction, PartidoJugadoVO partidoJugadoVO)
        {
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }



                command.CommandText = "INSERT INTO Partido_Jugado(cod_Jugador,cod_Partido,titular,minutos," +
                    "asistencias,asistencias_gol,remates,remates_porteria,remates_poste,fueras_juego," +
                    "tarjetas_amarillas_provocadas,tarjetas_rojas_provocadas,faltas_recibidas,faltas_cometidas," +
                    "corners,balones_recuperados,balones_perdidos,penaltis_recibidos,penaltis_cometidos) " +
                    "values (@cod_Jugador,@cod_Partido,@titular,@minutos,@asistencias,@asistenciasGol," +
                    "@remates,@rematesPorteria,@rematesPoste,@fuerasJuego,@tarjetasAmarillasProvocadas," +
                    "@tarjetasRojasProvocadas,@faltasRecibidas,@faltasCometidas,@corners,@balonesRecuperados," +
                    "@balonesPerdidos,@penaltisRecibidos,@penaltisCometidos)";

                DbParameter cod_JugadorParam = command.CreateParameter();
                cod_JugadorParam.ParameterName = "@cod_Jugador";
                cod_JugadorParam.DbType = DbType.Int32;
                cod_JugadorParam.Value = partidoJugadoVO.Cod_Jugador;
                cod_JugadorParam.Size = 32;
                command.Parameters.Add(cod_JugadorParam);


                DbParameter cod_PartidoParam = command.CreateParameter();
                cod_PartidoParam.ParameterName = "@cod_Partido";
                cod_PartidoParam.DbType = DbType.Int32;
                cod_PartidoParam.Value = partidoJugadoVO.Cod_Partido;
                cod_PartidoParam.Size = 32;
                command.Parameters.Add(cod_PartidoParam);


                DbParameter titularParam = command.CreateParameter();
                titularParam.ParameterName = "@titular";
                titularParam.DbType = DbType.String;
                titularParam.Size = 32;
                titularParam.Value = partidoJugadoVO.Titular;
                command.Parameters.Add(titularParam);


                DbParameter minutosParam = command.CreateParameter();
                minutosParam.ParameterName = "@minutos";
                minutosParam.DbType = DbType.Int32;
                minutosParam.Value = partidoJugadoVO.Minutos;
                minutosParam.Size = 32;
                command.Parameters.Add(minutosParam);


                DbParameter asistenciasParam = command.CreateParameter();
                asistenciasParam.ParameterName = "@asistencias";
                asistenciasParam.DbType = DbType.Int32;
                asistenciasParam.Value = partidoJugadoVO.Asistencias;
                asistenciasParam.Size = 32;
                command.Parameters.Add(asistenciasParam);


                DbParameter asistenciasGolParam = command.CreateParameter();
                asistenciasGolParam.ParameterName = "@asistenciasGol";
                asistenciasGolParam.DbType = DbType.Int32;
                asistenciasGolParam.Value = partidoJugadoVO.AsistenciasGol;
                asistenciasGolParam.Size = 32;
                command.Parameters.Add(asistenciasGolParam);


                DbParameter rematesParam = command.CreateParameter();
                rematesParam.ParameterName = "@remates";
                rematesParam.DbType = DbType.Int32;
                rematesParam.Value = partidoJugadoVO.Remates;
                rematesParam.Size = 32;
                command.Parameters.Add(rematesParam);


                DbParameter rematesPorteriaParam = command.CreateParameter();
                rematesPorteriaParam.ParameterName = "@rematesPorteria";
                rematesPorteriaParam.DbType = DbType.Int32;
                rematesPorteriaParam.Value = partidoJugadoVO.RematesPorteria;
                rematesPorteriaParam.Size = 32;
                command.Parameters.Add(rematesPorteriaParam);


                DbParameter rematesPosteParam = command.CreateParameter();
                rematesPosteParam.ParameterName = "@rematesPoste";
                rematesPosteParam.DbType = DbType.Int32;
                rematesPosteParam.Value = partidoJugadoVO.RematesPoste;
                rematesPosteParam.Size = 32;
                command.Parameters.Add(rematesPosteParam);


                DbParameter fuerasJuegoParam = command.CreateParameter();
                fuerasJuegoParam.ParameterName = "@fuerasJuego";
                fuerasJuegoParam.DbType = DbType.Int32;
                fuerasJuegoParam.Value = partidoJugadoVO.FuerasJuego;
                fuerasJuegoParam.Size = 32;
                command.Parameters.Add(fuerasJuegoParam);


                DbParameter tarjetasAmarillasProvocadasParam = command.CreateParameter();
                tarjetasAmarillasProvocadasParam.ParameterName = "@tarjetasAmarillasProvocadas";
                tarjetasAmarillasProvocadasParam.DbType = DbType.Int32;
                tarjetasAmarillasProvocadasParam.Value = partidoJugadoVO.TarjetasAmarillasProvocadas;
                tarjetasAmarillasProvocadasParam.Size = 32;
                command.Parameters.Add(tarjetasAmarillasProvocadasParam);


                DbParameter tarjetasRojasProvocadasParam = command.CreateParameter();
                tarjetasRojasProvocadasParam.ParameterName = "@tarjetasRojasProvocadas";
                tarjetasRojasProvocadasParam.DbType = DbType.Int32;
                tarjetasRojasProvocadasParam.Value = partidoJugadoVO.TarjetasRojasProvocadas;
                tarjetasRojasProvocadasParam.Size = 32;
                command.Parameters.Add(tarjetasRojasProvocadasParam);


                DbParameter faltasCometidasParam = command.CreateParameter();
                faltasCometidasParam.ParameterName = "@faltasCometidas";
                faltasCometidasParam.DbType = DbType.Int32;
                faltasCometidasParam.Value = partidoJugadoVO.FaltasCometidas;
                faltasCometidasParam.Size = 32;
                command.Parameters.Add(faltasCometidasParam);


                DbParameter faltasRecibidasParam = command.CreateParameter();
                faltasRecibidasParam.ParameterName = "@faltasRecibidas";
                faltasRecibidasParam.DbType = DbType.Int32;
                faltasRecibidasParam.Value = partidoJugadoVO.FaltasRecibidas;
                faltasRecibidasParam.Size = 32;
                command.Parameters.Add(faltasRecibidasParam);


                DbParameter cornersParam = command.CreateParameter();
                cornersParam.ParameterName = "@corners";
                cornersParam.DbType = DbType.Int32;
                cornersParam.Value = partidoJugadoVO.Corners;
                cornersParam.Size = 32;
                command.Parameters.Add(cornersParam);


                DbParameter balonesRecuperadosParam = command.CreateParameter();
                balonesRecuperadosParam.ParameterName = "@balonesRecuperados";
                balonesRecuperadosParam.DbType = DbType.Int32;
                balonesRecuperadosParam.Value = partidoJugadoVO.BalonesRecuperados;
                balonesRecuperadosParam.Size = 32;
                command.Parameters.Add(balonesRecuperadosParam);


                DbParameter balonesPerdidosParam = command.CreateParameter();
                balonesPerdidosParam.ParameterName = "@balonesPerdidos";
                balonesPerdidosParam.DbType = DbType.Int32;
                balonesPerdidosParam.Value = partidoJugadoVO.BalonesPerdidos;
                balonesPerdidosParam.Size = 32;
                command.Parameters.Add(balonesPerdidosParam);


                DbParameter penaltisCometidosParam = command.CreateParameter();
                penaltisCometidosParam.ParameterName = "@penaltisCometidos";
                penaltisCometidosParam.DbType = DbType.Int32;
                penaltisCometidosParam.Value = partidoJugadoVO.PenaltisCometidos;
                penaltisCometidosParam.Size = 32;
                command.Parameters.Add(penaltisCometidosParam);


                DbParameter penaltisRecibidosParam = command.CreateParameter();
                penaltisRecibidosParam.ParameterName = "@penaltisRecibidos";
                penaltisRecibidosParam.DbType = DbType.Int32;
                penaltisRecibidosParam.Value = partidoJugadoVO.PenaltisRecibidos;
                penaltisRecibidosParam.Size = 32;
                command.Parameters.Add(penaltisRecibidosParam);






                command.Prepare();
                int insertedRows = command.ExecuteNonQuery();
                
                if (insertedRows == 0)
                {            
                    throw new SQLException("errorrrrrrr");
                }


                return partidoJugadoVO;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }

        
        public ArrayList listarPartidosJugadosCompeticionJugador(DbConnection connection, DbTransaction transaction,
            String temporada, int cod_Competicion, int cod_Jugador, int startIndex, int count)
        {
            DbDataReader dataReader = null;

            try
            {
                DbCommand command = connection.CreateCommand();
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }
                
                if (cod_Competicion!=0)
                    command.CommandText = "SELECT co.nombre, co.temporada, pa.Jornada, eq1.Nombre AS eq_local," +
                        "eq2.Nombre AS eq_visitante, pj.Titular, pj.Minutos, pj.Faltas_Cometidas,COUNT(gol.Cod_Gol) AS Goles," +
                        "COUNT(tar.Cod_Tarjeta) AS Tarjetas,pj.cod_partido " +
                        "FROM Partido_Jugado AS pj INNER JOIN " +
                        "Partido AS pa ON pj.Cod_Partido = pa.Cod_Partido AND pj.Cod_Jugador =" + cod_Jugador + " INNER JOIN " +
                        "Competicion AS co ON co.cod_competicion='" + cod_Competicion + "' AND co.Cod_Competicion = pa.Cod_Competicion LEFT OUTER JOIN " +
                             "Gol AS gol ON gol.Cod_Jugador = pj.Cod_Jugador AND gol.Cod_Partido = pj.Cod_Partido INNER JOIN " +
                             "Equipo AS eq1 ON pa.Cod_Local = eq1.Cod_Equipo INNER JOIN " +
                             "Equipo AS eq2 ON pa.Cod_Visitante = eq2.Cod_Equipo LEFT OUTER JOIN " +
                             "Tarjeta AS tar ON tar.Cod_Jugador = pj.Cod_Jugador AND tar.Cod_Partido = pj.Cod_Partido " +
                             "GROUP BY pj.Cod_Partido, pj.Cod_Jugador, co.nombre, co.temporada, pa.Jornada, eq1.Nombre, " +
                             "eq2.Nombre, pj.Titular, pj.Minutos, pj.Faltas_Cometidas";
                else 

                command.CommandText = "SELECT co.nombre, co.temporada, pa.Jornada, eq1.Nombre AS eq_local," +
                    "eq2.Nombre AS eq_visitante, pj.Titular, pj.Minutos, pj.Faltas_Cometidas,COUNT(gol.Cod_Gol) AS Goles," +
                    "COUNT(tar.Cod_Tarjeta) AS Tarjetas,pj.cod_partido " +
                    "FROM Partido_Jugado AS pj INNER JOIN " +
                    "Partido AS pa ON pj.Cod_Partido = pa.Cod_Partido AND pj.Cod_Jugador ="+cod_Jugador+" INNER JOIN " +
                    "Competicion AS co ON co.Temporada='" + temporada + "' AND co.Cod_Competicion = pa.Cod_Competicion LEFT OUTER JOIN " +
                         "Gol AS gol ON gol.Cod_Jugador = pj.Cod_Jugador AND gol.Cod_Partido = pj.Cod_Partido INNER JOIN " +
                         "Equipo AS eq1 ON pa.Cod_Local = eq1.Cod_Equipo INNER JOIN " +
                         "Equipo AS eq2 ON pa.Cod_Visitante = eq2.Cod_Equipo LEFT OUTER JOIN " +
                         "Tarjeta AS tar ON tar.Cod_Jugador = pj.Cod_Jugador AND tar.Cod_Partido = pj.Cod_Partido " +
                         "GROUP BY pj.Cod_Partido, pj.Cod_Jugador, co.nombre, co.temporada, pa.Jornada, eq1.Nombre, " +
                         "eq2.Nombre, pj.Titular, pj.Minutos, pj.Faltas_Cometidas";

                command.Prepare();

                dataReader = command.ExecuteReader();
                

                if (!dataReader.Read())
                {
                 //   throw new InstanceNotFoundException(1, "algo");
                    return null;

                }

                ArrayList partidosJugadosCompeticionJugador = new ArrayList();

                do
                {                  
                    String nombreCompeticion = dataReader.GetString(0);
                   // String temporada = dataReader.GetString(1);
                    String jornada = dataReader.GetString(2);
                    String nombreLocal = dataReader.GetString(3);
                    String nombreVisitante = dataReader.GetString(4);
                    String titular = dataReader.GetString(5);
                    int minutos = dataReader.GetInt32(6);
                    int faltas = dataReader.GetInt32(7);
                    int goles = dataReader.GetInt32(8);
                    int tarjetas = dataReader.GetInt32(9);

                    int cod_Partido = dataReader.GetInt32(10);

                    
                    
                    partidosJugadosCompeticionJugador.Add(new PartidoJugadoJugadorCO(cod_Partido,nombreCompeticion,
                        temporada, jornada, nombreLocal, nombreVisitante, titular, minutos, faltas,
                        goles, tarjetas));

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


        public EstadisticasAgrupadasCO verEstadisticasTemporada(DbConnection connection, 
            DbTransaction transaction, int cod_Jugador,String temporada,int 
            cod_Competicion,String tipo)
        {
            DbDataReader dataReader = null;
            
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                String consulta=null;
                switch (tipo)
                {
                    case "Competicion":
                        consulta = "select ju.cod_jugador,sum(minutos),sum(asistencias)," +
                                "sum(asistencias_gol),sum(remates),sum(remates_porteria)," +
                            "sum(remates_poste),sum(fueras_juego),sum(tarjetas_amarillas_provocadas)," +
                            "sum(tarjetas_rojas_provocadas),sum(faltas_recibidas)," +
                            "sum(faltas_cometidas),sum(corners),sum(balones_recuperados)," +
                            "sum(balones_perdidos),sum(penaltis_recibidos),sum(penaltis_cometidos) " +
                            "from partido_jugado pj JOIN " +
                            "jugador ju on ju.cod_jugador=" + cod_Jugador + " and pj.cod_jugador=ju.cod_jugador JOIN " +
                            "partido p on pj.cod_partido=p.cod_partido and p.cod_competicion="+cod_Competicion+" "+
                            "group by ju.cod_jugador";
                        break;
                    case "Temporada":
                        consulta = "select ju.cod_jugador,sum(minutos),sum(asistencias)," +
                            "sum(asistencias_gol),sum(remates),sum(remates_porteria)," +
                            "sum(remates_poste),sum(fueras_juego),sum(tarjetas_amarillas_provocadas)," +
                            "sum(tarjetas_rojas_provocadas),sum(faltas_recibidas)," +
                            "sum(faltas_cometidas),sum(corners),sum(balones_recuperados)," +
                            "sum(balones_perdidos),sum(penaltis_recibidos),sum(penaltis_cometidos) " +
                            "from partido_jugado pj JOIN " +
                            "jugador ju on ju.cod_jugador=" + cod_Jugador + " and pj.cod_jugador=ju.cod_jugador JOIN " +
                            "partido p on pj.cod_partido=p.cod_partido JOIN " +
                            "competicion c on c.temporada='" + temporada + "' and c.cod_competicion=p.cod_competicion " +
                            "group by ju.cod_jugador";
                        break;
                    default: break;
                }


                command.CommandText = consulta;

                command.Prepare();
                dataReader = command.ExecuteReader();



                if (!dataReader.Read())
                {
                   // throw new InstanceNotFoundException(1, "algo");
                    
                    return null;
                }
                

                
                int minutos = dataReader.GetInt32(1);
                int asistencias = dataReader.GetInt32(2);
                int asistenciasGol=dataReader.GetInt32(3);
                int remates = dataReader.GetInt32(4);
                int rematesPorteria = dataReader.GetInt32(5);
                int rematesPoste = dataReader.GetInt32(6);
                int fuerasJuego = dataReader.GetInt32(7);
                int tarjetasAmarillasProvocadas = dataReader.GetInt32(8);
                int tarjetasRojasProvocadas = dataReader.GetInt32(9);
                int faltasRecibidas = dataReader.GetInt32(10);
                int faltasCometidas = dataReader.GetInt32(11);
                int corners = dataReader.GetInt32(12);
                int balonesRecuperados = dataReader.GetInt32(13);
                int balonesPerdidos = dataReader.GetInt32(14);
                int penaltisRecibidos = dataReader.GetInt32(15);
                int penaltisCometidos = dataReader.GetInt32(16);


                dataReader.Close();

                return new EstadisticasAgrupadasCO(cod_Jugador, minutos, asistencias,
                    asistenciasGol, remates, rematesPorteria, rematesPoste, fuerasJuego,
                    tarjetasAmarillasProvocadas, tarjetasRojasProvocadas, faltasRecibidas,
                    faltasCometidas, corners, balonesRecuperados, balonesPerdidos,
                    penaltisRecibidos, penaltisCometidos);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }


        public List<PartidoJugadoBasicoCO> buscarJugadoresTitularesEquipoPartido(DbConnection connection, DbTransaction transaction,
            int cod_Equipo, int cod_Partido,String titulares)
        {

            DbDataReader dataReader = null;

            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT ju.Cod_Jugador,pj.Cod_Partido,int.Nombre," +
                    "int.Apellidos, pj.minutos, pj.faltas_cometidas,hi.dorsal,ju.cod_Integrante " +
                    "FROM Integrante AS int INNER JOIN Hco_Integrante AS hi " +
                    "ON int.Cod_Int = hi.Cod_Integrante INNER JOIN Jugador AS ju " +
                    "ON hi.Cod_Integrante = ju.Cod_Integrante AND hi.Cod_Equipo = ju.Cod_Equipo " +
                    "AND hi.Version_Integrante = ju.Version_Integrante INNER JOIN " +
                    "Partido_Jugado AS pj ON pj.Cod_Jugador = ju.Cod_Jugador " +
                    "WHERE     (ju.Cod_Equipo =" + cod_Equipo + ") AND (pj.Cod_Partido =" + cod_Partido + ") "+
                    "AND (pj.Titular = '" + titulares + "') ORDER BY hi.dorsal";
                command.Prepare();

                 
                dataReader = command.ExecuteReader();
                

                if (!dataReader.Read())
                {
                    return null;
                    //throw new InstanceNotFoundException(1, "algo");
                }


                var nombresJugadoresTitulares = new List<PartidoJugadoBasicoCO>();

                do
                {
                    int cod_jugador = dataReader.GetInt32(0);
                    String nombre = dataReader.GetString(2);
                    String apellido = dataReader.GetString(3);
                    int minutos=dataReader.GetInt32(4);
                    int faltas_cometidas=dataReader.GetInt32(5);
                    int dorsal = dataReader.GetInt32(6);
                    int cod_Integrante = dataReader.GetInt32(7);
                    PartidoJugadoBasicoCO partidoJugadoBasicoCO=
                        new PartidoJugadoBasicoCO(cod_Partido,cod_jugador,nombre+" "+apellido,
                        minutos,faltas_cometidas,dorsal,cod_Integrante);
                    nombresJugadoresTitulares.Add(partidoJugadoBasicoCO);

                }
                while (dataReader.Read());

                return nombresJugadoresTitulares;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }




        }


        public List<TemporadaCO> temporadasConPartidosJugados(DbConnection connection, DbTransaction transaction,
            int cod_Jugador)
        {
            DbDataReader dataReader = null;

            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT distinct comp.temporada from Partido_Jugado paju INNER JOIN " +
                "partido pa on paju.cod_jugador="+cod_Jugador+" and paju.cod_partido=pa.cod_partido INNER JOIN " +
                "competicion comp on pa.cod_competicion=comp.cod_competicion";
                command.Prepare();
                dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                {
                   // throw new InstanceNotFoundException(1, "algo");
                    return null;
                }


                var temporadasConPartidosJugados = new List<TemporadaCO>();

                do
                {
                    String temporada = dataReader.GetString(0);

                    temporadasConPartidosJugados.Add(new TemporadaCO(temporada));

                }
                while (dataReader.Read());

                return temporadasConPartidosJugados;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }

        }



        public EstadisticasAgrupadasCO verEstadisticasJugadorPartido(DbConnection connection,
            DbTransaction transaction, int cod_Jugador, int cod_Partido)
        {
            DbDataReader dataReader = null;

            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                String consulta = null;

                consulta = "select titular,minutos,asistencias," +
                        "asistencias_gol,remates,remates_porteria," +
                    "remates_poste,fueras_juego,tarjetas_amarillas_provocadas," +
                    "tarjetas_rojas_provocadas,faltas_recibidas," +
                    "faltas_cometidas,corners,balones_recuperados," +
                    "balones_perdidos,penaltis_recibidos,penaltis_cometidos " +
                    "from partido_jugado pj where pj.cod_jugador=" + cod_Jugador +
                    " and pj.cod_Partido=" + cod_Partido;
                        


                command.CommandText = consulta;

                command.Prepare();
                dataReader = command.ExecuteReader();



                if (!dataReader.Read())
                {
                    // throw new InstanceNotFoundException(1, "algo");

                    return null;
                }



                int minutos = dataReader.GetInt32(1);
                int asistencias = dataReader.GetInt32(2);
                int asistenciasGol = dataReader.GetInt32(3);
                int remates = dataReader.GetInt32(4);
                int rematesPorteria = dataReader.GetInt32(5);
                int rematesPoste = dataReader.GetInt32(6);
                int fuerasJuego = dataReader.GetInt32(7);
                int tarjetasAmarillasProvocadas = dataReader.GetInt32(8);
                int tarjetasRojasProvocadas = dataReader.GetInt32(9);
                int faltasRecibidas = dataReader.GetInt32(10);
                int faltasCometidas = dataReader.GetInt32(11);
                int corners = dataReader.GetInt32(12);
                int balonesRecuperados = dataReader.GetInt32(13);
                int balonesPerdidos = dataReader.GetInt32(14);
                int penaltisRecibidos = dataReader.GetInt32(15);
                int penaltisCometidos = dataReader.GetInt32(16);


                dataReader.Close();

                return new EstadisticasAgrupadasCO(cod_Jugador, minutos, asistencias,
                    asistenciasGol, remates, rematesPorteria, rematesPoste, fuerasJuego,
                    tarjetasAmarillasProvocadas, tarjetasRojasProvocadas, faltasRecibidas,
                    faltasCometidas, corners, balonesRecuperados, balonesPerdidos,
                    penaltisRecibidos, penaltisCometidos);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }

    
    }
}
