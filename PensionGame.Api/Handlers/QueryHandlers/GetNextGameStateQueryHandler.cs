using AutoMapper;
using PensionGame.Api.Common.Mappers;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Core.Calculators;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Events.Common;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetNextGameStateQueryHandler : IGetNextGameStateQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IClientDataMapper _clientDataMapper;
        private readonly IMacroEconomicDataCalculator _macroEconomicDataCalculator;
        private readonly IReturnDataCalculator _returnDataCalculator;
        private readonly IClientDataCalculator _clientDataCalculator;

        public GetNextGameStateQueryHandler(IMapper mapper,
            IClientDataMapper clientDataMapper,
            IMacroEconomicDataCalculator macroEconomicDataCalculator,
            IReturnDataCalculator returnDataCalculator, 
            IClientDataCalculator clientDataCalculator)
        {
            _mapper = mapper;
            _clientDataMapper = clientDataMapper;
            _macroEconomicDataCalculator = macroEconomicDataCalculator;
            _returnDataCalculator = returnDataCalculator;
            _clientDataCalculator = clientDataCalculator;
        }

        public async Task<GameState> Handle(GetNextGameStateQuery query)
        {
            var currentGameState = query.CurrentGameState;
            var investmentSelection = query.InvestmentSelection;

            var macroEconomicData = _macroEconomicDataCalculator.Calculate();
            var returnData = _returnDataCalculator.Calculate(macroEconomicData);

            var previousClientData = _clientDataMapper.Map(currentGameState.ClientData);

            var clientDataRequiredData = new ClientDataRequiredData
                (
                    PreviousClientData: previousClientData,
                    PreviousMarketData: _mapper.Map<Core.Domain.MarketData.MarketData>(currentGameState.MarketData),
                    InvestmentSelection: _mapper.Map<Core.Domain.ClientData.InvestmentSelection>(investmentSelection),
                    MacroEconomicData: macroEconomicData,
                    ReturnData: returnData,
                    Events: Enumerable.Empty<IEvent>()
                );

            var clientData = _clientDataCalculator.Calculate(clientDataRequiredData);
            var newClientData = _mapper.Map<Domain.Resources.ClientData.ClientData>(clientData);
            var newMarketData = new MarketData(_mapper.Map<MacroEconomicData>(macroEconomicData), _mapper.Map<ReturnData>(returnData));

            var newGameState = new GameState(currentGameState.Year + 1, newClientData, newMarketData, false, currentGameState.Year + 1 >= 65);

            return await Task.FromResult(newGameState);
        }
    }
}
