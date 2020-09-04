using Football.Services.Proxy.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Proxy
{
    public abstract class BaseHttpClient
    {
        public const string JsonMediaType = "application/json";

        protected BaseHttpClient(IHttpClientFactory httpClientFactory)
        {
            this.HttpClientFactoryInstance = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        private HttpClient HttpClientInstance
        {
            get
            {
                var httpClient = this.HttpClientFactoryInstance.CreateClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonMediaType));
                return httpClient;
            }
        }

        private IHttpClientFactory HttpClientFactoryInstance { get; }

        protected async Task<TResponse> Get<TResponse>(Uri uri)
        {
            var response = await this.HttpClientInstance.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                //throw new Exceptions.ApiFailedResponseException(uri, responseContent, response.StatusCode);
                throw new Exception(response.StatusCode.ToString());
            }

            var responseObject = await response.Content.ConvertTo<TResponse>();

            return responseObject;
        }

        protected async Task<TResponse> PostAsStringContent<TResponse, TRequest>(TRequest itemToPost, Uri uri)
        {
            using (var stringContent = itemToPost?.ToStringContent() ?? throw new ArgumentNullException(nameof(itemToPost)))
            using (var response = await this.HttpClientInstance.PostAsync(uri, stringContent))
            {
                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    //throw new Exceptions.ApiFailedResponseException(uri, responseContent, response.StatusCode);
                    throw new Exception(response.StatusCode.ToString());
                }

                return await response.Content.ConvertTo<TResponse>();
            }
        }
    }
}
