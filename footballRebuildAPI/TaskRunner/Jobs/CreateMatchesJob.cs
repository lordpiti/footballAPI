using AspNetCoreSignalr.SignalRHubs;
using Crosscutting.ViewModels;
using Football.API.Config;
using footballRebuildAPI;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Football.API.TaskRunner.Jobs
{
    public class CreateMatchesJob : BaseJob
    {
        private readonly IOptions<AppSettings> _settings;

        public CreateMatchesJob(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        public override async Task<bool> Run()
        {
            //_logger.LogInformation("AmazonCleanupBadger Run()");

            try
            {
                //TODO: create matches

                var serviceProvider = ServiceConfiguration.ConsoleProvider;

                var chatHub = serviceProvider.GetService<IHubContext<LoopyHub>>();
                var bubu = Startup.Provider.GetService<IHubContext<LoopyHub>>();

                await bubu.Clients.All.InvokeAsync("Send", "Hello folks");

            }
            catch (Exception ex)
            {
                // We need to log this somewhere.
            }

            return true;
        }
    }
}
