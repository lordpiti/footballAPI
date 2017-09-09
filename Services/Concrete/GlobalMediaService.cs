using Football.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Football.Crosscutting;
using System.Threading.Tasks;
using Football.BlobStorage.Interfaces;

namespace Football.Services.Concrete
{
    public class GlobalMediaService : IGlobalMediaService
    {
        private readonly IBlobStorageService _blobStorageService;

        public GlobalMediaService(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        public async Task<BlobData> GetBlobById(string blobReference, string blobContainerReference)
        {
            return await _blobStorageService.GetBlobById(blobReference, blobContainerReference);
        }

        public string GetUrlForBlog(string blobReference, string blobContainerReference)
        {
            return _blobStorageService.GetUrlForBlog(blobReference, blobContainerReference);
        }

        public async Task<BlobData> PostBlob(byte[] data, string blobReference, string containerReference)
        {
            return await _blobStorageService.PostBlob(data, blobReference, containerReference);
        }
    }
}
