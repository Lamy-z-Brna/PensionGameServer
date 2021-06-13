using Microsoft.AspNetCore.Mvc;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Exceptions.Session;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PensionGame.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public GameController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid sessionId, InvestmentSelection investmentSelection)
        {
            await _dispatcher.Dispatch(
                new CreateNextStepCommand
                (
                    SessionId: new SessionId(sessionId),
                    InvestmentSelection: investmentSelection
                ));

            return Ok();
        }

        [HttpPost]
        [Route("Next")]
        public async Task<GameState> PostNext(NextGameStateCommand nextGameStateCommand)
        {
            var result = await _dispatcher.Dispatch<GetNextStepCommand, GameState>(
                new GetNextStepCommand
                (
                    GameState: nextGameStateCommand.GameState,
                    InvestmentSelection: nextGameStateCommand.InvestmentSelection
                ));

            return result;
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid sessionId, InvestmentSelection investmentSelection)
        {
            var currentGameState = await _dispatcher.Query<GetGameStateQuery, GameState?>
                (
                    new GetGameStateQuery(new SessionId(sessionId))
                );

            if (currentGameState == null)
                throw new SessionDoesNotExistException();

            await _dispatcher.Dispatch(
                new CheckInvestmentSelectionCommand
                (
                    GameState: currentGameState,
                    InvestmentSelection: investmentSelection
                ));

            return Ok();
        }

        [HttpPut]
        [Route("AvailableToInvest")]
        public async Task<AvailableToInvest?> CheckAvailableBalance(Guid sessionId, InvestmentSelection investmentSelection)
        {
            var result = await _dispatcher.Query<GetAvailableToInvestFromSessionQuery, AvailableToInvest?>
                (
                    new GetAvailableToInvestFromSessionQuery
                    (
                        SessionId: new SessionId(sessionId),
                        InvestmentSelection: investmentSelection
                    )
                );

            return result;
        }

        [HttpGet]
        [Route("ReturnRate")]
        public async Task<PortfolioReturnRate> GetReturnRate(Guid sessionId)
        {
            var result = await _dispatcher.Query<GetPortfolioReturnRateQuery, PortfolioReturnRate>
                (
                    new
                    (
                        SessionId: new SessionId(sessionId)
                    )
                );

            return result;
        }

        [HttpGet]
        [Route("PortfolioValue")]
        public async Task<PortfolioValue?> GetPortfolioValue(Guid sessionId)
        {
            var result = await _dispatcher.Query<GetPortfolioValueQuery, PortfolioValue?>
                (
                    new
                    (
                        SessionId: new SessionId(sessionId)
                    )
                );

            return result;
        }

        [HttpGet]
        public async Task<GameState> Get(Guid sessionId)
        {
            var result = await _dispatcher.Query<GetGameStateQuery, GameState?>
                (
                    new GetGameStateQuery(new SessionId(sessionId))
                );

            if (result == null)
                throw new SessionDoesNotExistException();

            return result;
        }

        [HttpGet]
        [Route("Initial")]
        public async Task<GameState> GetInitial()
        {
            var result = await _dispatcher.Query<GetInitialGameStateQuery, GameState>
                (
                    new GetInitialGameStateQuery(null)
                );
            return result;
        }

        [HttpGet]
        [Route("All")]
        public async Task<Dictionary<int, GameState>> GetAll(Guid sessionId)
        {
            var query = new GetGameStatesQuery(new SessionId(sessionId));

            var result = await _dispatcher.Query<GetGameStatesQuery, Dictionary<int, GameState>>
                (
                    query
                );

            return result;
        }
    }
}
