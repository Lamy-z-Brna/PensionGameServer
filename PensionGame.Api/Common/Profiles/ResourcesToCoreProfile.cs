using AutoMapper;
using PensionGame.Api.Resources.ClientData;
using PensionGame.Api.Resources.Holdings;

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

            CreateMap<SavingsAccountHoldings, Core.Domain.Holdings.SavingsAccountHoldings>();

            CreateMap<LoanHolding, Core.Domain.Holdings.LoanHolding>();

            CreateMap<ClientHoldings, Core.Domain.Holdings.ClientHoldings>();

            CreateMap<ClientData, Core.Domain.ClientData.ClientData>();
        }
    }
}
