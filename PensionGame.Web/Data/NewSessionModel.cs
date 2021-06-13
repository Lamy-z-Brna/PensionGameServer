using PensionGame.Api.Domain.Resources.Session;

namespace PensionGame.Web.Data
{
    public class NewSessionModel
    {
        public StartupParameters StartupParametersModel => new(Income ?? 0, Expenses ?? 0, Age ?? 0, RetirementAge ?? 0, ExistingFunds ?? 0);

        public NewSessionModel(StartupParameters investmentSelection, string name)
        {
            Income = investmentSelection.Income;
            Expenses = investmentSelection.Expenses;
            Age = investmentSelection.Age;
            RetirementAge = investmentSelection.RetirementAge;
            ExistingFunds = investmentSelection.ExistingFunds;
            Name = name;
        }

        public string? Name { get; set; }

        public int? Income { get; set; }

        public int? Expenses { get; set; }

        public int? Age { get; set; }

        public int? RetirementAge { get; set; }

        public int? ExistingFunds { get; set; }
    }
}
