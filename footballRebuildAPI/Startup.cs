using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Services.Interface;
using Services.Concrete;
using Services;
using Football.Services.Interface;
using Football.Services.Concrete;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Football.BlobStorage.Interfaces;
using Football.BlobStorage;
using Crosscutting.ViewModels;

namespace footballRebuildAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                    .AllowAnyMethod()
                                                                     .AllowAnyHeader()));
            // Add framework services.
            services.AddMvc();

            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings").Bind(options));

            ServiceLayerBindings
                .AddServiceLayerBindings(services, Configuration)
                .AddOptions()
                .AddScoped<IPlayerService, PlayerService>()
                .AddScoped<ITeamService, TeamService>()
                .AddScoped<ICompetitionService, CompetitionService>()
                .AddScoped<IBlobStorageService, BlobStorageService>()
                .AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("AllowAll");

            app.UseMvc();
        }
    }
}
