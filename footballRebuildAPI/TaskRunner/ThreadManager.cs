using Football.API.TaskRunner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.TaskRunner
{
    public static class ThreadManager
    {
        public static List<IBaseJob> Services = new List<IBaseJob>();


        public static void RunService(Guid id)
        {
            // Currently wont run a service if its not already running, expand at a later point
            var service = Services.FirstOrDefault(x => x.Id == id);
            service.NextRun = DateTime.Now;
        }

    }
}
