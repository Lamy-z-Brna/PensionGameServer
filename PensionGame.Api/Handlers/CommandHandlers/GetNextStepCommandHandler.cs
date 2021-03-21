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

        public GetNextStepCommandHandler(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public async Task<GameState> Handle(GetNextStepCommand command)
        {
            var checkInvestmentSelectionCommand = new CheckInvestmentSelectionCommand(command.GameState, command.InvestmentSelection);

            await _dispatcher.Dispatch(checkInvestmentSelectionCommand);

            var newGameState = await _dispatcher.Query<GetNextGameStateQuery, GameState>
                (
                    new GetNextGameStateQuery
                    (
                        CurrentGameState: command.GameState,
                        InvestmentSelection: command.InvestmentSelection
                    )
                );

            return newGameState;
        }
    }
}
