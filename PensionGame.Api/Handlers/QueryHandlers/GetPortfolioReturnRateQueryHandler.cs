using PensionGame.Api.Common.Mappers.Holdings;
using PensionGame.Api.Data_Access.Readers.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Core.Calculators.Holdings;
using PensionGame.Core.Calculators.RequiredData;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetPortfolioReturnRateQueryHandler : IGetPortfolioReturnRateQueryHandler
    {
        private readonly IGameStateReader _gameStateReader;
        private readonly IPortfolioReturnMapperCalculator _portfolioReturnCalculator;
        private readonly IPortfolioReturnRateMapper _portfolioReturnRateMapper;

        public GetPortfolioReturnRateQueryHandler(IGameStateReader gameStateReader,
            IPortfolioReturnMapperCalculator portfolioReturnCalculator, 
            IPortfolioReturnRateMapper portfolioReturnRateMapper)
        {
            _gameStateReader = gameStateReader;
            _portfolioReturnCalculator = portfolioReturnCalculator;
            _portfolioReturnRateMapper = portfolioReturnRateMapper;
        }

        public async Task<PortfolioReturnRate?> Handle(GetPortfolioReturnRateQuery query)
        {
            var result = await _gameStateReader.Get(query.SessionId);

            var returnRate = _portfolioReturnCalculator.Calculate(new PortfolioReturnRateRequiredData(result));

            if (returnRate == null)
                return null;

            return _portfolioReturnRateMapper.Map(returnRate);
        }
    }
}
