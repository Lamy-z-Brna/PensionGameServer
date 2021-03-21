using Microsoft.AspNetCore.Mvc;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Session;
using System;
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
        public async Task<IActionResult> Post(string sessionId, InvestmentSelection investmentSelection)
        {
            Guid.TryParse(sessionId, out var guid);

            await _dispatcher.Dispatch(
                new CreateNextStepCommand
                (
                    SessionId: new SessionId(guid),
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
        public async Task<IActionResult> Put(string sessionId, InvestmentSelection investmentSelection)
        {
            Guid.TryParse(sessionId, out var guid);

            var currentGameState = await _dispatcher.Query<GetGameStateQuery, GameState>
                (
                    new GetGameStateQuery(new SessionId(guid))                 
                );

            await _dispatcher.Dispatch(
                new CheckInvestmentSelectionCommand
                (
                    GameState: currentGameState,
                    InvestmentSelection: investmentSelection
                ));

            return Ok();
        }

        [HttpGet]
        public async Task<GameState> Get(Guid sessionId)
        {
            var result = await _dispatcher.Query<GetGameStateQuery, GameState>
                (
                    new GetGameStateQuery(new SessionId(sessionId))
                );
            return result;
        }

        [HttpGet]
        [Route("Initial")]
        public async Task<GameState> GetInitial()
        {
            var result = await _dispatcher.Query<GetInitialGameStateQuery, GameState>
                (
                    new GetInitialGameStateQuery()
                );
            return result;
        }
    }
}
