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

        public GameState(int sessionId, int year, bool isFinished, ClientData.ClientData clientData)
        {
            SessionId = sessionId;
            Year = year;
            IsFinished = isFinished;
            ClientData = clientData;

        }

        public GameState(int year, bool isFinished, ClientData.ClientData clientData)
        {
            Year = year;
            IsFinished = isFinished;
            ClientData = clientData;

        }

        public GameState()
        {

        }
    }
}
