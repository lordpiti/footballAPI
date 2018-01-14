using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Config
{
    public class JobRunnerConfig
    {
        public List<JobConfig> Jobs { get; set; }
        public int EventRetryCount { get; set; }
        public TimeSpan EventRetryTime { get; set; }
    }
}
