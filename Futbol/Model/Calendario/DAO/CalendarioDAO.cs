using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;
using Util.Log;
using Futbol.Model.Calendario.VO;
using System.Data;
using System.Data.Common;

namespace Futbol.Model.Calendario.DAO
{
     public class CalendarioDAO
    {

         public CalendarioVO create(DbConnection connection, DbTransaction transaction, CalendarioVO calendarioVO)
         {
             try
             {
                 DbCommand command = connection.CreateCommand();

                 if (transaction != null)
                 {
                     command.Transaction = transaction;
                     
                 }


                 command.CommandText = "INSERT INTO Calendario (cod_competicion, jornada, cod_Local," +
                 "cod_Visitante, fecha) values " +
                 "(@cod_competicion, @jornada, @cod_Local, @cod_Visitante, @fecha)";

                 DbParameter cod_competicionParam = command.CreateParameter();
                 cod_competicionParam.ParameterName = "@cod_competicion";
                 cod_competicionParam.DbType = DbType.Int32;
                 cod_competicionParam.Value = calendarioVO.Cod_Competicion;
                 cod_competicionParam.Size = 32;
                 command.Parameters.Add(cod_competicionParam);


                 DbParameter jornadaParam = command.CreateParameter();
                 jornadaParam.ParameterName = "@jornada";
                 jornadaParam.DbType = DbType.String;
                 jornadaParam.Value = calendarioVO.Jornada;
                 jornadaParam.Size = 32;
                 command.Parameters.Add(jornadaParam);


                 DbParameter cod_LocalParam = command.CreateParameter();
                 cod_LocalParam.ParameterName = "@cod_Local";
                 cod_LocalParam.DbType = DbType.Int32;
                 cod_LocalParam.Value = calendarioVO.Cod_Local;
                 cod_LocalParam.Size = 32;
                 command.Parameters.Add(cod_LocalParam);


                 DbParameter cod_VisitanteParam = command.CreateParameter();
                 cod_VisitanteParam.ParameterName = "@cod_Visitante";
                 cod_VisitanteParam.DbType = DbType.Int32;
                 cod_VisitanteParam.Value = calendarioVO.Cod_Visitante;
                 cod_VisitanteParam.Size = 32;
                 command.Parameters.Add(cod_VisitanteParam);


                

                 DbParameter fechaParam = command.CreateParameter();
                 fechaParam.ParameterName = "@fecha";
                 fechaParam.DbType = DbType.DateTime;
                 fechaParam.Value = calendarioVO.Fecha;
                 fechaParam.Size = 100;
                 command.Parameters.Add(fechaParam);


                 command.Prepare();
                 
                 int insertedRows = command.ExecuteNonQuery();
                 

                 if (insertedRows == 0)
                 {
                     throw new SQLException("errorrrrrrr");
                 }

                 ICalendarioIdentifierRetriever calendarioIdentifierRetriever = CalendarioIdentifierRetrieverFactory.GetRetriever();

                 Int64 calendarioIdentifier = calendarioIdentifierRetriever.GetGeneratedIdentifier(connection,transaction);




                 return new CalendarioVO((int)calendarioIdentifier, calendarioVO.Cod_Competicion,calendarioVO.Jornada, 
                     calendarioVO.Cod_Local,calendarioVO.Cod_Visitante, calendarioVO.Fecha);
             }
             catch (DbException e)
             {
                 throw new InternalErrorException(e);

             }
         }
         

         
         
         public ArrayList verCalendarioCompeticionJornada(DbConnection connection, DbTransaction transaction,
             int cod_Competicion,String jornada)
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
                    "SELECT cal.jornada,cal.fecha,e1.nombre, e2.nombre,co.nombre FROM "+
                    "calendario cal INNER JOIN equipo e1 on (cal.cod_Local=e1.cod_equipo and "+
                    "cal.cod_competicion="+cod_Competicion+" and cal.jornada='"+jornada+"') INNER JOIN equipo e2 on "+
                    "(cal.cod_Visitante=e2.cod_equipo) INNER JOIN competicion co on "+
                    "cal.cod_competicion=co.cod_competicion";
                command.Prepare();
                
                dataReader = command.ExecuteReader();
                
                if (!dataReader.Read())
                {
                   // throw new InstanceNotFoundException(1, "algo");
                    return null;

                }

                ArrayList listaCalendario = new ArrayList();

                do
                {
                    DateTime fecha = dataReader.GetDateTime(1);
                    String nombreLocal = dataReader.GetString(2);
                    String nombreVisitante = dataReader.GetString(3);
                    String nombreCompeticion = dataReader.GetString(4);
                    listaCalendario.Add(new CalendarioCO(nombreLocal,nombreVisitante,
                        nombreCompeticion,jornada,fecha));
                }
                while (dataReader.Read());


                return listaCalendario;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { 
                dataReader.Close();
                
            }
        }
    }
}
