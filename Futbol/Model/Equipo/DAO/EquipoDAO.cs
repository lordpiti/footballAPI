using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;
using Util.Log;
using Futbol.Model.Equipo.VO;
using System.Data;
using System.Data.Common;








namespace Futbol.Model.Equipo.DAO
{
    public class EquipoDAO
    {


        public EquipoVO create(DbConnection connection, DbTransaction transaction, EquipoVO equipoVO)
        {
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "INSERT INTO Equipo (localidad,nombre,cod_Estadio,foto_Escudo,foto_Plantilla) values "+
                    "(@ciudad,@nombre,@cod_Estadio,@fotoEscudo,@fotoPlantilla)";

                DbParameter ciudadParam = command.CreateParameter();
                ciudadParam.ParameterName = "@ciudad";
                ciudadParam.DbType = DbType.String;
                ciudadParam.Value = equipoVO.Ciudad;
                ciudadParam.Size = 20;
                command.Parameters.Add(ciudadParam);


                DbParameter nombreParam = command.CreateParameter();
                nombreParam.ParameterName = "@nombre";
                nombreParam.DbType = DbType.String;
                nombreParam.Value = equipoVO.Nombre;
                nombreParam.Size = 20;
                command.Parameters.Add(nombreParam);


                DbParameter cod_EstadioParam = command.CreateParameter();
                cod_EstadioParam.ParameterName = "@cod_Estadio";
                cod_EstadioParam.DbType = DbType.Int32;
                cod_EstadioParam.Size = 32;
                cod_EstadioParam.Value = equipoVO.Cd_Estadio;
                command.Parameters.Add(cod_EstadioParam);


                DbParameter fotoEscudoParam = command.CreateParameter();
                fotoEscudoParam.ParameterName = "@fotoEscudo";
                fotoEscudoParam.DbType = DbType.String;
                fotoEscudoParam.Size = 50;
                fotoEscudoParam.Value = equipoVO.FotoEscudo;
                command.Parameters.Add(fotoEscudoParam);


                DbParameter fotoPlantillaParam = command.CreateParameter();
                fotoPlantillaParam.ParameterName = "@fotoPlantilla";
                fotoPlantillaParam.DbType = DbType.String;
                fotoPlantillaParam.Size = 50;
                fotoPlantillaParam.Value = equipoVO.FotoPlantilla;
                command.Parameters.Add(fotoPlantillaParam);

                command.Prepare();
                int insertedRows = command.ExecuteNonQuery();
                
                if (insertedRows == 0)
                {            
                    throw new SQLException("errorrrrrrr");
                }

                IEquipoIdentifierRetriever equipoIdentifierRetriever = EquipoIdentifierRetrieverFactory.GetRetriever();
                Int64 equipoIdentifier = equipoIdentifierRetriever.GetGeneratedIdentifier(connection,transaction);

                return new EquipoVO((int)equipoIdentifier, equipoVO.Nombre, equipoVO.Ciudad, 
                    equipoVO.Cd_Estadio,equipoVO.FotoEscudo,equipoVO.FotoPlantilla);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
        }

        
        
        public ArrayList listarEquipos(DbConnection connection, DbTransaction transaction,
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

                "SELECT * from equipo";
                command.Prepare();
                
                dataReader = command.ExecuteReader();
                if (!dataReader.Read())
                {
                    throw new InstanceNotFoundException(1, "equipo");

                }

                ArrayList equipos = new ArrayList();
                
                do
                {
                    int cod_Equipo = dataReader.GetInt32(0);
                    String nombre = dataReader.GetString(1);
                    String ciudad = dataReader.GetString(2);
                    int cod_Estadio = dataReader.GetInt32(3);
                    String fotoEscudo = dataReader.GetString(4);
                    String fotoPlantilla = dataReader.GetString(5);

                    equipos.Add(new EquipoVO(cod_Equipo, nombre, ciudad, cod_Estadio,fotoEscudo,fotoPlantilla));
                }
                while (dataReader.Read());
                             
                return equipos;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }



        public EquipoVO buscarEquipoId(DbConnection connection, DbTransaction transaction, int id_Equipo)
        {
            DbDataReader dataReader = null;
            
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT * FROM Equipo where cod_Equipo=" + id_Equipo;
                command.Prepare();
                dataReader = command.ExecuteReader();
                
                if (!dataReader.Read())
                {
                    throw new InstanceNotFoundException(1, "equipo");

                }
                
                int cod_Equipo = dataReader.GetInt32(0);
                String nombre = dataReader.GetString(1);
                String ciudad = dataReader.GetString(2);
                int cod_Estadio = dataReader.GetInt32(3);
                String fotoEscudo = dataReader.GetString(4);
                String fotoPlantilla = dataReader.GetString(5);


                return new EquipoVO(cod_Equipo, nombre, ciudad,cod_Estadio,fotoEscudo,fotoPlantilla);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }
            finally { dataReader.Close(); }
        }
    }
}
