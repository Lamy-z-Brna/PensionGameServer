using System;

namespace PensionGame.Web.Data.Entities
{
    public record SessionId
    {
        public Guid Id { get; init; }
    }
}