using PensionGame.Api.Domain.Resources.Session;

namespace PensionGame.Web.Data
{
    public class NewSessionModel
    {
        public StartupParameters StartupParametersModel => new(Income, Expenses, Age, RetirementAge);

        public NewSessionModel(StartupParameters investmentSelection, string name)
        {
            Income = investmentSelection.Income;
            Expenses = investmentSelection.Expenses;
            Age = investmentSelection.Age;
            RetirementAge = investmentSelection.RetirementAge;
            Name = name;
        }

        public string Name { get; set; }

        public int Income { get; set; }

        public int Expenses { get; set; }

        public int Age { get; set; }

        public int RetirementAge { get; set; }
    }
}
