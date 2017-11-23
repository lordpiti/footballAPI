using System;
using System.Data;
using System.Reflection;
using System.Runtime.Remoting;

using Util.Exceptions;
using System.Configuration;
using System.Data.Common;

/* For Testing only */
using Futbol.Model.Jugador.VO;
using Util.Log;
using System.Collections;

namespace Futbol.Model.Jugador.DAO
{
    /// <summary>
    /// A factory to get <code>ICriticaProfileDAO</code> objects.
    /// Required configuration parameters:
    /// <code>CriticaProfileDAOFactory/daoClassName</code>: it must specify the 
    /// full class name of the class implementing <code>ICriticaProfileDAO</code>.
    /// </summary> 
    public sealed class JugadorDAOFactory
    {
        /* NOTE: constans are implicitly static */
        private const String DAO_CLASS_NAME_PARAMETER =
            "JugadorDAOFactory/daoClassName";

        /* NOTE: Class constructor must be private, so nobody will be allowed to 
         * instantiate it      
         */
        private JugadorDAOFactory() { }

        public JugadorDAO JugadorDAO
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
        public static JugadorDAO GetDAO() {

            try {
                String daoClassName = ConfigurationManager.
                    AppSettings[DAO_CLASS_NAME_PARAMETER];

                Assembly assembly = Assembly.GetExecutingAssembly();

                Object theObject = AppDomain.CurrentDomain.
                    CreateInstanceAndUnwrap(assembly.FullName, daoClassName);

                return (JugadorDAO)theObject;

            } catch (Exception e) {

                throw new InternalErrorException(e);
            }

        }

     
    }
}
