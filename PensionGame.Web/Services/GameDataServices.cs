using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Domain.Validation;
using PensionGame.Web.Client;
using RestSharp;
using System.Threading.Tasks;

namespace PensionGame.Web.Services
{
    public class GameDataServices
    {
        private readonly IServiceClient _client;

        public GameDataServices(IServiceClient client)
        {
            _client = client;
        }

        public async Task<AvailableToInvest?> GetAvailableToInvest(SessionId sessionId, InvestmentSelection gameUpdate)
        {
            return await _client.Request<AvailableToInvest>("Game/AvailableToInvest", Method.PUT, gameUpdate,
                new() { { "sessionId", sessionId.Id.ToString() } });
        }

        public async Task<ValidationResultModel?> InvestmentSelectionValidate(SessionId sessionId, InvestmentSelection gameUpdate)
        {
            return await _client.Request<ValidationResultModel>("Game", Method.PUT, gameUpdate,
                new() { { "sessionId", sessionId.Id.ToString() } });
        }

        public async Task<bool> InvestmentSelectionSubmit(SessionId sessionId, InvestmentSelection gameUpdate)
        {
            return await _client.Request("Game", Method.POST, gameUpdate,
                new() { { "sessionId", sessionId.Id } });
        }

        public async Task<GameState?> GameStateGet(SessionId sessionId)
        {
            return await _client.Request<GameState>("Game", Method.GET,
                parameters: new() { { "sessionId", sessionId.Id } });
        }
    }
}
