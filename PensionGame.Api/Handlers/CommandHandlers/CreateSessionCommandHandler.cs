using AutoMapper;
using PensionGame.Api.Data_Access.Writers.GameData;
using PensionGame.Api.Data_Access.Writers.Session;
using PensionGame.Api.Domain.Resources.GameData;
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
        private readonly IMapper _mapper;

        public CreateSessionCommandHandler(ISessionWriter sessionWriter,
            IGameStateWriter gameStateWriter,
            IDispatcher dispatcher,
            IMapper mapper)
        {
            _sessionWriter = sessionWriter;
            _gameStateWriter = gameStateWriter;
            _dispatcher = dispatcher;
            _mapper = mapper;
        }

        public async Task<SessionId> Handle(CreateSessionCommand command)
        {
            var (name, startupParameters) = command;
            var result = await _sessionWriter.Create(name, startupParameters);

            var sessionId = _mapper.Map<SessionId>(result);
            var initialGameState = await _dispatcher.Query<GetInitialGameStateQuery, GameState>
                (
                    new GetInitialGameStateQuery
                    (
                        StartupParameters: startupParameters
                    )
                );

            await _gameStateWriter.Create(sessionId, initialGameState);

            return sessionId;
        }
    }
}
