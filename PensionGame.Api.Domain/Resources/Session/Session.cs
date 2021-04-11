using System;

namespace PensionGame.Api.Domain.Resources.Session
{
    public record Session(SessionId SessionId, DateTime DateStarted, string? Name, StartupParameters? StartupParameters)
    {
    }
}
