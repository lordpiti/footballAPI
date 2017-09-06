using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Concrete;
using Crosscutting.ViewModels;
using Services.Interface;
using Football.Services.Interface;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting;
using Football.BlobStorage;

namespace footballRebuildAPI.Controllers
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing

    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;

        public PlayerController(IPlayerService playerService, ITeamService teamService)
        {
            _playerService = playerService;
            _teamService = teamService;
        }
        
        [HttpGet]
        [Route("MatchesPlayed/{id}")]
        public IEnumerable<MatchPlayedInfo> GetMatchesPlayed(int id)
        {
            return _playerService.GetMatchesPlayed(id);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Player> List()
        {
            return _playerService.GetPlayers();
        }

        [HttpGet]
        [Route("Teams/{id}/year/{year}")]
        public Team GetTeam(int id, int year)
        {
            return _teamService.GetTeamByIdAndYear(id, year);
        }

        [HttpGet]
        [Route("Teams")]
        public List<Team> GetAllTeams()
        {
            return _teamService.GetAllTeams();
        }

        //[Route("Files/Upload")]
        //public string PostFile([FromBody] BlobData postData)
        //{
        //    string base64 = postData.Bytes.Substring(postData.Bytes.IndexOf(',') + 1);
        //    byte[] data = Convert.FromBase64String(base64);

        //    var container = _cloudStorageClient.GetContainerReference("mycontainer");

        //    // Create the container if it doesn't already exist.
        //    container.CreateIfNotExists();

        //    container.SetPermissions(
        //        new BlobContainerPermissions
        //        {
        //            PublicAccess = BlobContainerPublicAccessType.Blob
        //        });

        //    var blobName = postData.fileName;

        //    // Retrieve reference to a blob with an specified name
        //    CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
        //    //TODO: if exists, then create another one
        //    //blockBlob.Exists();
        //    Stream fileStream = new MemoryStream(data);
        //    blockBlob.UploadFromStream(fileStream);

        //    //System.IO.File.WriteAllBytes("c:\\test\\jaja.png", data);

        //    return blockBlob.Uri.ToString();
        //}

        // GET api/values/5

        [HttpGet]
        [Route("images/get/{something}")]
        public async Task<BlobData> GetBlobData(string something)
        {
            var hh = new BlobStorageService();

            return await hh.GetBlobById(something);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
