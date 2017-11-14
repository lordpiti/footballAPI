using System;
using System.Collections.Generic;
using System.Text;

namespace Crosscutting.ViewModels
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }

        public string BlobStorageConnectionString { get; set; }

        public string MongoConnection { get; set; }

        public string FacebookAppId { get; set; }
    }
}
