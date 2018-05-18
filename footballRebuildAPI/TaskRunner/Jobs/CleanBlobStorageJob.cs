using Football.API.Config;
using Football.BlobStorage.Interfaces;
using Football.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Football.API.TaskRunner.Jobs
{
    public class CleanBlobStorageJob : BaseJob
    {
        private IBlobStorageService _blobStorageService;
        private IGlobalMediaService _globalMediaService;

        public override async Task<bool> Run()
        {
            var serviceProvider = ServiceConfiguration.ConsoleProvider;
            _globalMediaService = serviceProvider.GetService<IGlobalMediaService>();
            _blobStorageService = serviceProvider.GetService<IBlobStorageService>();

            var referencedBlobs = await _globalMediaService.GetReferencedBlobIds();
            var referencedBlobIds = referencedBlobs.Select(x => x.BlobStorageReference).ToList();
            var referencedGlobalMediaIds = referencedBlobs.Select(x => x.GlobalMediaId).ToList();

            //Remove non referenced files from blob storage
            await _blobStorageService.DeleteBlobsExceptSelected(referencedBlobIds, "mycontainer");

            //Remove non referenced items froom the globalmedia table
            await _globalMediaService.DeleteUnreferencedBlobs(referencedGlobalMediaIds);

            return true;
        }
    }
}
