using System;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;
using System.IO;
using Football.Crosscutting;

namespace Football.BlobStorage
{
    public class BlobStorageService
    {
        private readonly CloudBlobClient _cloudStorageClient;

        public BlobStorageService()
        {
            //for some reason DI doesn't look to work properly on Azure when loading the config values on the Appsettings class
            //thats why the connection strings for the mongodb db are hardcoded here. Locally it's ok
            //This is only for azure
            var cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=pititest;AccountKey=UIAjevML+igZ7ldWewh0VrVsi2kWUetFPY9qHdvmi3J1Xjo1rb3QzNSc3zknBK+melgoIEshEx5XG7DLt1Vb/A==");

            //var cloudStorageAccount = CloudStorageAccount.Parse(settings.Options.StorageKey);

            _cloudStorageClient = cloudStorageAccount.CreateCloudBlobClient();
        }

        public async Task<string> PostBlob(byte[] data, string blobReference, string containerReference)
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

            return blockBlob.Uri.ToString();
        }

        public async Task<BlobData> GetBlobById(string blobReference, string blobContainerReference)
        {
            CloudBlobContainer container = _cloudStorageClient.GetContainerReference(blobContainerReference);

            // Retrieve reference to a blob
            CloudBlockBlob blockBlob2 = container.GetBlockBlobReference(blobReference);

            using (var memoryStream = new MemoryStream())
            {
                await blockBlob2.DownloadToStreamAsync(memoryStream);

                var blob = new BlobData() { Bytes = memoryStream.ToArray(), FileName = blobReference };

                return blob;
            }
        }
    }
}
