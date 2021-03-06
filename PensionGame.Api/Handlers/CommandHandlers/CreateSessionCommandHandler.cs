using PensionGame.Api.Data_Access.Writers.GameData;
using PensionGame.Api.Data_Access.Writers.Session;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public sealed class CreateSessionCommandHandler : ICreateSessionCommandHandler
    {
        private readonly ISessionWriter _sessionWriter;
        private readonly IGameStateWriter _gameStateWriter;
        private readonly IDispatcher _dispatcher;

        public CreateSessionCommandHandler(ISessionWriter sessionWriter,
            IGameStateWriter gameStateWriter,
            IDispatcher dispatcher)
        {
            _sessionWriter = sessionWriter;
            _gameStateWriter = gameStateWriter;
            _dispatcher = dispatcher;
        }

        public async Task<SessionId> Handle(CreateSessionCommand command)
        {
            var (name, startupParameters) = command;
            var sessionId = await _sessionWriter.Create(name, startupParameters);

            var initialGameState = await _dispatcher.Query<GetInitialCoreGameStateQuery, Core.Domain.GameData.GameState>
                (
                    new
                    (
                        StartupParameters: startupParameters
                    )
                );

            await _gameStateWriter.Create(sessionId, initialGameState);

            return sessionId;
        }
    }
}
