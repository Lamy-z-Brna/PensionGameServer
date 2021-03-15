using PensionGame.Api.Resources.ClientData;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Readers.ClientData
{
    public interface IInvestmentSelectionReader : IReader
    {
        Task<InvestmentSelection> Get(int clientDataId);
    }
}
