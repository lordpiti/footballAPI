using Football.API.IntegrationTests.Mocks;
using footballRebuildAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Football.API.IntegrationTests.Infrastructure
{
    public class TestServerBase : IDisposable
    {
        protected HttpClient HttpClient;
        protected TestServer TestServer;

        protected TopSquadApiClientMock TopSquadApiClientMock => (TopSquadApiClientMock)TestServer.Host.Services.GetService(typeof(TopSquadApiClientMock));
        //protected ProductMetricsApiClientMock ProductMetricsApiClientMock => (ProductMetricsApiClientMock)TestServer.Host.Services.GetService(typeof(ProductMetricsApiClientMock));
        //protected AssortmentDocumentApiClientMock AssortmentDocumentApiClientMock => (AssortmentDocumentApiClientMock)TestServer.Host.Services.GetService(typeof(AssortmentDocumentApiClientMock));
        //protected PerformanceApiClientMock PerformanceApiClientMock => (PerformanceApiClientMock)TestServer.Host.Services.GetService(typeof(PerformanceApiClientMock));
        //protected PersistScienceServiceMock PersistScienceServiceMock => (PersistScienceServiceMock)TestServer.Host.Services.GetService(typeof(PersistScienceServiceMock));

        //protected CDTScienceContextMock CDTScienceContextMock => (CDTScienceContextMock)TestServer.Host.Services.GetService(typeof(CDTScienceContextMock));

        public TestServerBase()
        {
            TestServer = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>()
                .ConfigureAppConfiguration((builderContext, configBuilder) => {
                
                }));
                    //Startup.BuildConfiguration(builderContext.HostingEnvironment, configBuilder)));

            HttpClient = TestServer.CreateClient();
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
            TestServer?.Dispose();
        }
    }
}
