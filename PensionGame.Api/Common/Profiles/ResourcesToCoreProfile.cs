using AutoMapper;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.MarketData;

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

            CreateMap<ClientHoldings, Core.Domain.Holdings.ClientHoldings>();

            CreateMap<ClientData, Core.Domain.ClientData.ClientData>();
        }
    }
}
