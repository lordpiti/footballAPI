using Crosscutting.ViewModels;
using Football.API.TaskRunner.Jobs;
using Football.API.TaskRunner.Services;
using Football.BlobStorage;
using Football.BlobStorage.Interfaces;
using Football.Services.Concrete;
using Football.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Concrete;
using Services.Interface;
using Simulador;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Config
{
    public static class ServiceConfiguration
    {
        private static void ConfigureServices(IServiceCollection services, bool transient = false)
        {

            ServiceLayerBindings
                .AddServiceLayerBindings(services, Configuration, transient)
                .AddOptions()
                .AddScoped<ICompetitionService, CompetitionService>()
                .AddScoped<IBlobStorageService, BlobStorageService>()
                .AddScoped<IGlobalMediaService, GlobalMediaService>()
                .AddScoped<IUserService, UserService>();

            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings").Bind(options));
        }

        /// <summary>
        /// Configure services that are used only by the console and then calls to add shared services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureAPIServices(IServiceCollection services)
        {
            
            ConfigureServices(services, false);
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<ITeamService, TeamService>();
        }


        private static IServiceProvider _consoleProvider;
        public static IServiceProvider ConsoleProvider
        {
            get
            {
                return _consoleProvider ?? (_consoleProvider = ConfigureConsoleServices());
            }
        }

        /// <summary>
        /// Configure services that are used only by the the api and then calls to add shared services
        /// </summary>
        /// <param name="services"></param>
        public static IServiceProvider ConfigureConsoleServices()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string configFile = $"appsettings.{env}.json";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(configFile, optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            var services = new ServiceCollection();
            ConfigureServices(services, true);
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddScoped<IGeneradorCosas, GeneradorCosas>();
            services.AddScoped<IGeneradorPartidos, GeneradorPartidos>();
            services.AddSingleton<JobRunnerConfigService>()
                .AddTransient<CreateMatchesJob>()
                .AddTransient<CleanBlobStorageJob>();

            services.AddSignalR();

            //// Badgers
            //services.AddScoped<TestBadger>();
            //services.AddScoped<AmazonCleanupBadger>();
            //services.AddScoped<DailyBadger>();
            //services.AddScoped<EventBadger>();
            //services.AddScoped<KeepAliveBadger>();

            //// Domain services
            //services.AddScoped<IImportedEventsService, ImportedEventsService>();
            //services.AddScoped<IEmailService, SendGridService>();
            //services.AddScoped<IAmazonService, AmazonService>();
            //services.AddScoped<IDailyService, DailyService>();
            //services.AddScoped<ITwitterService, TwitterService>();
            //services.AddScoped<IAmazonApi, AmazonApi>();
            //services.AddScoped<IQueueService, QueueService>();
            //services.AddScoped<IDonationService, DonationService>();
            //services.AddScoped<IProjectService, ProjectService>();
            //services.AddScoped<ITimelineService, TimelineService>();

            ////Singleton domain services
            //services.AddSingleton<ILoggerService, LoggerService>();
            //services.AddSingleton<ILog, LoggerService>();
            //services.AddSingleton<IEventHandlerService, EventHandlerService>();
            //services.AddSingleton<BadgerConfigService>();

            //// Setup options with DI
            //services.AddOptions();

            //// Configure MySubOptions using a sub-section of the appsettings.json file

            //var appSettings = Configuration.GetSection("AppSettings");
            //services.Configure<AppSettings>(appSettings);

            //var badgerSettings = Configuration.GetSection("BadgerSettings");
            //services.Configure<TaskBadgerConfig>(badgerSettings);


            //foreach (var setting in appSettings.GetChildren())
            //{
            //    ConfigurationManager.AppSettings[setting.Key] = setting.Value;
            //}


            return services.BuildServiceProvider();
        }

        public static IConfigurationRoot Configuration { get; set; }

    }
}
