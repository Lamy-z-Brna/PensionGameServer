using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.DataAccess.Data_Objects.ClientData
{
    public record IncomeData
    {
        public int Salary { get; init; }

        public int BondInterest { get; init; }

        public int SavingsAccountInterest { get; init; }

        public int ExtraIncome { get; init; }
    }
}
