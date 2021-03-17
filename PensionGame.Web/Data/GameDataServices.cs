using System;
using System.Threading.Tasks;
using PensionGame.Web.Data.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace PensionGame.Web.Data
{
    public class GameDataServices
    {
        public async Task<bool> GameUpdate(SessionId sessionId, GameUpdate gameUpdate, Method method)
        {
            Uri requestUri = new($"https://pensiongameserver.azurewebsites.net/api/Game");

            IRestClient client = new RestClient(requestUri);
            client.AddDefaultHeader("Content-type", "application/json");

            IRestRequest request = new RestRequest(requestUri, method);
            request.AddParameter("sessionId",sessionId.Id);
            request.AddJsonBody(gameUpdate);

            var response = await client.ExecuteAsync(request);

            return response.IsSuccessful;
        }

        public async Task<GameData> GameDataGet(SessionId sessionId)
        {
            if (string.IsNullOrEmpty(sessionId.Id))
            {
                return null;
            }

            Uri requestUri = new($"https://pensiongameserver.azurewebsites.net/api/Game");

            IRestClient client = new RestClient(requestUri);
            client.AddDefaultHeader("Content-type", "application/json");

            IRestRequest request = new RestRequest(requestUri, Method.GET);
            request.AddParameter("sessionId", sessionId.Id);

            var response = await client.ExecuteAsync(request);
            var gameData = JsonConvert.DeserializeObject<GameData>(response.Content);

            return gameData;
        }
    }
}
