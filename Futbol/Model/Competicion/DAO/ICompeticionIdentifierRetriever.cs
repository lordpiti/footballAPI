using System;
using System.Data.Common;

namespace Futbol.Model.Competicion.DAO
{
    interface ICompeticionIdentifierRetriever
    {
        /// <summary>
        /// Returns the last Critica Identifier generated
        /// </summary>
        Int64 GetGeneratedIdentifier(DbConnection connection, DbTransaction transaction); 
    }
}
