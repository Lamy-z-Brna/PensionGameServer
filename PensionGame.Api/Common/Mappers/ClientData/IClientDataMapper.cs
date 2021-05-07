namespace PensionGame.Api.Common.Mappers.ClientData
{
    public interface IClientDataMapper : IMapper<Core.Domain.ClientData.ClientData, Domain.Resources.ClientData.ClientData>, IMapper<Domain.Resources.ClientData.ClientData, Core.Domain.ClientData.ClientData>
    {
    }
}
