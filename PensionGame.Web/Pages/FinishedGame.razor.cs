using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Api.Domain.Resources.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Web.Pages
{
    public partial class FinishedGame
    {
        private const string PensionYearsCoveredTooltip = "The value shows how many years you could spend your pension before running out of money. Aim for the value to be more than 25 - 30 years.";
        private const string AverageYearlyReturnRateTooltip = "The value calculates the average yearly return of your portfolio. Values above inflation rate mean your portfolio has grown.";
        private const string AverageInflationRateTooltip = "The average inflation rate over the whole game play";

        [Parameter]
        public string? SessionId { get; set; }

        public SessionId? CurrentSessionId { get; set; }

        private string? SessionName { get; set; }

        private Dictionary<int, GameState>? GameHistory { get; set; }

        private PortfolioReturnRate? PortfolioReturnRate { get; set; }

        private PortfolioValue? PortfolioValue { get; set; }

        private AverageInflationRate? AverageInflationRate { get; set; }

        private GameState? GameData => GameHistory?
            .OrderByDescending(kv => kv.Key)
            .Select(kv => kv.Value)
            .FirstOrDefault();

        private Dictionary<int, ClientHoldings>? ClientHoldingsHistory => GameHistory?
            .Where(kv => !kv.Value.IsInitial)
            .Select(kv => new { kv.Key, kv.Value.ClientData.ClientHoldings })
            .ToDictionary(data => data.Key, data => data.ClientHoldings);

        protected override async void OnInitialized()
        {
            if (string.IsNullOrEmpty(SessionId) || !Guid.TryParse(SessionId, out var sessionGuid))
            {
                NavigationManager.NavigateTo($"/error");
                return;
            }

            CurrentSessionId = new SessionId(sessionGuid);

            SessionName = (await SessionService.GetSession(sessionGuid))?.Name;

            await LoadPageBySessionId(CurrentSessionId);

            StateHasChanged();
        }

        private async Task LoadPageBySessionId(SessionId sessionId)
        {
            GameHistory = await GameService.GetAll(sessionId);

            PortfolioReturnRate = await GameService.GetPortfolioReturnRate(sessionId);

            PortfolioValue = await GameService.GetPortfolioValue(sessionId);

            AverageInflationRate = await GameService.GetInflationRate(sessionId);

            if (GameData == null)
            {
                NavigationManager.NavigateTo($"/error");
                return;
            }

            if (!GameData.IsFinished)
                NavigationManager.NavigateTo($"/game/{sessionId.Id}");
        }

        private void RedirectToNewSession()
        {
            NavigationManager.NavigateTo($"/newsession/");
        }
    }
}
