namespace PensionGame.Api.Common.Mappers.Holdings
{
    public sealed class LoanHoldingMapper : ILoanHoldingMapper
    {
        public Domain.Resources.Holdings.LoanHolding Map(Core.Domain.Holdings.LoanHolding loanHolding)
        {
            return new (
                Amount: loanHolding.Amount, 
                InterestRate: loanHolding.InterestRate
                );
        }

        public Core.Domain.Holdings.LoanHolding Map(Domain.Resources.Holdings.LoanHolding loanHolding)
        {
            return new(
                Amount: loanHolding.Amount,
                InterestRate: loanHolding.InterestRate
                );
        }
    }
}
