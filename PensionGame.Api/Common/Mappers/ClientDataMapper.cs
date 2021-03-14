using AutoMapper;
using PensionGame.Api.Resources.ClientData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Mappers
{
    public sealed class ClientDataMapper : IClientDataMapper
    {
        private readonly IMapper _mapper;

        public ClientDataMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Core.Domain.ClientData.ClientData Map(ClientData @in)
        {
            return _mapper.Map<Core.Domain.ClientData.ClientData>(@in);
        }
    }
}
