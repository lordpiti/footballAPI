using System;
using System.Configuration;
using System.Reflection;

using Util.Exceptions;
using System.Data.Common;
using System.Data;
using Futbol.Model.Jugador.VO;


namespace Futbol.Model.Jugador.DAO
{
    /// <summary>
    /// A factory to get <code>CriticaIdentifierRetriever</code> objects.
    /// Requered configuration properties:
    ///   - <code>CriticaIdentifierRetrieverFactory/retrieverClassName</code>: 
    ///           it must specify the full class name of the class implementing
    ///            <code>EntityIdentifierRetriever</code>
    /// </summary>
   class JugadorIdentifierRetrieverFactory
    {
        private const String RETRIEVER_CLASS_NAME_PARAMETER =
            "JugadorIdentifierRetrieverFactory/retrieverClassName";

        private JugadorIdentifierRetrieverFactory() { }

       internal IJugadorIdentifierRetriever IJugadorIdentifierRetriever
       {
           get
           {
               throw new System.NotImplementedException();
           }
           set
           {
           }
       }

        public static IJugadorIdentifierRetriever GetRetriever() {

            Object theObject = null;

            try {

                String retrieverClassName =
                    ConfigurationManager.AppSettings[RETRIEVER_CLASS_NAME_PARAMETER];

                Assembly assembly = Assembly.GetExecutingAssembly();

                theObject = Activator.CreateInstance(assembly.GetType(retrieverClassName));

            } catch (Exception e) {
                throw new InternalErrorException(e);
            }

            return (IJugadorIdentifierRetriever)theObject;

        }
    }
}
