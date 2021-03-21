using PensionGame.Api.Domain.Resources.Session;

namespace PensionGame.Web.Data
{
    public class StartupParametersModel
    {
        public StartupParametersModel(StartupParameters investmentSelection)
        {
            Income = investmentSelection.Income;
            Expenses = investmentSelection.Expenses;
            Year = investmentSelection.Year;
            RetirementYear = investmentSelection.RetirementYear;
        }

        public static implicit operator StartupParameters(StartupParametersModel model)
        {
            return new(model.Income, model.Expenses, model.Year, model.RetirementYear);
        }

        public int Income { get; set; }

        public int Expenses { get; set; }

        public int Year { get; set; }

        public int RetirementYear { get; set; }
    }
}
