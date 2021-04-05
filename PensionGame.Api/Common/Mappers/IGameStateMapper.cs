using PensionGame.Api.Domain.Resources.GameData;

namespace PensionGame.Api.Common.Mappers
{
    public interface IGameStateMapper : IMapper<Core.Domain.GameData.GameState, GameState>, IMapper<GameState, Core.Domain.GameData.GameState>
    {
    }
}
