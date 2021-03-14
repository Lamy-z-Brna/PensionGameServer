using AutoMapper;
using PensionGame.Api.Handlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Profiles
{
    public sealed class CommandAndQueryProfile : Profile
    {
        public CommandAndQueryProfile()
        {
            CreateMap<CreateNextStepCommand, CheckInvestmentSelectionCommand>();
        }
    }
}
