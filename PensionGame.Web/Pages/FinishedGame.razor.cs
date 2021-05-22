using Microsoft.AspNetCore.Components;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Web.Pages
{
    public partial class FinishedGame
    {
        [Parameter]
        public string? SessionId { get; set; }

        public SessionId? CurrentSessionId { get; set; }

        private Dictionary<int, GameState>? GameHistory { get; set; }

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

            await LoadPageBySessionId(CurrentSessionId);

            StateHasChanged();
        }

        private async Task LoadPageBySessionId(SessionId sessionId)
        {
            GameHistory = await GameService.GetAll(sessionId);

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
