using System;
using System.Configuration;
using System.Reflection;

using Util.Exceptions;
using System.Data.Common;
using System.Data;
using Futbol.Model.Partido.VO;


namespace Futbol.Model.Partido.DAO
{
    /// <summary>
    /// A factory to get <code>CriticaIdentifierRetriever</code> objects.
    /// Requered configuration properties:
    ///   - <code>CriticaIdentifierRetrieverFactory/retrieverClassName</code>: 
    ///           it must specify the full class name of the class implementing
    ///            <code>EntityIdentifierRetriever</code>
    /// </summary>
   class PartidoIdentifierRetrieverFactory
    {
        private const String RETRIEVER_CLASS_NAME_PARAMETER =
            "PartidoIdentifierRetrieverFactory/retrieverClassName";

        private PartidoIdentifierRetrieverFactory() { }

       internal IPartidoIdentifierRetriever IPartidoIdentifierRetriever
       {
           get
           {
               throw new System.NotImplementedException();
           }
           set
           {
           }
       }

        public static IPartidoIdentifierRetriever GetRetriever() {

            Object theObject = null;

            try {

                String retrieverClassName =
                    ConfigurationManager.AppSettings[RETRIEVER_CLASS_NAME_PARAMETER];

                Assembly assembly = Assembly.GetExecutingAssembly();

                theObject = Activator.CreateInstance(assembly.GetType(retrieverClassName));

            } catch (Exception e) {
                throw new InternalErrorException(e);
            }

            return (IPartidoIdentifierRetriever)theObject;

        }
    }
}
