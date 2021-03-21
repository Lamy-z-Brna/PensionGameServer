using AutoMapper;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Calculators.Validation;
using System.Threading.Tasks;
using PensionGame.Api.Domain.Validation;
using PensionGame.Api.Domain.Resources.ClientData;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public sealed class CheckInvestmentSelectionCommandHandler : ICheckInvestmentSelectionCommandHandler
    {
        private readonly IInvestmentSelectionValidationCalculator _investmentSelectionValidationCalculator;
        private readonly IMapper _mapper;

        public CheckInvestmentSelectionCommandHandler(IInvestmentSelectionValidationCalculator investmentSelectionValidationCalculator,
            IMapper mapper)
        {
            _investmentSelectionValidationCalculator = investmentSelectionValidationCalculator;
            _mapper = mapper;
        }

        public async Task Handle(CheckInvestmentSelectionCommand command)
        {
            var currentGameState = command.GameState;
            var currentClientHoldings = currentGameState.ClientData.ClientHoldings;

            var clientData = _mapper.Map<ClientData, Core.Domain.ClientData.ClientData>(currentGameState.ClientData);
             var investmentSelection = _mapper.Map<Core.Domain.ClientData.InvestmentSelection>(command.InvestmentSelection);

            var result = _investmentSelectionValidationCalculator.Calculate
                (
                    new InvestmentSelectionValidationRequiredData
                    (
                        CurrentClientData: clientData,
                        InvestmentSelection: investmentSelection
                    )
                );

            result.OnError(error => throw new ValidationException(string.Join(",", error.ErrorMessages)));
        }
    }
}
