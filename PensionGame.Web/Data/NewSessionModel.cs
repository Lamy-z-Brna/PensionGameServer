using PensionGame.Api.Domain.Resources.Session;

namespace PensionGame.Web.Data
{
    public class NewSessionModel
    {
        public StartupParameters StartupParametersModel => new StartupParameters(Income, Expenses, Year, RetirementYear);

        public NewSessionModel(StartupParameters investmentSelection, string name)
        {
            Income = investmentSelection.Income;
            Expenses = investmentSelection.Expenses;
            Year = investmentSelection.Year;
            RetirementYear = investmentSelection.RetirementYear;
            Name = name;
        }

        public string Name { get; set; }

        public int Income { get; set; }

        public int Expenses { get; set; }

        public int Year { get; set; }

        public int RetirementYear { get; set; }
    }
}
