using PensionGame.Api.Common.Helpers;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Core.Common;

namespace PensionGame.Api.Common.Mappers.Holdings
{
    public sealed class ClientHoldingsMapper : IClientHoldingsMapper
    {
        private readonly IStockHoldingMapper _stockHoldingMapper;
        private readonly IBondHoldingMapper _bondHoldingMapper;
        private readonly ISavingsAccountHoldingMapper _savingsAccountHoldingMapper;
        private readonly ILoanHoldingMapper _loanHoldingMapper;

        public ClientHoldingsMapper(IStockHoldingMapper stockHoldingMapper, 
            IBondHoldingMapper bondHoldingMapper, 
            ISavingsAccountHoldingMapper savingsAccountHoldingMapper, 
            ILoanHoldingMapper loanHoldingMapper)
        {
            _stockHoldingMapper = stockHoldingMapper;
            _bondHoldingMapper = bondHoldingMapper;
            _savingsAccountHoldingMapper = savingsAccountHoldingMapper;
            _loanHoldingMapper = loanHoldingMapper;
        }        

        public ClientHoldings Map(Core.Domain.Holdings.ClientHoldings clientHoldings)
        {
            return new(
                Stocks: _stockHoldingMapper.Map(clientHoldings.Stocks),
                Bonds: new BondHoldings(_bondHoldingMapper.Map<Core.Domain.Holdings.BondHolding, BondHolding>(clientHoldings.Bonds)),
                SavingsAccount: _savingsAccountHoldingMapper.Map(clientHoldings.SavingsAccount),
                Loans: new LoanHoldings(_loanHoldingMapper.Map<Core.Domain.Holdings.LoanHolding, LoanHolding>(clientHoldings.Loans))
            );
        }

        public Core.Domain.Holdings.ClientHoldings Map(ClientHoldings clientHoldings)
        {
            return new(
                Stocks: _stockHoldingMapper.Map(clientHoldings.Stocks),
                Bonds: _bondHoldingMapper.Map<BondHolding, Core.Domain.Holdings.BondHolding>(clientHoldings.Bonds).ToBonds(),
                SavingsAccount: _savingsAccountHoldingMapper.Map(clientHoldings.SavingsAccount),
                Loans: _loanHoldingMapper.Map<LoanHolding, Core.Domain.Holdings.LoanHolding>(clientHoldings.Loans).ToLoans()
            );
        }
    }
}
