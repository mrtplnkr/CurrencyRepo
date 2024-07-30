using Application.Clients.Extensions;
using CubeExample;

namespace Application.Clients
{
    public class CurrencyHttpClient : ICurrencyHttpClient
    {
        public async Task<string> Get(string requestUri)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            using var httpClientHandler = new HttpClientHandler();

            using (var client = new HttpClient(httpClientHandler))
            {
                using (var response = await client.SendAsync(request))
                {
                    var xml = await response.Content.ReadAsStringAsync();

                    return xml;
                }
            }
        }
    }
}
