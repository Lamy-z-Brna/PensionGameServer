using AutoMapper;
using PensionGame.DataAccess.Data_Objects.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
