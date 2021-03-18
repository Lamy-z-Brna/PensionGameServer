using System.ComponentModel.DataAnnotations.Schema;

namespace PensionGame.DataAccess.Data_Objects.GameData
{
    public class GameState
    {
        public int Id { get; set; }
        [ForeignKey("Session")]
        public int SessionId { get; set; }
        public int Year { get; set; }
        public bool IsFinished { get; set; }
        public ClientData.ClientData? ClientData { get; set; }
        public Session.Session? Session { get; set; }
    }
}
