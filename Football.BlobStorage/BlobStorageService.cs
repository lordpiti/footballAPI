using System;
using System.Threading.Tasks;
using System.IO;
using Football.Crosscutting;
using Football.BlobStorage.Interfaces;
using Microsoft.Extensions.Options;
using Crosscutting.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Football.BlobStorage
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobContainerClient _blobContainerClient;

        public BlobStorageService(IOptions<AppSettings> options)
        {
            _blobContainerClient = new BlobContainerClient(options.Value.BlobStorageConnectionString, "mycontainer");
        }

        public async Task<BlobData> PostBlob(byte[] data, string fileName, string containerReference)
        {
            await _blobContainerClient.CreateIfNotExistsAsync();

            var blobReference = Guid.NewGuid().ToString() + "-" + fileName;

            #region Container Access Policy

            //List<BlobSignedIdentifier> signedIdentifiers = new List<BlobSignedIdentifier>
            //{
            //    new BlobSignedIdentifier
            //    {
            //        Id = "mysignedidentifier",
            //        AccessPolicy = new BlobAccessPolicy
            //        {
            //            StartsOn = DateTimeOffset.UtcNow.AddHours(-1),
            //            ExpiresOn = DateTimeOffset.UtcNow.AddDays(1),
            //            Permissions = "rw"
            //        }
            //    }
            //};

            // Set the container's access policy.
            //await _blobContainerClient.SetAccessPolicyAsync(permissions: signedIdentifiers);

            #endregion

            BlobClient blob = _blobContainerClient.GetBlobClient(blobReference);
            Stream fileStream = new MemoryStream(data);
            await blob.UploadAsync(fileStream);


            //System.IO.File.WriteAllBytes("c:\\test\\jaja.png", data);

            return new BlobData()
            {
                ContainerReference = containerReference,
                BlobStorageReference = blobReference,
                FileName = fileName,
                Url = blob.Uri.ToString()
            };
        }

        public async Task<BlobData> GetBlobById(string blobReference, string blobContainerReference)
        {
            // Retrieve reference to a blob
            BlobClient blobBlock = _blobContainerClient.GetBlobClient(blobReference);

            using (var memoryStream = new MemoryStream())
            {
                await blobBlock.DownloadToAsync(memoryStream);

                var blob = new BlobData() {
                    Bytes = memoryStream.ToArray(),
                    FileName = blobReference,
                    Url = blobBlock.Uri.ToString()
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

                #region .net4.6 / .net core

                //var container = _cloudStorageClient.GetContainerReference(blobContainerReference);
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

                //TODO: implement
                //var container = _cloudStorageClient.GetContainerReference(blobContainerReference);
                //var blobList = await container.ListBlobsSegmentedAsync(null);

                //List<string> blobNames = blobList.Results.OfType<CloudBlockBlob>().Select(b => b.Name).ToList();

                //foreach (var item in blobList.Results.OfType<CloudBlockBlob>().ToList())
                //{
                //    if (!guidList.Contains(item.Name))
                //    {
                //        await item.DeleteIfExistsAsync();
                //    }
                //}

               var blobList = _blobContainerClient.GetBlobsAsync();

               await foreach (var item in blobList)
                {
                    if (!guidList.Contains(item.Name))
                    {
                        _blobContainerClient.DeleteBlobIfExists(item.Name, DeleteSnapshotsOption.IncludeSnapshots);
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
                return _blobContainerClient.Uri + "/" + blobReference;
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
                data.Url = getUrlForBlob(data.BlobStorageReference, data.ContainerReference);
            }
        }
    }
}
