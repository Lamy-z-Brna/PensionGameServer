using PensionGame.Api.Domain.Resources.Events;
using PensionGame.Core.Events.Common;

namespace PensionGame.Api.Common.Mappers
{
    public interface IEventMapper : IMapper<IEvent, Event>
    {
    }
}
