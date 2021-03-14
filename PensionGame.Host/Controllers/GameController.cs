using Microsoft.AspNetCore.Mvc;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using PensionGame.Api.Resources.ClientData;
using PensionGame.Api.Resources.Events;
using PensionGame.Api.Resources.GameData;
using PensionGame.Api.Resources.Holdings;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    SessionId: new Api.Domain.Session.SessionId(sessionId),
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
                    SessionId: new Api.Domain.Session.SessionId(sessionId),
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
