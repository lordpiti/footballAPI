using System;
using System.Data.Common;

namespace Futbol.Model.Estadio.DAO
{
    interface IEstadioIdentifierRetriever
    {
        /// <summary>
        /// Returns the last Critica Identifier generated
        /// </summary>
        Int64 GetGeneratedIdentifier(DbConnection connection,DbTransaction transaction); 
    }
}
