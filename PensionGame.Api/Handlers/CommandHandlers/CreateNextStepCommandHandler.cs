using AutoMapper;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Domain.Resources.GameData;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public sealed class CreateNextStepCommandHandler : ICreateNextStepCommandHandler
    {
        private readonly IDispatcher _dispatcher;
        private readonly IMapper _mapper;


        public CreateNextStepCommandHandler(IDispatcher dispatcher,
            IMapper mapper)
        {
            _dispatcher = dispatcher;
            _mapper = mapper;
        }

        public async Task Handle(CreateNextStepCommand command)
        {
            var sessionId = command.SessionId;           
            var currentGameState = await _dispatcher
                .Query<GetGameStateQuery, GameState>
                (
                    new GetGameStateQuery
                    (
                        SessionId: sessionId.Id
                    )
                );

            var checkInvestmentSelectionCommand = new CheckInvestmentSelectionCommand(currentGameState, command.InvestmentSelection);

            await _dispatcher.Dispatch(checkInvestmentSelectionCommand);

            var newGameState = await _dispatcher.Query<GetNextGameStateQuery, GameState>
                (
                    new GetNextGameStateQuery
                    (
                        CurrentGameState: currentGameState,
                        InvestmentSelection: command.InvestmentSelection
                    )
                );
        }
    }
}
