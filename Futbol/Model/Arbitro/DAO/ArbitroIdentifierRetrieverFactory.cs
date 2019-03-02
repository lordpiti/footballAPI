using System;
using System.Configuration;
using System.Reflection;

using Util.Exceptions;
using System.Data.Common;
using System.Data;
using Futbol.Model.Arbitro.VO;


namespace Futbol.Model.Arbitro.DAO
{

   class ArbitroIdentifierRetrieverFactory
    {
        private const String RETRIEVER_CLASS_NAME_PARAMETER =
            "ArbitroIdentifierRetrieverFactory/retrieverClassName";

        private ArbitroIdentifierRetrieverFactory() { }

       internal IArbitroIdentifierRetriever IArbitroIdentifierRetriever
       {
           get
           {
               throw new System.NotImplementedException();
           }
           set
           {
           }
       }

        public static IArbitroIdentifierRetriever GetRetriever() {

            Object theObject = null;

            try {

                string retrieverClassName =
                    ConfigurationManager.AppSettings[RETRIEVER_CLASS_NAME_PARAMETER];

                Assembly assembly = Assembly.GetExecutingAssembly();

                theObject = Activator.CreateInstance(assembly.GetType(retrieverClassName));

            } catch (Exception e) {
                throw new InternalErrorException(e);
            }

            return (IArbitroIdentifierRetriever)theObject;

        }
    }
}
