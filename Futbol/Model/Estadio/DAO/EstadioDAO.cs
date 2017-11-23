using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Util.Exceptions;
using Util.Log;
using Futbol.Model.Estadio.VO;
using System.Data;
using System.Data.Common;


/*queda meter un metodo de obtener estadio por nombre*/






namespace Futbol.Model.Estadio.DAO
{
    public class EstadioDAO
    {



        public EstadioVO create(DbConnection connection, DbTransaction transaction, EstadioVO estadioVO)
        {
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "INSERT INTO Estadio (nombre,capacidad,direccion,tipo,foto) values (@nombre,@capacidad,@direccion,@tipo,@foto)";

                DbParameter nombreParam = command.CreateParameter();
                nombreParam.ParameterName = "@nombre";
                nombreParam.DbType = DbType.String;
                nombreParam.Value = estadioVO.Nombre;
                nombreParam.Size = 32;
                command.Parameters.Add(nombreParam);
                
                
                
                
                DbParameter capacidadParam = command.CreateParameter();
                capacidadParam.ParameterName = "@capacidad";
                capacidadParam.DbType = DbType.Int32;
                capacidadParam.Value = estadioVO.Capacidad;
                capacidadParam.Size = 32;
                command.Parameters.Add(capacidadParam);


                DbParameter direccionParam = command.CreateParameter();
                direccionParam.ParameterName = "@direccion";
                direccionParam.DbType = DbType.String;
                direccionParam.Value = estadioVO.Direccion;
                direccionParam.Size = 100;
                command.Parameters.Add(direccionParam);

                DbParameter tipoParam = command.CreateParameter();
                tipoParam.ParameterName = "@tipo";
                tipoParam.DbType = DbType.String;
                tipoParam.Value = estadioVO.Tipo;
                tipoParam.Size = 15;
                command.Parameters.Add(tipoParam);


                DbParameter fotoParam = command.CreateParameter();
                fotoParam.ParameterName = "@foto";
                fotoParam.DbType = DbType.String;
                fotoParam.Size = 50;
                if (estadioVO.Foto == null) fotoParam.Value = DBNull.Value;
                else fotoParam.Value = estadioVO.Foto;

                command.Parameters.Add(fotoParam);

                command.Prepare();
                int insertedRows = command.ExecuteNonQuery();
                

                if (insertedRows == 0)
                {
                    throw new SQLException("errorrrrrrr");
                }

                IEstadioIdentifierRetriever estadioIdentifierRetriever = EstadioIdentifierRetrieverFactory.GetRetriever();
                Int64 estadioIdentifier = estadioIdentifierRetriever.GetGeneratedIdentifier(connection,transaction);



                return new EstadioVO((int)estadioIdentifier, estadioVO.Nombre,estadioVO.Capacidad, estadioVO.Direccion,
                    estadioVO.Tipo, estadioVO.Foto);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }



        }

        
        
        public ArrayList listarEstadios(DbConnection connection, DbTransaction transaction,
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
                "SELECT * from estadio";
                command.Prepare();
                
                dataReader = command.ExecuteReader();
                if (!dataReader.Read())
                {
                    throw new InstanceNotFoundException(1, "estadio");

                }

                ArrayList estadios = new ArrayList();
                
                do
                {
                    int cod_estadio = dataReader.GetInt32(0);
                    String nombre = dataReader.GetString(1);
                    int capacidad = dataReader.GetInt32(2);
                    String direccion = dataReader.GetString(3);
                    String tipo = dataReader.GetString(4);
                    String foto = dataReader.GetString(5);

                    estadios.Add(new EstadioVO(cod_estadio,nombre, capacidad, direccion, tipo, foto));
                }
                while (dataReader.Read());
                
                /*no se si hay q poner el close*/
                
                dataReader.Close();
                
                return estadios;
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);
            }
            finally { dataReader.Close(); }
        }



        public EstadioVO buscarEstadioId(DbConnection connection, DbTransaction transaction, int id_Estadio)
        {

            DbDataReader dataReader = null;
            
            try
            {
                DbCommand command = connection.CreateCommand();

                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = "SELECT * FROM Estadio where cod_estadio=" + id_Estadio;
                command.Prepare();



                dataReader = command.ExecuteReader();
                
                if (!dataReader.Read())
                {
                    throw new InstanceNotFoundException(1, "estadio");

                }

                
                int cod_estadio = dataReader.GetInt32(0);
                String nombre = dataReader.GetString(1);
                int capacidad = dataReader.GetInt32(2);
                String direccion = dataReader.GetString(3);
                String tipo = dataReader.GetString(4);

                /*ojo, esto es para trabajar con valores que pueden ser
                 * nulos en la BD*/  
                String foto = Convert.ToString(dataReader.GetValue(5));

                dataReader.Close();

                return new EstadioVO(cod_estadio,nombre, capacidad, direccion,
                    tipo, foto);
            }
            catch (DbException e)
            {
                throw new InternalErrorException(e);

            }



        }



    }
}
