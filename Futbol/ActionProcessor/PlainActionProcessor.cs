using System;
using System.Collections.Generic;
using System.Text;
using Util.Exceptions;
using System.Configuration;
using System.Data.Common;
using System.Collections;
using System.Xml;
using Util.Log;
using System.Data;

namespace Futbol.ActionProcessor
{
    public class PlainActionProcessor
    {

        private static String connectionString = "Data Source=tcp:qdijnzq4jx.database.windows.net,1433;Initial Catalog=Football;User ID=lordpiti@qdijnzq4jx;Password=Kidswast1;";
        private PlainActionProcessor() { }
        
        public static Object process(DbProviderFactory dbFactory, NonTransactionalPlainAction action) {
            
            DbConnection connection = dbFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            
           
            try {
                return action.execute(connection);
        
            }
            catch (SQLException e){
                throw new InternalErrorException(e);
            }
            finally {
                try
                {
                    if (connection != null)
                    {
                        connection.Close();
                        
                    }
                }
                catch (Exception e)
                {
                    throw new InternalErrorException(e);
                }
            }
        }




        public static Object process(DbProviderFactory dbFactory, TransactionalPlainAction action)
        {

            DbConnection connection = dbFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable);
            bool rollback = false;



            try
            {
                return action.execute(connection,transaction);

            }
            catch (SQLException e)
            {
                rollback = true;
                throw new InternalErrorException(e);
            }
            finally
            {
                
                try
                {
                    if (connection != null)
                    {
                        if (transaction != null) {
                            if (rollback)
                                transaction.Rollback();
                            else transaction.Commit();
                        }
                        
                        connection.Close();
                        
                        
                    }
                }
                catch (Exception e)
                {
                    
                    throw new InternalErrorException(e);
                }
            }
        }
    }
}
