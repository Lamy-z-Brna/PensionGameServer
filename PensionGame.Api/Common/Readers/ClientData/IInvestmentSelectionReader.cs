using PensionGame.Api.Resources.ClientData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Readers.ClientData
{
    public interface IInvestmentSelectionReader : IReader
    {
        Task<InvestmentSelection> Get(int clientDataId);
    }
}
