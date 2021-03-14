using AutoMapper;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Queries;

namespace PensionGame.Api.Common.Profiles
{
    public sealed class CommandAndQueryProfile : Profile
    {
        public CommandAndQueryProfile()
        {
            CreateMap<CreateNextStepCommand, CheckInvestmentSelectionCommand>();

            CreateMap<CreateNextStepCommand, GetGameStateQuery>()
                .ForMember(destination => destination.SessionId, src => src.MapFrom(obj => obj.SessionId.Id));
        }
    }
}
