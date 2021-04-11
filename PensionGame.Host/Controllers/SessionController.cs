using Microsoft.AspNetCore.Mvc;
using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Api.Handlers.Queries;
using System.Threading.Tasks;

namespace PensionGame.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SessionController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public SessionController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        [ActionName("Default")]
        public async Task<IActionResult> PostDefault(string? name)
        {
            var result = await _dispatcher.Dispatch<CreateSessionCommand, SessionId>(new CreateSessionCommand(name ?? string.Empty, null));

            return Ok(result);
        }

        [HttpPost]
        [ActionName("New")]
        public async Task<IActionResult> PostNew(string? name, [FromBody] StartupParameters startupParameters)
        {
            var command = new CreateSessionCommand(name ?? string.Empty, startupParameters);

            var result = await _dispatcher.Dispatch<CreateSessionCommand, SessionId>(command);

            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetAll")]
        public async Task<PaginationResult<Session>> GetAll(int page, int pageSize)
        {
            var query = new GetSessionsQuery(page, pageSize);

            var result = await _dispatcher.Query<GetSessionsQuery, PaginationResult<Session>>(query);

            return result;
        }
    }
}
