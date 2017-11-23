using System;
using System.Data;
using System.Reflection;
using System.Runtime.Remoting;

using Es.UDC.DotNet.Util.Exceptions;
using System.Configuration;
using System.Data.Common;

/* For Testing only */
using Futbol.Model.Gol.VO;
using Es.UDC.DotNet.Util.Log;
using System.Collections;

namespace Futbol.Model.Gol.DAO
{
    /// <summary>
    /// A factory to get <code>ICriticaProfileDAO</code> objects.
    /// Required configuration parameters:
    /// <code>CriticaProfileDAOFactory/daoClassName</code>: it must specify the 
    /// full class name of the class implementing <code>ICriticaProfileDAO</code>.
    /// </summary> 
    public sealed class GolDAOFactory
    {
        /* NOTE: constans are implicitly static */
        private const String DAO_CLASS_NAME_PARAMETER =
            "GolDAOFactory/daoClassName";

        /* NOTE: Class constructor must be private, so nobody will be allowed to 
         * instantiate it      
         */
        private GolDAOFactory() { }

        public GolDAO GolDAO
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Static method creates the instance specified in the configuration 
        /// parameters <code>CriticaProfileDAOFactory/daoClassName</code>
        /// </summary>
        /// <returns>
        /// Returns an instance of the <code>ICriticaProfileDAO</code> interface
        /// </returns>
        /// <exception cref="ConfigurationParameterException"/> 
        /// <exception cref="InternalErrorException"/>     
        public static GolDAO GetDAO() {

            try {
                String daoClassName = ConfigurationManager.
                    AppSettings[DAO_CLASS_NAME_PARAMETER];

                Assembly assembly = Assembly.GetExecutingAssembly();

                Object theObject = AppDomain.CurrentDomain.
                    CreateInstanceAndUnwrap(assembly.FullName, daoClassName);

                return (GolDAO)theObject;

            } catch (Exception e) {

                throw new InternalErrorException(e);
            }

        }

        #region Test Code Region. Uncomment for testing.

        /*
        /// <summary>
        /// Test region
        /// </summary>
        
        public static void Main(string[] args) {

            DbConnection connection = null;
            DbTransaction transaction = null;
            Boolean commited = false;

            CriticaProfileVO criticaProfileVO =
               new CriticaProfileVO(-1, 4,"buen libro","juan",1);

            CriticaProfileVO criticaProfileVO2 =
               new CriticaProfileVO(-1, 3,"libro mediocre","pablo",1);

        //    Encloses all data access code within a try block 
              try {

               String providerInvariantName = ConfigurationManager.
                    AppSettings["CriticaProfileDAOFactory/providerInvariantName"];

                String connectionString = ConfigurationManager.
                    AppSettings["CriticaProfileDAOFactory/connectionString"];

        //         * Returns an instance of a 
        //         * System.Data.Common.DbProviderFactory for the 
        //         * specified providerName
        //         *

                DbProviderFactory dbFactory = DbProviderFactories.
                    GetFactory(providerInvariantName);

        //        Create and open the connection 
                connection = dbFactory.CreateConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

        //         Get DAO 
                ICriticaProfileDAO dao = CriticaProfileDAOFactory.GetDAO();

        //         * INFO: all commands executed after a transaction creation
        //         * must be associated with this transaction while it remains 
        //         * active (i.e. transaction.Commit() not executed)
        //         *


        //         Test DAO.Create 
                 dao.Create(connection, transaction, criticaProfileVO);
                 dao.Create(connection, transaction, criticaProfileVO2);

                  LogManager.RecordMessage("Critica by juan created",
                    LogManager.MessageType.INFO);
                  LogManager.RecordMessage("Critica by pablo created",
                    LogManager.MessageType.INFO);

        //         Test DAO.Find 
                  ArrayList encontrados = dao.Find(connection, transaction, 1);

                  IEnumerator enumerator = encontrados.GetEnumerator();

                  while (enumerator.MoveNext()) {
                      LogManager.RecordMessage("Critica found: " + enumerator.Current, 
                          LogManager.MessageType.INFO);
                    }


        //         Tests OK. 
                    LogManager.RecordMessage("Tests OK !!!",
                    LogManager.MessageType.INFO);

            } catch (Exception e) {
                LogManager.RecordMessage("Exception Message: " + e.Message,
                    LogManager.MessageType.ERROR);
                LogManager.RecordMessage("Exception StackTrace: " + e.StackTrace,
                    LogManager.MessageType.ERROR);

            } finally {

                    if (!commited) {
                        if (transaction != null)
                        transaction.Rollback();
                }

                // Ensures connection is closed
                if (connection.State.Equals(ConnectionState.Open))
                    connection.Close();
            }

            Console.ReadLine();
            
        }
        */
        #endregion

    }
}
