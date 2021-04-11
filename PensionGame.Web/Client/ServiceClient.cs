using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PensionGame.Web.Client
{
    public class ServiceClient : IServiceClient
    {
        private IRestConnectionConfiguration _config;

        public ServiceClient(IRestConnectionConfiguration config)
        {
            _config = config;
        }

        public async Task<T> Request<T>(string requestAddress, Method method, object? requestBody = null,
            Dictionary<string, object>? parameters = null)
        {
            var response = await RequestInner(requestAddress, method, requestBody, parameters);

            T? result = JsonConvert.DeserializeObject<T>(response.Content);

            if (result == null)
                throw new Exception($"Response failed to be deserialized: {response.Content}");

            return result;
        }

        public async Task<bool> Request(string requestAddress, Method method, object? requestBody = null,
            Dictionary<string, object>? parameters = null)
        {
            var response = await RequestInner(requestAddress, method, requestBody, parameters);

            return response.IsSuccessful;
        }

        private async Task<IRestResponse> RequestInner(string requestAddress, Method method, object? requestBody = null,
            Dictionary<string, object>? parameters = null)
        {
            Uri requestUri = new Uri(_config.RestApiUri, requestAddress);

            IRestClient client = new RestClient(requestUri);
            client.AddDefaultHeader("Content-type", "application/json");

            IRestRequest restRequest = new RestRequest(requestUri, method);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    if (parameter.Key == "sessionId")
                    {
                        restRequest.AddQueryParameter(parameter.Key, parameter.Value.ToString() ?? string.Empty);
                    }
                    else
                    {
                        restRequest.AddParameter(parameter.Key, parameter.Value);
                    }
                }
            }

            if (requestBody != null)
            {
                restRequest.AddParameter("format", "json");
                restRequest.AddJsonBody(requestBody);
            }

            var response = await client.ExecuteAsync(restRequest);

            return response;
        }
    }
}
