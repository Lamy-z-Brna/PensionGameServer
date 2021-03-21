using AutoMapper;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Core.Common;
using System.Collections.Generic;

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

            CreateMap<ClientHoldings, Core.Domain.Holdings.ClientHoldings>()
                .ForMember(dest => dest.Bonds, src => src.MapFrom((@from, _, _, context) =>
                {
                    return context.Mapper.Map<BondHoldings, Core.Domain.Holdings.BondHoldings>(new BondHoldings(@from.Bonds));
                }))
                .ForMember(dest => dest.Loans, src => src.MapFrom((@from, _, _, context) =>
                {
                    return context.Mapper.Map<IEnumerable<LoanHolding>, IEnumerable<Core.Domain.Holdings.LoanHolding>>(@from.Loans).ToLoans();
                }));

            CreateMap<ClientData, Core.Domain.ClientData.ClientData>();                

            CreateMap<MacroEconomicData, Core.Domain.MarketData.MacroEconomicData>();

            CreateMap<ReturnData, Core.Domain.MarketData.ReturnData>();

            CreateMap<MarketData, Core.Domain.MarketData.MarketData>();
        }
    }
}
