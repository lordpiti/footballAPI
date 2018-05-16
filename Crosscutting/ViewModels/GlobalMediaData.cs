using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Crosscutting.ViewModels
{
    public class GlobalMediaData
    {
        public int GlobalMediaId { get; set; }

        public string BlobStorageContainer { get; set; }

        public string BlobStorageReference { get; set; }

        public string FileName { get; set; }
    }
}
