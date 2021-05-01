using Newtonsoft.Json;
using PensionGame.Api.Domain.Validation;
using PensionGame.Common.Functional;
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

        public async Task<ValidationResultModel?> Post(string requestAddress, object? requestBody = null,
            Dictionary<string, object>? parameters = null)
        {
            var response = await RequestInner(requestAddress, Method.POST, requestBody, parameters);

            var validationResult = JsonConvert.DeserializeObject<ValidationResultModel>(response.Content);

            return validationResult;
        }

        public async Task<Union<T, ValidationResultModel>> Post<T>(string requestAddress, object? requestBody = null,
            Dictionary<string, object>? parameters = null)
        {
            var response = await RequestInner(requestAddress, Method.POST, requestBody, parameters);

            var validationResult = JsonConvert.DeserializeObject<ValidationResultModel>(response.Content);

            if (validationResult != null && validationResult.IsFailed)
                return validationResult;

            var result = JsonConvert.DeserializeObject<T>(response.Content);

            return result!;
        }

        public async Task<ValidationResultModel> Put(string requestAddress, object? requestBody = null, Dictionary<string, object>? parameters = null)
        {
            var response = await RequestInner(requestAddress, Method.PUT, requestBody, parameters);

            var validationResult = JsonConvert.DeserializeObject<ValidationResultModel>(response.Content);

            return validationResult!;
        }

        public async Task<T?> Put<T>(string requestAddress, object? requestBody = null,
            Dictionary<string, object>? parameters = null)
        {
            var response = await RequestInner(requestAddress, Method.PUT, requestBody, parameters);

            var result = JsonConvert.DeserializeObject<T>(response.Content);

            return result;
        }

        public async Task<T?> Get<T>(string requestAddress, Dictionary<string, object>? parameters = null)
        {
            var response = await RequestInner(requestAddress, Method.GET, null, parameters);

            var result = JsonConvert.DeserializeObject<T>(response.Content);

            return result;
        }

        private async Task<IRestResponse> RequestInner(string requestAddress, Method method, object? requestBody = null,
            Dictionary<string, object>? parameters = null)
        {
            var requestUri = new Uri(_config.RestApiUri, requestAddress);

            IRestClient client = new RestClient(requestUri);
            client.AddDefaultHeader("Content-type", "application/json");

            IRestRequest restRequest = new RestRequest(requestUri, method);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    restRequest.AddQueryParameter(parameter.Key, parameter.Value.ToString() ?? string.Empty);
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
