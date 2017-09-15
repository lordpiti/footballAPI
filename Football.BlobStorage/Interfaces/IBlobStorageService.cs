using Football.Crosscutting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.BlobStorage.Interfaces
{
    public interface IBlobStorageService
    {
        Task<BlobData> PostBlob(byte[] data, string blobReference, string containerReference);

        Task<BlobData> GetBlobById(string blobReference, string blobContainerReference);

        //string GetUrlForBlog(string blobReference, string blobContainerReference);

        void PopulateUrlForBlob(BlobData data);
    }
}
