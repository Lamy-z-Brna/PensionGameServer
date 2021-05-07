using PensionGame.Api.Common.Mappers.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Core.Calculators;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public class GetAvailableToInvestQueryHandler : IGetAvailableToInvestQueryHandler
    {
        private readonly IAvailableToInvestCalculator _availableToInvestCalculator;
        private readonly IDispatcher _dispatcher;
        private readonly IClientDataMapper _clientDataMapper;
        private readonly IInvestmentSelectionMapper _investmentSelectionMapper;

        public GetAvailableToInvestQueryHandler(IAvailableToInvestCalculator availableToInvestCalculator,
            IDispatcher dispatcher, IClientDataMapper clientDataMapper,
            IInvestmentSelectionMapper investmentSelectionMapper)
        {
            _availableToInvestCalculator = availableToInvestCalculator;
            _dispatcher = dispatcher;
            _clientDataMapper = clientDataMapper;
            _investmentSelectionMapper = investmentSelectionMapper;
        }

        public async Task<AvailableToInvest> Handle(GetAvailableToInvestQuery query)
        {
            var (clientData, investmentSelection) = query;

            var availableToInvest = _availableToInvestCalculator.Calculate
                (
                    new(
                        CurrentClientData: _clientDataMapper.Map(clientData),
                        InvestmentSelection: _investmentSelectionMapper.Map(investmentSelection)
                    )
                );

            return await Task.FromResult(new AvailableToInvest(availableToInvest));
        }

        public async Task<AvailableToInvest?> Handle(GetAvailableToInvestFromSessionQuery query)
        {
            var (sessionId, investmentSelection) = query;

            var currentGameState = await _dispatcher.Query<GetGameStateQuery, GameState?>
                (
                    new(
                        SessionId: sessionId
                    )
                );

            if (currentGameState == null)
                return null;

            var availableToInvest = await _dispatcher.Query<GetAvailableToInvestQuery, AvailableToInvest>
                (
                    new(
                        ClientData: currentGameState.ClientData,
                        InvestmentSelection: investmentSelection
                    )
                );

            return availableToInvest;
        }
    }
}
