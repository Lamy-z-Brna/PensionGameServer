using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace PensionGame.Web.Client
{
    public class ServiceClient : IServiceClient
    {
        private IRestConnectionConfiguration _config;

        public ServiceClient(IRestConnectionConfiguration config)
        {
            _config = config;
        }

        public async Task<T> PostRequest<T>(string requestAddress, object? requestContent = null)
        {
            Uri requestUri = new Uri(_config.RestApiUri, requestAddress);

            IRestClient client = new RestClient(requestUri);
            client.AddDefaultHeader("Content-type", "application/json");

            IRestRequest restRequest = new RestRequest(requestUri, Method.POST);
            restRequest.AddParameter("format", "json");

            if (requestContent != null)
                restRequest.AddJsonBody(requestContent);

            var response = await client.ExecuteAsync(restRequest);

            var result = JsonConvert.DeserializeObject<T>(response.Content);

            return result;
        }
    }
}
