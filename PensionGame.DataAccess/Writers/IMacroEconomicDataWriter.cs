using PensionGame.DataAccess.Data_Objects;
using System.Threading.Tasks;

namespace PensionGame.DataAccess.Writers
{
    public interface IMacroEconomicDataWriter : IWriter
    {
        Task Create(MacroEconomicData macroEconomicData);
    }
}
