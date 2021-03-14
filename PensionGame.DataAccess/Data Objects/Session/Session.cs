using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensionGame.DataAccess.Data_Objects.Session
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime DateStarted { get; set; }
    }
}
