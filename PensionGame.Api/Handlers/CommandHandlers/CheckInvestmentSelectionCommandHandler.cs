using PensionGame.Api.Common.Mappers.ClientData;
using PensionGame.Api.Domain.Validation;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Calculators.Validation;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public sealed class CheckInvestmentSelectionCommandHandler : ICheckInvestmentSelectionCommandHandler
    {
        private readonly IInvestmentSelectionValidationCalculator _investmentSelectionValidationCalculator;
        private readonly IClientDataMapper _clientDataMapper;
        private readonly IInvestmentSelectionMapper _investmentSelectionMapper;

        public CheckInvestmentSelectionCommandHandler(IInvestmentSelectionValidationCalculator investmentSelectionValidationCalculator,
            IClientDataMapper clientDataMapper, 
            IInvestmentSelectionMapper investmentSelectionMapper)
        {
            _investmentSelectionValidationCalculator = investmentSelectionValidationCalculator;
            _clientDataMapper = clientDataMapper;
            _investmentSelectionMapper = investmentSelectionMapper;
        }

        public async Task Handle(CheckInvestmentSelectionCommand command)
        {
            var currentGameState = command.GameState;
            var currentClientHoldings = currentGameState.ClientData.ClientHoldings;

            var clientData = _clientDataMapper.Map(currentGameState.ClientData);
            var investmentSelection = _investmentSelectionMapper.Map(command.InvestmentSelection);

            var result = await Task.Run(() => _investmentSelectionValidationCalculator.Calculate
                (
                    new InvestmentSelectionValidationRequiredData
                    (
                        CurrentClientData: clientData,
                        InvestmentSelection: investmentSelection
                    )
                ));

            result.OnError(error => throw new ValidationException(string.Join(",", error.ErrorMessages)));
        }
    }
}
