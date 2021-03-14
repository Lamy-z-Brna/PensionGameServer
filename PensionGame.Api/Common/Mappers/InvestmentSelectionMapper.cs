using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Mappers
{
    public sealed class InvestmentSelectionMapper : IInvestmentSelectionMapper
    {
        private readonly IMapper _mapper;

        public InvestmentSelectionMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Core.Domain.ClientData.InvestmentSelection Map(Resources.ClientData.InvestmentSelection @in)
        {
            return _mapper.Map<Core.Domain.ClientData.InvestmentSelection>(@in);
        }
    }
}
