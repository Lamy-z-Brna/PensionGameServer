using PensionGame.DataAccess.Data_Objects.Session;

namespace PensionGame.DataAccess.Data_Objects
{
    public record MacroEconomicData(SessionId SessionId, int Year, bool IsCrisis, double InflationRate, double UnemploymentRate, double InterestRate)
    {
    }
}
