﻿namespace PensionGame.Api.Domain.Resources.Events
{
    public record Event(string DisplayMessage, EventType EventType = EventType.Info)
    {
    }
}
