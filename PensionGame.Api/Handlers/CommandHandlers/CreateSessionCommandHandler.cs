using PensionGame.Api.Common.Mappers;
using PensionGame.Api.Domain.Session;
using PensionGame.Api.Handlers.Commands;
using PensionGame.DataAccess.Writers.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public sealed class CreateSessionCommandHandler : ICreateSessionCommandHandler
    {
        private readonly ISessionWriter _sessionWriter;
        private readonly ISessionIdMapper _sessionIdMapper;

        public CreateSessionCommandHandler(ISessionWriter sessionWriter,
            ISessionIdMapper sessionIdMapper)
        {
            _sessionWriter = sessionWriter;
            _sessionIdMapper = sessionIdMapper;
        }

        public async Task<SessionId> Handle(CreateSessionCommand command)
        {
            var startupParameters = command.StartupParameters ?? new StartupParameters(123456, 23456, 20, 65);
            var result = await _sessionWriter.Create(startupParameters.Income, startupParameters.Expenses, startupParameters.Year, startupParameters.RetirementYear);

            var sessionId = _sessionIdMapper.Map(result);

            return sessionId;
        }
    }
}
