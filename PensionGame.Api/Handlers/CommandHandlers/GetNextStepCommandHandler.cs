using PensionGame.Api.Common.Mappers.GameState;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public sealed class GetNextStepCommandHandler : IGetNextStepCommandHandler
    {
        private readonly IDispatcher _dispatcher;
        private readonly IGameStateMapper _gameStateMapper;

        public GetNextStepCommandHandler(IDispatcher dispatcher, 
            IGameStateMapper gameStateMapper)
        {
            _dispatcher = dispatcher;
            _gameStateMapper = gameStateMapper;
        }

        public async Task<GameState> Handle(GetNextStepCommand command)
        {
            var (gameState, investmentSelection) = command;
            var checkInvestmentSelectionCommand = new CheckInvestmentSelectionCommand(gameState, investmentSelection);

            await _dispatcher.Dispatch(checkInvestmentSelectionCommand);

            var newGameState = await _dispatcher.Query<GetNextGameStateQuery, Core.Domain.GameData.GameState>
                (
                    new GetNextGameStateQuery
                    (
                        CurrentGameState: _gameStateMapper.Map(gameState),
                        InvestmentSelection: investmentSelection
                    )
                );

            return _gameStateMapper.Map(newGameState);
        }
    }
}
