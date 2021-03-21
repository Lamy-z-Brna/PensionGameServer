using AutoMapper;
using PensionGame.Api.Domain.Resources.ClientData;
using System;
using System.Collections.Generic;
using PensionGame.Core.Common;

namespace PensionGame.Api.Common.Mappers
{
    public sealed class ClientDataMapper : IClientDataMapper
    {
        private readonly IMapper _mapper;

        public ClientDataMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Core.Domain.ClientData.ClientData Map(ClientData @in)
        {
            var bonds = _mapper.Map<IEnumerable<Core.Domain.Holdings.BondHolding>>(@in.ClientHoldings.Bonds);
            var loans = _mapper.Map<IEnumerable<Core.Domain.Holdings.LoanHolding>>(@in.ClientHoldings.Loans);

            var clientHoldings = new Core.Domain.Holdings.ClientHoldings
                (
                    Stocks: _mapper.Map<Core.Domain.Holdings.StockHolding>(@in.ClientHoldings.Stocks),
                    Bonds: bonds.ToBonds(),
                    SavingsAccount: _mapper.Map<Core.Domain.Holdings.SavingsAccountHoldings>(@in.ClientHoldings.SavingsAccount),
                    Loans: loans.ToLoans()
                );
            var incomeData = _mapper.Map<Core.Domain.ClientData.IncomeData>(@in.IncomeData);
            var expenseData = _mapper.Map<Core.Domain.ClientData.ExpenseData>(@in.ExpenseData);

            var clientData = new Core.Domain.ClientData.ClientData(ClientHoldings: clientHoldings, IncomeData: incomeData, ExpenseData: expenseData);

            return clientData;
        }
    }
}
