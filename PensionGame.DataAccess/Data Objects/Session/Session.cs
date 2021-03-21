using PensionGame.DataAccess.Data_Objects.GameData;
using System;
using System.Collections.Generic;

namespace PensionGame.DataAccess.Data_Objects.Session
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime DateStarted { get; set; }
        public IEnumerable<GameState>? GameStates { get; set; }
    }
}
