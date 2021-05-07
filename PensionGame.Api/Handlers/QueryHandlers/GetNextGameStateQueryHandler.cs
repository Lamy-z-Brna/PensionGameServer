using PensionGame.Api.Common.Mappers.ClientData;
using PensionGame.Api.Common.Mappers.GameState;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Core.Calculators.GameState;
using PensionGame.Core.Calculators.RequiredData;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetNextGameStateQueryHandler : IGetNextGameStateQueryHandler
    {
        private readonly IInvestmentSelectionMapper _investmentSelectionMapper;
        private readonly IGameStateMapper _gameStateMapper;
        private readonly INextGameStateCalculator _nextGameStateCalculator;

        public GetNextGameStateQueryHandler(IInvestmentSelectionMapper investmentSelectionMapper, 
            IGameStateMapper gameStateMapper,
            INextGameStateCalculator nextGameStateCalculator)
        {
            _investmentSelectionMapper = investmentSelectionMapper;
            _gameStateMapper = gameStateMapper;
            _nextGameStateCalculator = nextGameStateCalculator;
        }

        public async Task<GameState> Handle(GetNextGameStateQuery query)
        {
            var currentGameState = query.CurrentGameState;
            var investmentSelection = query.InvestmentSelection;

            var nextGameStateRequiredData = new NextGameStateRequiredData
                (
                    PreviousGameState: _gameStateMapper.Map(currentGameState),
                    InvestmentSelection: _investmentSelectionMapper.Map(investmentSelection)
                );

            var gameState = _nextGameStateCalculator.Calculate(nextGameStateRequiredData);
            var nextGameState = _gameStateMapper.Map(gameState);

            return await Task.FromResult(nextGameState);
        }
    }
}
