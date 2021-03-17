using AutoMapper;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Core.Calculators;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Events.Common;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public sealed class CreateNextStepCommandHandler : ICreateNextStepCommandHandler
    {
        private readonly IDispatcher _dispatcher;
        private readonly IMapper _mapper;
        private readonly IMacroEconomicDataCalculator _macroEconomicDataCalculator;
        private readonly IReturnDataCalculator _returnDataCalculator;
        private readonly IClientDataCalculator _clientDataCalculator;


        public CreateNextStepCommandHandler(IDispatcher dispatcher,
            IMapper mapper, 
            IMacroEconomicDataCalculator macroEconomicDataCalculator, 
            IReturnDataCalculator returnDataCalculator, 
            IClientDataCalculator clientDataCalculator)
        {
            _dispatcher = dispatcher;
            _mapper = mapper;
            _macroEconomicDataCalculator = macroEconomicDataCalculator;
            _returnDataCalculator = returnDataCalculator;
            _clientDataCalculator = clientDataCalculator;
        }

        public async Task Handle(CreateNextStepCommand command)
        {
            var checkInvestmentSelectionCommand = _mapper.Map<CheckInvestmentSelectionCommand>(command);

            await _dispatcher.Dispatch(checkInvestmentSelectionCommand);

            var getGameStateQuery = new GetGameStateQuery
                (
                    SessionId: command.SessionId.Id
                );

            var currentGameState = await _dispatcher.Query<GetGameStateQuery, GameState>(getGameStateQuery);

            var macroEconomicData = _macroEconomicDataCalculator.Calculate();
            var returnData = _returnDataCalculator.Calculate(macroEconomicData);

            var clientDataRequiredData = new ClientDataRequiredData
                (
                    PreviousClientData: _mapper.Map<Core.Domain.ClientData.ClientData>(currentGameState.ClientData),
                    InvestmentSelection: _mapper.Map<Core.Domain.ClientData.InvestmentSelection>(command.InvestmentSelection),
                    MacroEconomicData: macroEconomicData,
                    ReturnData: returnData,
                    Events: Enumerable.Empty<IEvent>()
                );

            var clientData = _clientDataCalculator.Calculate(clientDataRequiredData);
        }
    }
}
