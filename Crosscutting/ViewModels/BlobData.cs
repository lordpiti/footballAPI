using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting
{
    public class BlobData
    {
        public int Id { get; set; }
        public byte[] Bytes { get; set; }

        public string Base64String { get; set; }

        public string FileName { get; set; }

        public string Url { get; set; }

        public string ContainerReference { get; set; }
    }
}
