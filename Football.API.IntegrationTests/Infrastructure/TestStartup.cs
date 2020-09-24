using Football.API.IntegrationTests.Mocks;
using Football.Services.Proxy;
using footballRebuildAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Football.API.IntegrationTests.Infrastructure
{
    public class TestStartup : Startup
    {
        public TestStartup(IWebHostEnvironment configuration) : base(configuration)
        {

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            // replace the instances with the mocks in the container
            services.Remove(ServiceDescriptor.Scoped(typeof(ITopSquadApiClient), typeof(TopSquadApiClient)));
            //services.Remove(ServiceDescriptor.Singleton(typeof(IProductMetricsApiClient)));
            //services.Remove(ServiceDescriptor.Singleton(typeof(IAssortmentDocumentApiClient)));
            //services.Remove(ServiceDescriptor.Singleton(typeof(IPerformanceApiClient)));
            //services.Remove(ServiceDescriptor.Scoped(typeof(IPersistScienceService), typeof(PersistScienceService)));
            //services.Remove(ServiceDescriptor.Scoped(typeof(ICDTScienceContext), typeof(CDTScienceLinq2DbContext)));

            var mockTopSquadApiClient = new TopSquadApiClientMock();
            services.AddSingleton(provider => mockTopSquadApiClient.Object);
            services.AddSingleton(provider => mockTopSquadApiClient);

            //var productMetricsApiClientMock = new ProductMetricsApiClientMock();
            //services.AddSingleton(provider => productMetricsApiClientMock.Object);
            //services.AddSingleton(provider => productMetricsApiClientMock);

            //var assortmentDocumentApiClientMock = new AssortmentDocumentApiClientMock();
            //services.AddSingleton(provider => assortmentDocumentApiClientMock.Object);
            //services.AddSingleton(provider => assortmentDocumentApiClientMock);

            //var performanceApiClientMock = new PerformanceApiClientMock();
            //services.AddSingleton(provider => performanceApiClientMock.Object);
            //services.AddSingleton(provider => performanceApiClientMock);

            //var persistScienceServiceMock = new PersistScienceServiceMock();
            //services.AddScoped(provider => persistScienceServiceMock.Object);
            //services.AddScoped(provider => persistScienceServiceMock);

            //var cdtScienceContextMock = new CDTScienceContextMock();
            //services.AddScoped(provider => cdtScienceContextMock.Object);
            //services.AddScoped(provider => cdtScienceContextMock);
            services.AddControllersWithViews().AddApplicationPart(Assembly.Load("Football.API"));
        }

    }
}
