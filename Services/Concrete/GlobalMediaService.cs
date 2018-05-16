using Football.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Football.Crosscutting;
using System.Threading.Tasks;
using Football.BlobStorage.Interfaces;
using Football.DataAccess.Interface;
using Football.Crosscutting.ViewModels;

namespace Football.Services.Concrete
{
    public class GlobalMediaService : IGlobalMediaService
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly IGlobalMediaRepository _globalMediaRepository;

        public GlobalMediaService(IBlobStorageService blobStorageService, IGlobalMediaRepository globalMediaRepository)
        {
            _blobStorageService = blobStorageService;
            _globalMediaRepository = globalMediaRepository;
        }

        public async Task<BlobData> GetBlobById(string blobReference, string blobContainerReference)
        {
            return await _blobStorageService.GetBlobById(blobReference, blobContainerReference);
        }

        public async Task<BlobData> PostBlob(byte[] data, string blobReference, string containerReference)
        {
            return await _blobStorageService.PostBlob(data, blobReference, containerReference);
        }

        public async Task<List<GlobalMediaData>> GetReferencedBlobIds()
        {
            return await _globalMediaRepository.GetReferencedBlobIds();
        }

        public async Task<int> DeleteUnreferencedBlobs(List<int> referencedBlobIds)
        {
            return await _globalMediaRepository.DeleteUnreferencedBlobs(referencedBlobIds);
        }
    }
}
