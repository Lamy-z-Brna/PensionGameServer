using System;

namespace PensionGame.Web.Data.Entities
{
    public class Session
    {
        public int Income { get; set; }

        public int Expenses { get; set; }

        public int Year { get; set; }

        public int RetirementYear { get; set; }
    }
}
