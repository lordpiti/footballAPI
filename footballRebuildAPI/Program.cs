using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System.Threading;
using Football.API.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Football.API.TaskRunner.Interfaces;
using Football.API.TaskRunner;
using Football.API.TaskRunner.Services;
using Football.MigrationTool;
using Services.Interface;
using Football.Services.Interface;

namespace footballRebuildAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ServiceConfiguration.ConfigureConsoleServices();
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            new Thread(() =>
            {
                Thread.Sleep(10000);

                bool running = true;

                //Get DI services
                while (running)
                {
                    try
                    {
                        Start();
                    }
                    catch (Exception e)
                    {
                        //logger.LogError("Error running task runner startup");
                        //logger.LogInformation(e.Message);
                        Thread.Sleep(10000);
                    }
                }

            }).Start();

            BuildWebHost(args).Run();
        }

        public static void Start()
        {
            var serviceProvider = ServiceConfiguration.ConsoleProvider;
            //var logger = serviceProvider.GetService<ILoggerService>();

            #region add here code to run data migration custom code

            //RunMigrationDataCode(serviceProvider);

            #endregion

            //Make sure all services have been killed off before starting up again, this should not happen but better to be safe.
            if (ThreadManager.Services.Count > 0)
            {
                ThreadManager.Services.ForEach(x => x.Stop());
                ThreadManager.Services = new List<IBaseJob>();
            }


            System.Reflection.Assembly asm = System.Reflection.Assembly.Load(new System.Reflection.AssemblyName() { Name = "Football.API" });

            // Load service objects
            var configService = serviceProvider.GetService<JobRunnerConfigService>();
            List<IBaseJob> services = new List<IBaseJob>();
            foreach (var item in configService.Config.Jobs.Where(x => x.Enabled))
            {
                var serviceType = asm.GetType($"Football.API.TaskRunner.Jobs.{item.Name}");


                var instance = serviceProvider.GetService(serviceType) as IBaseJob;
                if (instance != null)
                {
                    instance.Setup(item);
                    services.Add(instance);
                }
                else
                {
                    // Failed to load a given service
                    //logger.LogError($"Failed to find service type: {item.Name}");
                }
            }


            //Services loaded, lets start them up!
            foreach (var item in services)
            {
                //logger.LogInformation("Loading service: " + item.Name);
                item.Start();
                ThreadManager.Services.Add(item);
            }


            //logger.LogInformation("All services started up and running （ ^_^）o自自o（^_^ ）");

            //Now sit and loop for as long as any threads are running
            while (ThreadManager.Services.Any(x => !x.Task.IsCompleted))
            {
                Thread.Sleep(1000);
            }

            //logger.LogError("All services closed, restarting in 10 seconds.");
            Thread.Sleep(10000);
        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseKestrel(options =>
            {
                options.Limits.MaxRequestBodySize = null;
            })
            .Build();

        public static void RunMigrationDataCode(IServiceProvider serviceProvider)
        {
            var playerService = serviceProvider.GetService<IPlayerService>();
            var teamService = serviceProvider.GetService<ITeamService>();
            var globalMediaService = serviceProvider.GetService<IGlobalMediaService>();
            var a = new SearchAndPopulateMigration(playerService, teamService, globalMediaService);
            Task.Run(() => a.Execute());
        }
    }
}
