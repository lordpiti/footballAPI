using System;
using System.Data.Common;
using Westwind.Utilities;


namespace Futbol.ActionProcessor
{
    class FachadaPruebas
    {
        private static String providerName = "system.data.sqlclient";
     /*   private static String connectionString = "Data Source=localhost\\SQLExpress;" +
            "Initial Catalog=criticas;" +
            "User ID=user;Password=password";*/
        private DbProviderFactory dbFactory;


        public FachadaPruebas()
        {
            
            dbFactory = DataUtils.GetDbProviderFactory(providerName);
        }



    }
}
