using AutoMapper;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Core.Calculators;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Events.Common;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetNextGameStateQueryHandler : IGetNextGameStateQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly INextGameStateCalculator _nextGameStateCalculator;

        public GetNextGameStateQueryHandler(IMapper mapper, 
            INextGameStateCalculator nextGameStateCalculator)
        {
            _mapper = mapper;
            _nextGameStateCalculator = nextGameStateCalculator;
        }

        public async Task<GameState> Handle(GetNextGameStateQuery query)
        {
            var currentGameState = query.CurrentGameState;
            var investmentSelection = query.InvestmentSelection;

            var nextGameStateRequiredData = new NextGameStateRequiredData
                (
                    PreviousGameState: _mapper.Map<Core.Domain.GameData.GameState>(currentGameState),
                    InvestmentSelection: _mapper.Map<Core.Domain.ClientData.InvestmentSelection>(investmentSelection)
                );

            var gameState = _nextGameStateCalculator.Calculate(nextGameStateRequiredData);
            var nextGameState = _mapper.Map<GameState>(gameState);

            return await Task.FromResult(nextGameState);
        }
    }
}
