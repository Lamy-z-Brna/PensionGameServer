using AutoMapper;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Core.Calculators;
using PensionGame.Core.Calculators.RequiredData;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public class GetAvailableToInvestQueryHandler : IGetAvailableToInvestQueryHandler
    {
        private readonly IAvailableToInvestCalculator _availableToInvestCalculator;
        private readonly IMapper _mapper;
        private readonly IDispatcher _dispatcher;

        public GetAvailableToInvestQueryHandler(IAvailableToInvestCalculator availableToInvestCalculator,
            IMapper mapper, 
            IDispatcher dispatcher)
        {
            _availableToInvestCalculator = availableToInvestCalculator;
            _mapper = mapper;
            _dispatcher = dispatcher;
        }

        public async Task<AvailableToInvest> Handle(GetAvailableToInvestQuery query)
        {
            var (clientData, investmentSelection) = query;

            var availableToInvest = _availableToInvestCalculator.Calculate
                (
                    new AvailableToInvestRequiredData
                    (
                        CurrentClientData: _mapper.Map<Core.Domain.ClientData.ClientData>(clientData),
                        InvestmentSelection: _mapper.Map<Core.Domain.ClientData.InvestmentSelection>(investmentSelection)
                    )
                );

            return await Task.FromResult(new AvailableToInvest(availableToInvest));
        }

        public async Task<AvailableToInvest?> Handle(GetAvailableToInvestFromSessionQuery query)
        {
            var (sessionId, investmentSelection) = query;

            var currentGameState = await _dispatcher.Query<GetGameStateQuery, GameState?>
                (
                    new GetGameStateQuery
                    (
                        SessionId: sessionId
                    )
                );

            if (currentGameState == null)
                return null;

            var availableToInvest = await _dispatcher.Query<GetAvailableToInvestQuery, AvailableToInvest>
                (
                    new GetAvailableToInvestQuery
                    (
                        ClientData: currentGameState.ClientData,
                        InvestmentSelection: investmentSelection
                    )
                );

            return availableToInvest;
        }
    }
}
