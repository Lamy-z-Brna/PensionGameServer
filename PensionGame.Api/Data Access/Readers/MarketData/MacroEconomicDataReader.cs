using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.MarketData
{
    public sealed class MacroEconomicDataReader : IMacroEconomicDataReader
    {
        public async Task<MacroEconomicData> GetCurrent(SessionId sessionId)
        {
            return new MacroEconomicData
                (
                    IsCrisis: false,
                    InflationRate: 0.032,
                    UnemploymentRate: 0.065,
                    InterestRate: 0.02
                );
        }
    }
}
