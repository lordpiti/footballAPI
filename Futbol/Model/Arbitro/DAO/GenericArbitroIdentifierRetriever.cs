using System;
using System.Data.Common;
using System.Configuration;
using Util.Exceptions;
using System.Data;

namespace Futbol.Model.Arbitro.DAO
{
    /// <summary>
    /// Clase que recupera el identifier de la crítica generado
    /// </summary>
    public class GenericArbitroIdentifierRetriever : IArbitroIdentifierRetriever
    {
        private const String QUERY_PARAMETER =
                "GenericArbitroIdentifierRetriever/query";

        private static String queryString =
                ConfigurationManager.AppSettings[QUERY_PARAMETER];

        /// <summary>
        /// Returns the last Critica Identifier generated
        /// </summary>
        /// <param name="connection">DataBase Connection</param>
        /// <exception cref="InternalErrorException"/>        
        public Int64 GetGeneratedIdentifier(DbConnection connection)
        {

            DbCommand command = null;

            try
            {

                command = connection.CreateCommand();
                command.CommandText = queryString;

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
