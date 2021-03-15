using AutoMapper;
using PensionGame.DataAccess.Data_Objects.Session;

namespace PensionGame.Api.Common.Profiles
{
    public sealed class DataObjectsToResourcesProfile : Profile
    {
        public DataObjectsToResourcesProfile()
        {
            CreateMap<SessionId, Resources.Session.SessionId>();
        }
    }
}
