using PensionGame.Api.Domain.Resources.Events;

namespace PensionGame.Api.Common.Mappers.Events
{
    public interface IEventMapper : IMapper<Core.Events.Common.Event, Event>
    {
    }
}
