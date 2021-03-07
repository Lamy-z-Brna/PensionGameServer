using Microsoft.AspNetCore.Mvc;
using PensionGame.Api.Domain.Session;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using System.Threading.Tasks;

namespace PensionGame.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SessionController : Controller
    {
        private readonly IDispatcher _dispatcher;
        //private readonly ICreateSessionCommandHandler _createSessionCommandHandler;

        public SessionController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            //_createSessionCommandHandler = createSessionCommandHandler;
        }

        [HttpPost]
        [ActionName("Default")]
        public async Task<IActionResult> PostDefault()
        {
            var result = await _dispatcher.Dispatch<CreateSessionCommand, SessionId>(new CreateSessionCommand(null)); //await _createSessionCommandHandler.Handle(new CreateSessionCommand(null));

            return Ok(result);
        }

        [HttpPost]
        [ActionName("New")]
        public async Task<IActionResult> PostNew([FromBody] StartupParameters startupParameters)
        {
            var command = new CreateSessionCommand(startupParameters);

            var result = await _dispatcher.Dispatch<CreateSessionCommand, SessionId>(command); //await _createSessionCommandHandler.Handle(command);

            return Ok(result);
        }
    }
}
