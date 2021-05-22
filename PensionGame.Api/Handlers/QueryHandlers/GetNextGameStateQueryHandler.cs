using PensionGame.Api.Common.Mappers.ClientData;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Core.Calculators.GameState;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.GameData;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetNextGameStateQueryHandler : IGetNextGameStateQueryHandler
    {
        private readonly IInvestmentSelectionMapper _investmentSelectionMapper;
        private readonly INextGameStateCalculator _nextGameStateCalculator;

        public GetNextGameStateQueryHandler(IInvestmentSelectionMapper investmentSelectionMapper, 
            INextGameStateCalculator nextGameStateCalculator)
        {
            _investmentSelectionMapper = investmentSelectionMapper;
            _nextGameStateCalculator = nextGameStateCalculator;
        }

        public async Task<GameState> Handle(GetNextGameStateQuery query)
        {
            var currentGameState = query.CurrentGameState;
            var investmentSelection = query.InvestmentSelection;

            var nextGameStateRequiredData = new NextGameStateRequiredData
                (
                    PreviousGameState: currentGameState,
                    InvestmentSelection: _investmentSelectionMapper.Map(investmentSelection)
                );

            var nextGameState = _nextGameStateCalculator.Calculate(nextGameStateRequiredData);

            return await Task.FromResult(nextGameState);
        }
    }
}
