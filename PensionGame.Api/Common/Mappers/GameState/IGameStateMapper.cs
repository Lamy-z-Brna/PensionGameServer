namespace PensionGame.Api.Common.Mappers.GameState
{
    public interface IGameStateMapper : 
        IMapper<Core.Domain.GameData.GameState, Domain.Resources.GameData.GameState>, 
        IMapper<Domain.Resources.GameData.GameState, Core.Domain.GameData.GameState>
    {
    }
}
