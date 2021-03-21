using AutoMapper;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Calculators.Validation;
using System.Threading.Tasks;
using PensionGame.Api.Domain.Validation;
using PensionGame.Api.Domain.Resources.Holdings;
using System.Collections.Generic;
using PensionGame.Core.Common;
using System.Linq;
using PensionGame.Api.Common.Mappers;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public sealed class CheckInvestmentSelectionCommandHandler : ICheckInvestmentSelectionCommandHandler
    {
        private readonly IInvestmentSelectionValidationCalculator _investmentSelectionValidationCalculator;
        private readonly IMapper _mapper;
        private readonly IClientDataMapper _clientDataMapper;

        public CheckInvestmentSelectionCommandHandler(IInvestmentSelectionValidationCalculator investmentSelectionValidationCalculator,
            IMapper mapper, IClientDataMapper clientDataMapper)
        {
            _investmentSelectionValidationCalculator = investmentSelectionValidationCalculator;
            _mapper = mapper;
            _clientDataMapper = clientDataMapper;
        }

        public async Task Handle(CheckInvestmentSelectionCommand command)
        {
            var currentGameState = command.GameState;
            var currentClientHoldings = currentGameState.ClientData.ClientHoldings;

            var clientData = _clientDataMapper.Map(currentGameState.ClientData);
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
