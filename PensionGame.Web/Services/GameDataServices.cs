using System.Threading.Tasks;
using RestSharp;
using PensionGame.Web.Client;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.Session;

namespace PensionGame.Web.Services
{
    public class GameDataServices
    {
        private readonly IServiceClient _client;

        public GameDataServices(IServiceClient client)
        {
            _client = client;
        }

        public async Task<bool> InvestmentSelectionValidate(SessionId sessionId, InvestmentSelection gameUpdate)
        {
            return await _client.Request("Game", Method.PUT, gameUpdate,
                new() { { "sessionId", sessionId.Id } });
        }

        public async Task<bool> InvestmentSelectionSubmit(SessionId sessionId, InvestmentSelection gameUpdate)
        {
            return await _client.Request("Game", Method.POST, gameUpdate,
                new() { { "sessionId", sessionId.Id } });
        }

        public async Task<GameState> GameStateGet(SessionId sessionId)
        {
            return await _client.Request<GameState>("Game", Method.GET,
                parameters : new() { { "sessionId", sessionId.Id } });
        }
    }
}
