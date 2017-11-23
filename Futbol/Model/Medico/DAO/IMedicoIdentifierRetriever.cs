using System;
using System.Data.Common;

namespace Futbol.Model.Medico.DAO
{
    interface IMedicoIdentifierRetriever
    {
        /// <summary>
        /// Returns the last Critica Identifier generated
        /// </summary>
        Int64 GetGeneratedIdentifier(DbConnection connection); 
    }
}
