using System.Threading.Tasks;
using PensionGame.Web.Data.Entities;
using RestSharp;
using PensionGame.Web.Client;

namespace PensionGame.Web.Services
{
    public class GameDataServices
    {
        private readonly IServiceClient _client;

        public GameDataServices(IServiceClient client)
        {
            _client = client;
        }

        public async Task<bool> GameUpdateValidate(SessionId sessionId, GameUpdate gameUpdate)
        {
            return await _client.Request("Game", Method.PUT, gameUpdate,
                new() { { "sessionId", sessionId.Id } });
        }

        public async Task<bool> GameUpdateSubmit(SessionId sessionId, GameUpdate gameUpdate)
        {
            return await _client.Request("Game", Method.POST, gameUpdate,
                new() { { "sessionId", sessionId.Id } });
        }

        public async Task<GameData> GameDataGet(SessionId sessionId)
        {
            return await _client.Request<GameData>("Game", Method.GET,
                parameters : new() { { "sessionId", sessionId.Id } });
        }
    }
}
