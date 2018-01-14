using Football.API.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.TaskRunner.Services
{
    public class JobRunnerConfigService
    {
        private JobRunnerConfig _config;
        public JobRunnerConfig Config
        {
            get
            {
                if (_config == null)
                {
                    //var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    string configFile = $"config.json";
                    _config = JsonConvert.DeserializeObject<JobRunnerConfig>(File.ReadAllText(configFile));
                }
                return _config;
            }
        }
    }
}
