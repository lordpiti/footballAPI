using Football.API.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.TaskRunner.Interfaces
{
    public interface IBaseJob
    {
        string Name { get; set; }
        IntervalSettings Settings { get; set; }
        bool IsRunning { get; set; }
        Task<bool> Run();
        void Setup(JobConfig config);
        void Start();
        void Stop();
        Task Task { get; set; }
        Guid Id { get; set; }
        DateTime NextRun { get; set; }
    }
}
