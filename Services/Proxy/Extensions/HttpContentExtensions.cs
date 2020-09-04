using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Football.Services.Proxy.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ConvertTo<T>(this HttpContent content)
        {
            var responseStream = await content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(
                responseStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static HttpContent ToStringContent<T>(this T obj)
        {
            string json = JsonSerializer.Serialize(obj);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
