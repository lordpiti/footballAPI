﻿using System;
using System.Threading.Tasks;
using System.IO;
using Football.Crosscutting;
using Football.BlobStorage.Interfaces;
using Microsoft.Extensions.Options;
using Crosscutting.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage;

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
                ContainerReference = containerReference,
                FileName = blobReference,
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

        public async Task<bool> DeleteBlobsExceptSelected(List<string> guidList, string blobContainerReference)
        {
            try
            {
                //https://stackoverflow.com/questions/23485514/getting-list-of-names-of-azure-blob-files-in-a-container
                //https://stackoverflow.com/questions/36497399/how-to-delete-files-from-blob-container

                var container = _cloudStorageClient.GetContainerReference(blobContainerReference);

                #region .net4.6 / .net core

                //var blobList = container.ListBlobs();

                //List<string> blobNames = blobList.OfType<CloudBlockBlob>().Select(b => b.Name).ToList();

                //foreach (var item in blobList.OfType<CloudBlockBlob>().ToList())
                //{
                //    if (!guidList.Contains(item.Name))
                //    {
                //        await item.DeleteIfExistsAsync();
                //    }
                //}

                #endregion

                #region .net standard

                var blobList = await container.ListBlobsSegmentedAsync(null);

                List<string> blobNames = blobList.Results.OfType<CloudBlockBlob>().Select(b => b.Name).ToList();

                foreach (var item in blobList.Results.OfType<CloudBlockBlob>().ToList())
                {
                    if (!guidList.Contains(item.Name))
                    {
                        await item.DeleteIfExistsAsync();
                    }
                }

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private string getUrlForBlob(string blobReference, string blobContainerReference)
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
                data.Url = getUrlForBlob(data.FileName, data.ContainerReference);
            }
        }
    }
}
