﻿using System;
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
using Football.API.Filters;
using MongoDB.Bson.Serialization.Conventions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Football.API.Config;
using AspNetCoreSignalr.SignalRHubs;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNet.OData.Extensions;

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

            #region Mongodb driver set up to ignore properties (like the _id) stored in the mongodb collection when deserialising to POCO objects

            var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
            ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);

            #endregion
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS

            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .AllowAnyOrigin();
            }));
            // Add framework services.
            services.AddOData();
            services.AddMvc();

            services.AddSignalR();

            

            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings").Bind(options));

            ServiceConfiguration.ConfigureAPIServices(services);

            //Because the filters will be used as a ServiceType (Because they use DI), the different custom filters need to be registered with the framework IoC. 
            //If the action filters were used directly, this would not be required.
            services.AddScoped<AuthorizationRequiredAttribute>();


            // Inject an implementation of ISwaggerProvider with defaulted settings applied
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info() { Title="jojo", Description="jeje" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //Added this to be able to use DI for the SignalR Hubs on the background service
            //https://github.com/aspnet/SignalR/issues/972
            Provider = app.ApplicationServices;

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));


            loggerFactory.AddDebug();

            //app.UseCors("AllowAll");
            app.UseCors("CorsPolicy");

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                routeBuilder.EnableDependencyInjection();
            });

            app.UseSignalR(routes =>
            {
                routes.MapHub<LoopyHub>("/loopy", options => options.Transports = HttpTransportType.WebSockets);
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","swagger"));
        }

        public static IServiceProvider Provider { get; private set; }
    }
}
