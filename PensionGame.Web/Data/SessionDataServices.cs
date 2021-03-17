using System;
using System.Threading.Tasks;
using PensionGame.Web.Data.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace PensionGame.Web.Data
{
    public class SessionDataServices
    {
        public async Task<SessionId> DefaultSessionPost()
        {
            Uri requestUri = new($"https://pensiongameserver.azurewebsites.net/api/Session/Default");

            IRestClient client = new RestClient(requestUri);
            client.AddDefaultHeader("Content-type", "application/json");

            IRestRequest request = new RestRequest(requestUri, Method.POST);
            request.AddParameter("format", "json");

            var response = await client.ExecuteAsync(request);

            var sessionId = JsonConvert.DeserializeObject<SessionId>(response.Content);

            return sessionId;
        }

        public async Task<SessionId> SessionPost(Session session)
        {
            Uri requestUri = new($"https://pensiongameserver.azurewebsites.net/api/Session/New");

            IRestClient client = new RestClient(requestUri);
            client.AddDefaultHeader("Content-type", "application/json");

            IRestRequest request = new RestRequest(requestUri, Method.POST);
            request.AddJsonBody(session);

            var response = await client.ExecuteAsync(request);
            var sessionId = JsonConvert.DeserializeObject<SessionId>(response.Content);

            return sessionId;
        }
    }
}
