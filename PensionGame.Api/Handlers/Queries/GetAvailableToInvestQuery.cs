using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Domain.Resources.Session;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetAvailableToInvestQuery(ClientData ClientData, InvestmentSelection InvestmentSelection) : IQuery<AvailableToInvest>
    {
    }

    public record GetAvailableToInvestFromSessionQuery(SessionId SessionId, InvestmentSelection InvestmentSelection) : IQuery<AvailableToInvest?>
    {
    }
}
