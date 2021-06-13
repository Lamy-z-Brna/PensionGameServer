using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Domain.Validation;
using PensionGame.Web.Client;
using System.Collections.Generic;
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
            return await _client.Put<AvailableToInvest>("Game/AvailableToInvest", gameUpdate,
                new() { { "sessionId", sessionId.Id.ToString() } });
        }

        public async Task<ValidationResultModel?> InvestmentSelectionValidate(SessionId sessionId, InvestmentSelection gameUpdate)
        {
            return await _client.Put("Game", gameUpdate,
                new() { { "sessionId", sessionId.Id.ToString() } });
        }

        public async Task<ValidationResultModel?> InvestmentSelectionSubmit(SessionId sessionId, InvestmentSelection gameUpdate)
        {
            var result = await _client.Post("Game",gameUpdate,
                new() { { "sessionId", sessionId.Id } });

            return result;
        }

        public async Task<GameState?> Get(SessionId sessionId)
        {
            return await _client.Get<GameState>("Game", parameters: new() { { "sessionId", sessionId.Id } });
        }

        public async Task<Dictionary<int, GameState>?> GetAll(SessionId sessionId)
        {
            return await _client.Get<Dictionary<int, GameState>>("Game/All", parameters: new() { { "sessionId", sessionId.Id } });
        }

        public async Task<PortfolioReturnRate?> GetPortfolioReturnRate(SessionId sessionId)
        {
            return await _client.Get<PortfolioReturnRate>("Game/ReturnRate", parameters: new() { { "sessionId", sessionId.Id } });
        }
        
        public async Task<PortfolioValue?> GetPortfolioValue(SessionId sessionId)
        {
            return await _client.Get<PortfolioValue>("Game/PortfolioValue", parameters: new() { { "sessionId", sessionId.Id } });
        }

        public async Task<AverageInflationRate?> GetInflationRate(SessionId sessionId)
        {
            return await _client.Get<AverageInflationRate>("Game/InflationRate", parameters: new() { { "sessionId", sessionId.Id } });
        }
    }
}
