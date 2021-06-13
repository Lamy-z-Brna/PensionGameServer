namespace PensionGame.Api.Common.Mappers.Holdings
{
    public sealed class PortfolioReturnRateMapper : IPortfolioReturnRateMapper
    {
        public Domain.Resources.Holdings.PortfolioReturnRate Map(Core.Domain.Holdings.PortfolioReturnRate portfolioReturnRate)
        {
            return new(portfolioReturnRate.ReturnRate);
        }
    }
}
