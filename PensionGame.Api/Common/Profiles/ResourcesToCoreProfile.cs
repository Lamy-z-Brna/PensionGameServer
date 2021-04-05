using AutoMapper;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.MarketData;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Api.Common.Profiles
{
    public sealed class ResourcesToCoreProfile : Profile
    {
        public ResourcesToCoreProfile()
        {
            CreateMap<InvestmentSelection, Core.Domain.ClientData.InvestmentSelection>();

            CreateMap<IncomeData, Core.Domain.ClientData.IncomeData>();

            CreateMap<ExpenseData, Core.Domain.ClientData.ExpenseData>();

            CreateMap<StockHolding, Core.Domain.Holdings.StockHolding>();

            CreateMap<BondHolding, Core.Domain.Holdings.BondHolding>();

            CreateMap<BondHoldings, Core.Domain.Holdings.BondHoldings>();

            CreateMap<SavingsAccountHoldings, Core.Domain.Holdings.SavingsAccountHoldings>();

            CreateMap<LoanHolding, Core.Domain.Holdings.LoanHolding>();

            CreateMap<LoanHoldings, Core.Domain.Holdings.LoanHoldings>();

            CreateMap<IEnumerable<BondHolding>, Core.Domain.Holdings.BondHoldings>()
                .ConvertUsing((src, _, context) => new Core.Domain.Holdings.BondHoldings(src.Select(bond => context.Mapper.Map<BondHolding, Core.Domain.Holdings.BondHolding>(bond))));

            CreateMap<IEnumerable<LoanHolding>, Core.Domain.Holdings.LoanHoldings>()
                .ConvertUsing((src, _, context) => new Core.Domain.Holdings.LoanHoldings(src.Select(loan => context.Mapper.Map<LoanHolding, Core.Domain.Holdings.LoanHolding>(loan))));

            CreateMap<ClientHoldings, Core.Domain.Holdings.ClientHoldings>();

            CreateMap<ClientData, Core.Domain.ClientData.ClientData>();

            CreateMap<MacroEconomicData, Core.Domain.MarketData.MacroEconomicData>();

            CreateMap<ReturnData, Core.Domain.MarketData.ReturnData>();

            CreateMap<MarketData, Core.Domain.MarketData.MarketData>();

            CreateMap<GameState, Core.Domain.GameData.GameState>();                
        }
    }
}
