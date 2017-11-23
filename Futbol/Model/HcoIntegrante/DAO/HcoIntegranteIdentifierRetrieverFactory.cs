using System;
using System.Configuration;
using System.Reflection;
using System.Runtime.Remoting;
using Util.Exceptions;
using System.Data.Common;
using System.Data;
using Futbol.Model.HcoIntegrante.VO;


namespace Futbol.Model.HcoIntegrante.DAO
{
    /// <summary>
    /// A factory to get <code>CriticaIdentifierRetriever</code> objects.
    /// Requered configuration properties:
    ///   - <code>CriticaIdentifierRetrieverFactory/retrieverClassName</code>: 
    ///           it must specify the full class name of the class implementing
    ///            <code>EntityIdentifierRetriever</code>
    /// </summary>
   class HcoIntegranteIdentifierRetrieverFactory
    {
        private const String RETRIEVER_CLASS_NAME_PARAMETER =
            "HcoIntegranteIdentifierRetrieverFactory/retrieverClassName";

        private HcoIntegranteIdentifierRetrieverFactory() { }

       internal IHcoIntegranteIdentifierRetriever IHcoIntegranteIdentifierRetriever
       {
           get
           {
               throw new System.NotImplementedException();
           }
           set
           {
           }
       }

        public static IHcoIntegranteIdentifierRetriever GetRetriever() {

            Object theObject = null;

            try {

                String retrieverClassName =
                    ConfigurationManager.AppSettings[RETRIEVER_CLASS_NAME_PARAMETER];

                Assembly assembly = Assembly.GetExecutingAssembly();

                theObject = AppDomain.CurrentDomain.
                    CreateInstanceAndUnwrap(assembly.FullName, retrieverClassName);

            } catch (Exception e) {
                throw new InternalErrorException(e);
            }

            return (IHcoIntegranteIdentifierRetriever)theObject;

        }
    }
}
