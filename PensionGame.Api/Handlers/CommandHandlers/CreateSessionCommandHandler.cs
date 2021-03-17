using AutoMapper;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;
using PensionGame.Api.Data_Access.Writers.Session;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public sealed class CreateSessionCommandHandler : ICreateSessionCommandHandler
    {
        private readonly ISessionWriter _sessionWriter;
        private readonly IMapper _mapper;

        public CreateSessionCommandHandler(ISessionWriter sessionWriter, 
            IMapper mapper)
        {
            _sessionWriter = sessionWriter;
            _mapper = mapper;
        }

        public async Task<SessionId> Handle(CreateSessionCommand command)
        {
            var startupParameters = command.StartupParameters ?? new StartupParameters(123456, 23456, 20, 65);
            var result = await _sessionWriter.Create(startupParameters.Income, startupParameters.Expenses, startupParameters.Year, startupParameters.RetirementYear);

            var sessionId = _mapper.Map<SessionId>(result);

            return sessionId;
        }
    }
}
