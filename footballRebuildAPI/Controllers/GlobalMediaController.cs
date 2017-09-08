using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Football.BlobStorage;
using System.IO;
using Football.Crosscutting;
using Football.BlobStorage.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Football.API.Controllers
{
    [Route("api/[controller]")]
    public class GlobalMediaController : Controller
    {
        private readonly IBlobStorageService _blobStorageService;

        public GlobalMediaController(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        [HttpPost]
        [Route("UploadDocument")]
        public async Task<BlobData> UploadDocument(IList<IFormFile> files)
        {
            var file = files[0];

            if (file.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);

                    var data = stream.ToArray();

                    return await _blobStorageService.PostBlob(data, file.FileName, "mycontainer");
                }
            }           

            return null;
        }

        [Route("UploadBase64Image")]
        public async Task<BlobData> PostBase64Image([FromBody] BlobData postData)
        {
            string base64 = postData.Base64String.Substring(postData.Base64String.IndexOf(',') + 1);
            byte[] data = Convert.FromBase64String(base64);

            return await _blobStorageService.PostBlob(data, postData.FileName, "mycontainer");
        }

        [HttpGet]
        [Route("Get/{referenceContainer}/reference/{referenceBlob}")]
        public async Task<BlobData> GetBlobData(string referenceContainer, string referenceBlob)
        {
            return await _blobStorageService.GetBlobById(referenceBlob, referenceContainer);
        }
    }
}
