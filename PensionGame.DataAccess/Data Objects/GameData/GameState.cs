namespace PensionGame.DataAccess.Data_Objects.GameData
{
    public class GameState
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int Year { get; set; }
        public bool IsFinished { get; set; }
    }
}
