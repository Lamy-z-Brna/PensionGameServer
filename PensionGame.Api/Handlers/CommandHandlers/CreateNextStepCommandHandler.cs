﻿using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Domain.Resources.GameData;
using System.Threading.Tasks;
using PensionGame.Api.Data_Access.Writers.GameData;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public sealed class CreateNextStepCommandHandler : ICreateNextStepCommandHandler
    {
        private readonly IDispatcher _dispatcher;
        private readonly IGameStateWriter _gameStateWriter;

        public CreateNextStepCommandHandler(IDispatcher dispatcher, 
            IGameStateWriter gameStateWriter)
        {
            _dispatcher = dispatcher;
            _gameStateWriter = gameStateWriter;
        }

        public async Task Handle(CreateNextStepCommand command)
        {
            var sessionId = command.SessionId;           
            var currentGameState = await _dispatcher
                .Query<GetGameStateQuery, GameState>
                (
                    new GetGameStateQuery
                    (
                        SessionId: sessionId
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

            await _gameStateWriter.Create(sessionId, newGameState);
        }
    }
}
