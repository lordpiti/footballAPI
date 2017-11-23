using System;
using System.Data.Common;

namespace Futbol.Model.Arbitro.DAO
{
    interface IArbitroIdentifierRetriever
    {
        /// <summary>
        /// Returns the last Critica Identifier generated
        /// </summary>
        Int64 GetGeneratedIdentifier(DbConnection connection); 
    }
}
