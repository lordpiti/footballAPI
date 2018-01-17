﻿using AspNetCoreSignalr.SignalRHubs;
using Crosscutting.ViewModels;
using Football.API.Config;
using footballRebuildAPI;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;

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

                //Create 10 different parallel threads to do stuff
                for(int i = 0; i < 10; i++)
                {
                    new Thread(async () =>
                    {
                        await bubu.Clients.All.InvokeAsync("Send", "Hello folks");

                    }).Start();
                }

            }
            catch (Exception ex)
            {
                // We need to log this somewhere.
            }

            return true;
        }
    }
}
