using Football.API.Config;
using Football.BlobStorage.Interfaces;
using Football.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Football.API.TaskRunner.Jobs
{
    public class KeepSitesAliveJob : BaseJob
    {

        public override async Task<bool> Run()
        {
            var urls = new List<string>() {
                "https://piti-react-test.herokuapp.com/competitions/competition-simulation",
                "https://footballtpititest.herokuapp.com/competitions/simulation"
                };

            try
            {
                foreach (var urlAddress in urls)
                {
                    var request = WebRequest.Create(urlAddress);
                    var response = await request.GetResponseAsync();
                }
            }
            catch (Exception ex)
            {
                //TODO: log this somewhere
            }

            return true;
        }

        public override Task executePostRun()
        {
            return null;
        }

    }
}
