using DataAccess.Models;
using Football.MigrationTool.HelperClasses;
using Football.Services.Interface;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Football.MigrationTool
{
    public class SearchAndPopulateMigration
    {
        private IPlayerService _playerService;
        private ITeamService _teamService;
        private IGlobalMediaService _globalMediaService;

        public SearchAndPopulateMigration(IPlayerService playerService, ITeamService teamService, IGlobalMediaService globalMediaService)
        {
            _playerService = playerService;
            _teamService = teamService;
            _globalMediaService = globalMediaService;
        }

        public async Task Execute()
        {
            try
            {
                const string apiKey = "AIzaSyDEMwf-TmawihildmEKe3V-vZNSmqIZhr0";
                const string searchEngineId = "009825223228933647019:srwbnv-i5xw";

                jsonFilesFromFolder();

                #region Update all team player names with the ones available

                int jsonIndex = 7;

                var jsonFileList = jsonFilesFromFolder().Skip(6);

                foreach (var jsonTeam in jsonFileList)
                {
                    var items = JsonConvert.DeserializeObject<RootObject>(jsonTeam);

                    var team = await _teamService.GetTeamByIdAndYear(jsonIndex, 2009);

                    int index = 0;
                    foreach (var item in team.PlayerList)
                    {
                        var currentPlayerToCopy = items.sheets.Players[index];

                        var nameAndSurname = currentPlayerToCopy.name.Split(' ');
                        if (nameAndSurname.Length > 1)
                        {
                            item.Name = nameAndSurname[0];
                            item.Surname = nameAndSurname[1];
                        }
                        else
                        {
                            item.Name = currentPlayerToCopy.name;
                            item.Surname = "";
                        }

                        item.Position = currentPlayerToCopy.position;

                        #region Google Search Code

                        var query = currentPlayerToCopy.name;
                        var customSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
                        var listRequest = customSearchService.Cse.List(query);
                        listRequest.Cx = searchEngineId;
                        listRequest.Num = 1;
                        //listRequest.Fields = "items(image(contextLink,thumbnailLink),link)";
                        listRequest.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;
                        listRequest.Start = 1;

                        var search = listRequest.Execute();

                        var url = search.Items[0].Link;

                        var imageByteArray = this.GetImage(url);
                        if (imageByteArray !=null)
                        {
                            var blobData = await _globalMediaService.PostBlob(imageByteArray, "test.png", "mycontainer");
                            item.Picture = blobData;
                        }


                        await _playerService.UpdatePlayer(item);

                        #endregion

                        index++;
                    }

                    jsonIndex++;

                    Thread.Sleep(10000);
                }

                #endregion

            }
            catch(Exception ex)
            {

            }
        }

        public byte[] GetImage(string url)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
            }

            return (buf);
        }

        private List<string> jsonFilesFromFolder()
        {
            string prefix = "Football.MigrationTool.TeamData.";

            var resourceNames = Assembly.GetExecutingAssembly()
                .GetManifestResourceNames()
                .Where(name => name.StartsWith(prefix));

            return resourceNames.OrderBy(x=>x).Select(x => this.readJsonStringAsEmbeddedResource(x)).ToList();
        }

        private string readJsonStringAsEmbeddedResource(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();

                return result;
            }
        }
            
    }
}
