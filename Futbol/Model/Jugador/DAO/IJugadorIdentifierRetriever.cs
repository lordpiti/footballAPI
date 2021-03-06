using System;
using System.Data.Common;

namespace Futbol.Model.Jugador.DAO
{
    interface IJugadorIdentifierRetriever
    {
        /// <summary>
        /// Returns the last Critica Identifier generated
        /// </summary>
        Int64 GetGeneratedIdentifier(DbConnection connection, DbTransaction transaction); 
    }
}
