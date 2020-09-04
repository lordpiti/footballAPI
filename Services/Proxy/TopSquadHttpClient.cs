using Football.Crosscutting.ViewModels.TopSquad;
using Football.Services.Proxy.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Football.Services.Proxy
{
    public class TopSquadApiClient : BaseHttpClient, ITopSquadApiClient
    {
        private readonly TopSquadApiConfiguration topSquadApiConfig;

        public TopSquadApiClient(
            IHttpClientFactory httpClientFactory,
            TopSquadApiConfiguration topSquadApiConfiguration)
            : base(httpClientFactory)
        {
            this.topSquadApiConfig = topSquadApiConfiguration;
        }

        public async Task<IEnumerable<TopSquad>> GetAllTopSquads()
        {
            var topSquadsUri = new Uri(this.topSquadApiConfig.TopSquadApiBaseUri, "/user/TopSquadList");

            try
            {
                return await this.Get<IEnumerable<TopSquad>>(topSquadsUri);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public async Task<IEnumerable<StoreCluster>> GetStoreClusters(long id)
        //{
        //    var storeclustersUri = new Uri(this.productMetricsApiConfig.ProductMetricsApiBaseUri, $"storeclusters/{id}");
        //    return await this.Get<IEnumerable<StoreCluster>>(storeclustersUri);
        //}

        //public async Task<Dictionary<string, string>> GetProductNames(long id)
        //{
        //    var productNamesUri = new Uri(this.productMetricsApiConfig.ProductMetricsApiBaseUri, $"productmetricsset/{id}/productnames");
        //    return await this.Get<Dictionary<string, string>>(productNamesUri);
        //}

        //public async Task<string> GetProductMetricsSetName(long id)
        //{
        //    var productMetricsSetNameUrl = new Uri(this.productMetricsApiConfig.ProductMetricsApiBaseUri, $"productmetricsset/{id}/name");
        //    return await this.Get<string>(productMetricsSetNameUrl);
        //}
    }
}
