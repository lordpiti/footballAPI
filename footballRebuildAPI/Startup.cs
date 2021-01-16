using AspNetCoreSignalr.SignalRHubs;
using Crosscutting.ViewModels;
using Football.API.Config;
using Football.API.Filters;
using Football.API.Middleware;
using Football.Crosscutting.ViewModels.Reports;
using GraphiQl;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace footballRebuildAPI
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            #region Mongodb driver set up

            //ignore properties(like the _id) stored in the mongodb collection when deserialising to POCO objects
            //also store property names in camelcase
            var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true), new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);
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
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();

            #region CORS setup

            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .AllowAnyOrigin()
                    .WithOrigins(
                    "http://localhost:4200",
                    "http://localhost:3000",
                    "https://piti-react-test.herokuapp.com",
                    "https://footballpitiangular.herokuapp.com",
                    "https://top-squad.herokuapp.com");
            }));

            #endregion

            // Add framework services.

            services.AddControllers()
                .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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

            services.AddHttpClient();

            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings").Bind(options));

            ServiceConfiguration.ConfigureAPIServices(services, Configuration);

            //Since the filters will be used as a ServiceType (Because they use DI), the different custom filters need to be registered with the framework IoC. 
            //If the action filters were used directly, this would not be required.
            services.AddScoped<AuthorizationRequiredAttribute>();

            //https://miniprofiler.com/dotnet/HowTo/ProfileEFCore
            services.AddMiniProfiler(options =>
                options.RouteBasePath = "/profiler"
            ).AddEntityFramework();

            // Inject an implementation of ISwaggerProvider with defaulted settings applied
            // https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.1
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo() {
                    Title = "Football API specification",
                    Description = ""
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            //Added this to be able to use DI for the SignalR Hubs on the background service
            //https://github.com/aspnet/SignalR/issues/972
            Provider = app.ApplicationServices;

            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/write?view=aspnetcore-3.1
            app.UseMiddleware<CustomMiddleware>();

            app.UseResponseCompression();

            //app.UseCors("AllowAll");
            app.UseCors("CorsPolicy");

            #region Add GraphiQL

            // Launch {url}/graphql
            app.UseGraphiQl("/graphiql");

            #endregion

            app.UseMiniProfiler();

            app.UseRouting();

            // https://stackoverflow.com/questions/57846127/what-are-the-differences-between-app-userouting-and-app-useendpoints/59966192#59966192

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                #region SignalR

                endpoints.MapHub<LoopyHub>("/loopy", options => options.Transports = HttpTransportType.WebSockets);

                #endregion

                #region OData

                endpoints.EnableDependencyInjection();
                endpoints.Count().Filter().OrderBy().Expand().Select().MaxTop(null);

                #endregion
            });

            //https://code-maze.com/swagger-ui-asp-net-core-web-api/
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","swagger"));
        }

        public static IServiceProvider Provider { get; private set; }
    }
}
