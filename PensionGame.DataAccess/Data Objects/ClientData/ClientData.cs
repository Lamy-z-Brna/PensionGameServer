using PensionGame.DataAccess.Data_Objects.GameData;
using PensionGame.DataAccess.Data_Objects.Holdings;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensionGame.DataAccess.Data_Objects.ClientData
{
    public class ClientData
    {
        public int Id { get; set; }
        [ForeignKey("GameState")]
        public int GameStateId { get; set; }
        public IncomeData? IncomeData { get; set; }
        public ExpenseData? ExpenseData { get; set; }
        public ClientHoldings? ClientHoldings { get; set; }
        public GameState? GameState { get; set; }

        public ClientData(IncomeData incomeData, ExpenseData expenseData, ClientHoldings clientHoldings)
        {
            IncomeData = incomeData;
            ExpenseData = expenseData;
            ClientHoldings = clientHoldings;
        }

        public ClientData()
        {
        }
    }
}
