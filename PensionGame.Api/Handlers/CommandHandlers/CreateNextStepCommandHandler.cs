using AutoMapper;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var checkInvestmentSelectionCommand = _mapper.Map<CheckInvestmentSelectionCommand>(command);

            await _dispatcher.Dispatch(checkInvestmentSelectionCommand);
        }
    }
}
