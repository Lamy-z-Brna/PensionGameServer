﻿using AutoMapper;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Resources.GameData;
using PensionGame.Core.Calculators;
using PensionGame.Core.Calculators.RequiredData;
using System;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public sealed class CheckInvestmentSelectionCommandHandler : ICheckInvestmentSelectionCommandHandler
    {
        private readonly IDispatcher _dispatcher;
        private readonly IInvestmentSelectionValidationCalculator _investmentSelectionValidationCalculator;
        private readonly IMapper _mapper;

        public CheckInvestmentSelectionCommandHandler(IDispatcher dispatcher,
            IInvestmentSelectionValidationCalculator investmentSelectionValidationCalculator,
            IMapper mapper)
        {
            _dispatcher = dispatcher;
            _investmentSelectionValidationCalculator = investmentSelectionValidationCalculator;
            _mapper = mapper;
        }

        public async Task Handle(CheckInvestmentSelectionCommand command)
        {
            var currentGameState = await _dispatcher.Query<GetGameStateQuery, GameState>(new GetGameStateQuery(command.SessionId.Id));

            var clientData = _mapper.Map<Core.Domain.ClientData.ClientData>(currentGameState.ClientData);
            var investmentSelection = _mapper.Map<Core.Domain.ClientData.InvestmentSelection>(command.InvestmentSelection);

            var result = _investmentSelectionValidationCalculator.Calculate
                (
                    new InvestmentSelectionValidationRequiredData
                    (
                        CurrentClientData: clientData,
                        InvestmentSelection: investmentSelection
                    )
                );

            result.OnError(error => throw new Exception(string.Join(",", error.ErrorMessages)));
        }
    }
}
