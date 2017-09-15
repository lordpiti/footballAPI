using System;
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
            //for some reason DI doesn't look to work properly on Azure when loading the config values on the Appsettings class
            //thats why the connection strings for the mongodb db are hardcoded here. Locally it's ok
            //This is only for azure
            //var cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=pititest;AccountKey=UIAjevML+igZ7ldWewh0VrVsi2kWUetFPY9qHdvmi3J1Xjo1rb3QzNSc3zknBK+melgoIEshEx5XG7DLt1Vb/A==");
            var cloudStorageAccount = CloudStorageAccount.Parse(options.Value.BlobStorageConnectionString);

            _cloudStorageClient = cloudStorageAccount.CreateCloudBlobClient();
        }

        public async Task<BlobData> PostBlob(byte[] data, string blobReference, string containerReference)
        {
            var container = _cloudStorageClient.GetContainerReference(containerReference);

            // Create the container if it doesn't already exist.
            await container.CreateIfNotExistsAsync();

            await container.SetPermissionsAsync(
                new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });

            // Retrieve reference to a blob with an specified name
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobReference);
            //TODO: if exists, then create another one
            //blockBlob.Exists();
            Stream fileStream = new MemoryStream(data);
            await blockBlob.UploadFromStreamAsync(fileStream);

            //System.IO.File.WriteAllBytes("c:\\test\\jaja.png", data);

            return new BlobData()
            {
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

        private string GetUrlForBlog(string blobReference, string blobContainerReference)
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
                data.Url = this.GetUrlForBlog(data.FileName, data.ContainerReference);
            }
        }
    }
}
