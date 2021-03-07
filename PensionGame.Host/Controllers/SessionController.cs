using Microsoft.AspNetCore.Mvc;
using PensionGame.Api.Domain.Session;
using PensionGame.Api.Handlers.CommandHandlers;
using PensionGame.Api.Handlers.Commands;
using System.Threading.Tasks;

namespace PensionGame.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SessionController : Controller
    {
        private readonly ICreateSessionCommandHandler _createSessionCommandHandler;

        public SessionController(ICreateSessionCommandHandler createSessionCommandHandler)
        {
            _createSessionCommandHandler = createSessionCommandHandler;
        }

        [HttpPost]
        [ActionName("Default")]
        public async Task<IActionResult> PostDefault()
        {
            var result = await _createSessionCommandHandler.Handle(new CreateSessionCommand(null));

            return Ok(result);
        }

        [HttpPost]
        [ActionName("New")]
        public async Task<IActionResult> PostNew([FromBody] StartupParameters startupParameters)
        {
            var result = await _createSessionCommandHandler.Handle(new CreateSessionCommand(startupParameters));

            return Ok(result);
        }
    }
}
