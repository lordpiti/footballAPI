using System;
using System.Data.Common;
using System.Configuration;
using Util.Exceptions;
using System.Data;

namespace Futbol.Model.Cambio.DAO
{
    /// <summary>
    /// Clase que recupera el identifer de la crítica generado
    /// </summary>
    public class GenericCambioIdentifierRetriever : ICambioIdentifierRetriever
    {
        private const String QUERY_PARAMETER =
                "GenericCambioIdentifierRetriever/query";

        private static String queryString =
                ConfigurationManager.AppSettings[QUERY_PARAMETER];

        /// <summary>
        /// Returns the last Critica Identifier generated
        /// </summary>
        /// <param name="connection">DataBase Connection</param>
        /// <exception cref="InternalErrorException"/>        
        public Int64 GetGeneratedIdentifier(DbConnection connection,DbTransaction transaction)
        {

            DbCommand command = null;

            try
            {

                command = connection.CreateCommand();
                command.CommandText = queryString;
                command.Transaction = transaction;

                Int64 identity = Convert.ToInt64(command.ExecuteScalar());

                return identity;

            }
            catch (Exception e)
            {

                throw new InternalErrorException(e);
            }

        }
    }
}
