using System;
using System.Configuration;
using System.Reflection;

using Util.Exceptions;
using System.Data.Common;
using System.Data;
using Futbol.Model.Gol.VO;


namespace Futbol.Model.Gol.DAO
{
    /// <summary>
    /// A factory to get <code>CriticaIdentifierRetriever</code> objects.
    /// Requered configuration properties:
    ///   - <code>CriticaIdentifierRetrieverFactory/retrieverClassName</code>: 
    ///           it must specify the full class name of the class implementing
    ///            <code>EntityIdentifierRetriever</code>
    /// </summary>
   class GolIdentifierRetrieverFactory
    {
        private const String RETRIEVER_CLASS_NAME_PARAMETER =
            "GolIdentifierRetrieverFactory/retrieverClassName";

        private GolIdentifierRetrieverFactory() { }

       internal IGolIdentifierRetriever IGolIdentifierRetriever
       {
           get
           {
               throw new System.NotImplementedException();
           }
           set
           {
           }
       }

        public static IGolIdentifierRetriever GetRetriever() {

            Object theObject = null;

            try {

                String retrieverClassName =
                    ConfigurationManager.AppSettings[RETRIEVER_CLASS_NAME_PARAMETER];

                Assembly assembly = Assembly.GetExecutingAssembly();

                theObject = Activator.CreateInstance(assembly.GetType(retrieverClassName));

            } catch (Exception e) {
                throw new InternalErrorException(e);
            }

            return (IGolIdentifierRetriever)theObject;

        }
    }
}
