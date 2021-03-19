using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.MarketData
{
    public sealed class MarketDataReader : IMarketDataReader
    {
        private readonly IMacroEconomicDataReader _macroEconomicDataReader;
        private readonly IReturnDataReader _returnDataReader;

        public MarketDataReader(IMacroEconomicDataReader macroEconomicDataReader, 
            IReturnDataReader returnDataReader)
        {
            _macroEconomicDataReader = macroEconomicDataReader;
            _returnDataReader = returnDataReader;
        }        

        public async Task<Domain.Resources.MarketData.MarketData> GetCurrent(SessionId sessionId)
        {
            var macroEconomicData = await _macroEconomicDataReader.GetCurrent(sessionId);
            var returnData = await _returnDataReader.GetCurrent(sessionId);

            return new Domain.Resources.MarketData.MarketData
                (
                    macroEconomicData,
                    returnData
                );
        }
    }
}
