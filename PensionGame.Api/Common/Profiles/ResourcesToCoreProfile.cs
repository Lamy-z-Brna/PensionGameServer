using AutoMapper;
using PensionGame.Api.Resources.ClientData;
using PensionGame.Api.Resources.Holdings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
