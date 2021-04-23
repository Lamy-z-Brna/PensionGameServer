using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Handlers.Queries;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public interface IGetSessionQueryHandler : IQueryHandler<GetSessionQuery, Session?>
    {
    }
}
