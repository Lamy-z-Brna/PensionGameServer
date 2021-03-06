using PensionGame.Api.Common.Mappers.GameState;
using PensionGame.Api.Data_Access.Writers.GameData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Exceptions.Session;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public sealed class CreateNextStepCommandHandler : ICreateNextStepCommandHandler
    {
        private readonly IDispatcher _dispatcher;
        private readonly IGameStateWriter _gameStateWriter;
        private readonly IGameStateMapper _gameStateMapper;

        public CreateNextStepCommandHandler(IDispatcher dispatcher,
            IGameStateWriter gameStateWriter, 
            IGameStateMapper gameStateMapper)
        {
            _dispatcher = dispatcher;
            _gameStateWriter = gameStateWriter;
            _gameStateMapper = gameStateMapper;
        }

        public async Task Handle(CreateNextStepCommand command)
        {
            var sessionId = command.SessionId;
            var currentGameState = await _dispatcher
                .Query<GetGameStateQuery, GameState?>
                (
                    new GetGameStateQuery
                    (
                        SessionId: sessionId
                    )
                );

            if (currentGameState == null)
                throw new SessionDoesNotExistException();

            var checkInvestmentSelectionCommand = new CheckInvestmentSelectionCommand(currentGameState, command.InvestmentSelection);

            await _dispatcher.Dispatch(checkInvestmentSelectionCommand);

            var newGameState = await _dispatcher.Query<GetNextGameStateQuery, Core.Domain.GameData.GameState>
                (
                    new GetNextGameStateQuery
                    (
                        CurrentGameState: _gameStateMapper.Map(currentGameState),
                        InvestmentSelection: command.InvestmentSelection
                    )
                );

            await _gameStateWriter.Create(sessionId, newGameState);
        }
    }
}
