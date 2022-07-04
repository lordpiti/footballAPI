using Crosscutting.ViewModels;
using Football.API.TaskRunner.Jobs;
using Football.API.TaskRunner.Services;
using Football.BlobStorage;
using Football.BlobStorage.Interfaces;
using Football.GraphQL.Models;
using Football.GraphQLUtils.Models;
using Football.Services.Concrete;
using Football.Services.Interface;
using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Concrete;
using Services.Interface;
using Simulador;
using System;
using System.IO;

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
                .AddScoped<IReportService, ReportService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ITopSquadService, TopSquadService>()

                // GraphQL DI
                .AddSingleton<IDocumentExecuter, DocumentExecuter>()
                .AddSingleton<IGraphQLSerializer, GraphQLSerializer> ()
                .AddScoped<FootballQuery>()
                .AddScoped<FootballMutation>()
                .AddScoped<PlayerType>()
                .AddScoped<MatchPlayedType>()
                .AddScoped<PlayerInputType>()
                .AddScoped<CompetitionType>()
                .AddScoped<CompetitionInputType>()
                .AddScoped<ISchema, FootballSchema>();

            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings").Bind(options));
        }

        /// <summary>
        /// Configure services that are used only by the console and then calls to add shared services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureAPIServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            Configuration = configuration;

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

        // <summary>
        // Configure services that are used only by the the api and then calls to add shared services
        // </summary>
        // <param name="services"></param>
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
                .AddTransient<CleanBlobStorageJob>()
                .AddTransient<KeepSitesAliveJob>();

            services.AddSignalR();

            return services.BuildServiceProvider();
        }

        public static IConfigurationRoot Configuration { get; set; }

    }
}
