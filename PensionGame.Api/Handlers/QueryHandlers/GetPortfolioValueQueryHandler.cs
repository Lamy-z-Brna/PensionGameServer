using PensionGame.Api.Common.Mappers.Holdings;
using PensionGame.Api.Data_Access.Readers.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Core.Calculators.Holdings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetPortfolioValueQueryHandler : IGetPortfolioValueQueryHandler
    {
        private readonly IPortfolioValueCalculator _portfolioValueCalculator;
        private readonly IGameStateReader _gameStateReader;
        private readonly IPortfolioValueMapper _portfolioValueMapper;

        public GetPortfolioValueQueryHandler(IPortfolioValueCalculator portfolioValueCalculator,
            IGameStateReader gameStateReader, 
            IPortfolioValueMapper portfolioValueMapper)
        {
            _portfolioValueCalculator = portfolioValueCalculator;
            _gameStateReader = gameStateReader;
            _portfolioValueMapper = portfolioValueMapper;
        }

        public async Task<PortfolioValue?> Handle(GetPortfolioValueQuery query)
        {
            var gameState = await _gameStateReader.GetCurrentGameState(query.SessionId);

            if (gameState == null)
                return null;

            var portfolioValue = _portfolioValueCalculator.Calculate(new(gameState));

            return _portfolioValueMapper.Map(portfolioValue);
        }
    }
}
