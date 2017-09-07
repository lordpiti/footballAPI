using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public partial class GlobalMedia
    {
        [Key]
        public int GlobalMediaId { get; set; }
        public string FileName { get; set; }
        public string BlobStorageContainer { get; set; }

        public string BlobStorageReference { get; set; }
    }
}