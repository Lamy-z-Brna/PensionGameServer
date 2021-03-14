using Microsoft.AspNetCore.Mvc;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Resources.ClientData;
using PensionGame.Api.Resources.GameData;
using PensionGame.Api.Resources.Session;
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

        [HttpPut]
        public async Task<IActionResult> Put(Guid sessionId, InvestmentSelection investmentSelection)
        {
            await _dispatcher.Dispatch(
                new CheckInvestmentSelectionCommand
                (
                    SessionId: new SessionId(sessionId),
                    InvestmentSelection: investmentSelection
                ));

            return Ok();
        }
        [HttpGet]
        public async Task<GameState> Get(Guid sessionId)
        {
            var result = await _dispatcher.Query<GetGameStateQuery, GameState>
                (
                    new GetGameStateQuery(sessionId)
                );
            return result;
        }
    }
}
