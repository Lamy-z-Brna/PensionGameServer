using PensionGame.Api.Resources.ClientData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Mappers
{
    public interface IClientDataMapper : IMapper<ClientData, Core.Domain.ClientData.ClientData>
    {
    }
}
