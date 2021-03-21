using AutoMapper;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;
using PensionGame.Api.Data_Access.Writers.Session;
using PensionGame.Api.Data_Access.Writers.GameData;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Domain.Resources.GameData;

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
            var startupParameters = command.StartupParameters ?? new StartupParameters(123456, 23456, 20, 65);
            var result = await _sessionWriter.Create(startupParameters.Income, startupParameters.Expenses, startupParameters.Year, startupParameters.RetirementYear);

            var sessionId = _mapper.Map<SessionId>(result);
            var initialGameState = await _dispatcher.Query<GetInitialGameStateQuery, GameState>(new GetInitialGameStateQuery());

            await _gameStateWriter.Create(sessionId, initialGameState);

            return sessionId;
        }
    }
}
