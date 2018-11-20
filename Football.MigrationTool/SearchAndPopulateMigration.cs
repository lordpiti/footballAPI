using DataAccess.Models;
using Football.MigrationTool.HelperClasses;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.MigrationTool
{
    class SearchAndPopulateMigration
    {
        private static DbContextOptions _contextOptions;

        public void Execute()
        {
            _contextOptions = new DbContextOptionsBuilder<c__database_futbol_mdfContext>()
            .UseSqlServer(@"Server=tcp:qdijnzq4jx.database.windows.net,1433;Initial Catalog=Football;Persist Security Info=False;User ID=lordpiti@qdijnzq4jx;Password=Kidswast1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            .Options;

            var context = new c__database_futbol_mdfContext((DbContextOptions<c__database_futbol_mdfContext>)_contextOptions);

            const string apiKey = "AIzaSyDEMwf-TmawihildmEKe3V-vZNSmqIZhr0";
            const string searchEngineId = "009825223228933647019:srwbnv-i5xw";

            #region Update all team player names with the ones available



            using (StreamReader r = new StreamReader("c:\\repos\\england-players.json"))
            {
                string json = r.ReadToEnd();

                var items = JsonConvert.DeserializeObject<RootObject>(json);

                foreach(var item in items.sheets.Players)
                {
                    #region Google Search Code

                    var query = item.name;
                    var customSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
                    var listRequest = customSearchService.Cse.List(query);
                    listRequest.Cx = searchEngineId;
                    listRequest.Num = 1;
                    //listRequest.Fields = "items(image(contextLink,thumbnailLink),link)";
                    listRequest.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;
                    listRequest.Start = 1;

                    var search = listRequest.Execute();

                    foreach (var result in search.Items)
                    {
                        Console.WriteLine(string.Format("Title: {0}", result.Title));
                        Console.WriteLine(string.Format("Link: {0}", result.Link));
                    }

                    #endregion
                }
            }

            #endregion

            
        }
    }
}
