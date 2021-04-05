using AutoMapper;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.MarketData;

namespace PensionGame.Api.Common.Profiles
{
    public sealed class CoreToResourcesProfile : Profile
    {
        public CoreToResourcesProfile()
        {
            CreateMap<Core.Domain.ClientData.InvestmentSelection, InvestmentSelection>();

            CreateMap<Core.Domain.ClientData.IncomeData, IncomeData>();

            CreateMap<Core.Domain.ClientData.ExpenseData, ExpenseData>();

            CreateMap<Core.Domain.Holdings.StockHolding, StockHolding>();

            CreateMap<Core.Domain.Holdings.BondHolding, BondHolding>();

            CreateMap<Core.Domain.Holdings.BondHoldings, BondHoldings>();

            CreateMap<Core.Domain.Holdings.SavingsAccountHoldings, SavingsAccountHoldings>();

            CreateMap<Core.Domain.Holdings.LoanHolding, LoanHolding>();

            CreateMap<Core.Domain.Holdings.LoanHoldings, LoanHoldings>();

            CreateMap<Core.Domain.Holdings.ClientHoldings, ClientHoldings>();

            CreateMap<Core.Domain.ClientData.ClientData, ClientData>();

            CreateMap<Core.Domain.MarketData.MacroEconomicData, MacroEconomicData>();

            CreateMap<Core.Domain.MarketData.ReturnData, ReturnData>();

            CreateMap<Core.Domain.MarketData.MarketData, MarketData>();

            CreateMap<Core.Domain.GameData.GameState, GameState>();
                //.ForMember(dest => dest.IsInitial, opt => opt.MapFrom(src => false));
        }
    }
}
