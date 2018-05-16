using Football.Crosscutting;
using Football.Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Interface
{
    public interface IGlobalMediaService
    {
        Task<BlobData> PostBlob(byte[] data, string blobReference, string containerReference);

        Task<BlobData> GetBlobById(string blobReference, string blobContainerReference);

        Task<List<GlobalMediaData>> GetReferencedBlobIds();

        Task<int> DeleteUnreferencedBlobs(List<int> referencedBlobIds);
    }
}
