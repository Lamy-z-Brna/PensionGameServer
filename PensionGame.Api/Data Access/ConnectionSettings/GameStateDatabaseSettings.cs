using PensionGame.Api.Data_Access.Data_Objects;

namespace PensionGame.Api.Data_Access.ConnectionSettings
{
    public sealed record GameStateDatabaseSettings : DatabaseSettings<GameState>
    {
    }
}
