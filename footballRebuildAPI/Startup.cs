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
using Football.API.Filters;
using MongoDB.Bson.Serialization.Conventions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Football.API.Config;
using AspNetCoreSignalr.SignalRHubs;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNet.OData.Extensions;
using MongoDB.Bson.Serialization;
using Football.Crosscutting.ViewModels.Reports;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.Net.Http.Headers;

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

            #region Deserialising settings for mongodb

            //https://mongodb-documentation.readthedocs.io/en/latest/ecosystem/tutorial/serialize-documents-with-the-csharp-driver.html#polymorphic-classes-and-discriminators
            BsonClassMap.RegisterClassMap<BaseItem>();
            BsonClassMap.RegisterClassMap<SubstitutionReportItem>();
            BsonClassMap.RegisterClassMap<YellowRedCardReportItem>();
            BsonClassMap.RegisterClassMap<GoalReportItem>();
            BsonClassMap.RegisterClassMap<StartingLineReportItem>();

            #endregion
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region CORS setup

            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .AllowAnyOrigin();
            }));

            #endregion

            // Add framework services.

            services.AddMvc();

            #region OData

            services.AddOData();

            //Added for compatibility with OData and Swagger
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });

            #endregion

            services.AddSignalR();          

            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings").Bind(options));

            ServiceConfiguration.ConfigureAPIServices(services);

            //Since the filters will be used as a ServiceType (Because they use DI), the different custom filters need to be registered with the framework IoC. 
            //If the action filters were used directly, this would not be required.
            services.AddScoped<AuthorizationRequiredAttribute>();


            // Inject an implementation of ISwaggerProvider with defaulted settings applied
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info() { Title="Football API specification", Description="" }));
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

            #region Added for OData

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                routeBuilder.EnableDependencyInjection();
            });

            #endregion

            #region SignalR

            app.UseSignalR(routes =>
            {
                routes.MapHub<LoopyHub>("/loopy", options => options.Transports = HttpTransportType.WebSockets);
            });

            #endregion

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","swagger"));
        }

        public static IServiceProvider Provider { get; private set; }
    }
}
