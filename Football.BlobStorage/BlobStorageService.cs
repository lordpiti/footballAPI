﻿using System;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;
using System.IO;
using Football.Crosscutting;
using Football.BlobStorage.Interfaces;
using Microsoft.Extensions.Options;
using Crosscutting.ViewModels;

namespace Football.BlobStorage
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly CloudBlobClient _cloudStorageClient;

        public BlobStorageService(IOptions<AppSettings> options)
        {
            var cloudStorageAccount = CloudStorageAccount.Parse(options.Value.BlobStorageConnectionString);

            _cloudStorageClient = cloudStorageAccount.CreateCloudBlobClient();
        }

        public async Task<BlobData> PostBlob(byte[] data, string fileName, string containerReference)
        {
            var container = _cloudStorageClient.GetContainerReference(containerReference);

            // Create the container if it doesn't already exist.
            await container.CreateIfNotExistsAsync();

            await container.SetPermissionsAsync(
                new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });

            var blobReference = Guid.NewGuid().ToString() + "-" + fileName;
            // Retrieve reference to a blob with an specified name
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobReference);
            //TODO: if exists, then create another one
            //blockBlob.Exists();
            Stream fileStream = new MemoryStream(data);
            await blockBlob.UploadFromStreamAsync(fileStream);

            //System.IO.File.WriteAllBytes("c:\\test\\jaja.png", data);

            return new BlobData()
            {
                ContainerReference = blobReference,
                FileName = fileName,
                Url = blockBlob.Uri.ToString()
            };
        }

        public async Task<BlobData> GetBlobById(string blobReference, string blobContainerReference)
        {
            CloudBlobContainer container = _cloudStorageClient.GetContainerReference(blobContainerReference);

            // Retrieve reference to a blob
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobReference);

            using (var memoryStream = new MemoryStream())
            {
                await blockBlob.DownloadToStreamAsync(memoryStream);

                var blob = new BlobData() {
                    Bytes = memoryStream.ToArray(),
                    FileName = blobReference,
                    Url = blockBlob.Uri.ToString()
                };

                return blob;
            }
        }

        private string getUrlForBlog(string blobReference, string blobContainerReference)
        {
            if (!string.IsNullOrEmpty(blobReference) && !string.IsNullOrEmpty(blobContainerReference))
            {
                return _cloudStorageClient.BaseUri + blobContainerReference + "/" + blobReference;
            }
            else
            {
                return "/assets/img/no-image.png";
            }
            
        }

        public void PopulateUrlForBlob(BlobData data)
        {
            if (data != null)
            {
                data.Url = getUrlForBlog(data.FileName, data.ContainerReference);
            }
        }
    }
}
