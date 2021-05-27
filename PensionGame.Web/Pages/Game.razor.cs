using System;
using System.Threading.Tasks;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Validation;
using Blazorise;
using System.Collections.Generic;

namespace PensionGame.Web.Pages
{
    public partial class Game
    {
        private const string StocksInfo = "Stocks are a highly volatile liquid investment that has a high average returns. The price of stock market unit can vary widely from year to year, however you are able to buy and sell down units freely.";
        private const string BondsInfo = "Bonds are a long term investment with above average returns, but low liquidity. Bonds yield coupons of the same amount every year until they expire (10 years). You cannot disinvest bonds and have to wait until they expire.";
        private const string SavingsAccountInfo = "An investment with very small but guaranteed returns. You can add and withdraw your investment at any moment, making it highly liquid. Any remaining disposable income will be automatically invested here.";
        private const string LoansInfo = "A very expensive way to get extra money for investments. Interest will be charged every year until you pay your loans back.";

        [Parameter]
        public string? SessionId { get; set; }

        private InvestmentSelectionModel InvestmentSelection { get; set; } = new(new());

        private GameState? GameData => GameHistory?
            .OrderByDescending(kv => kv.Key)
            .Select(kv => kv.Value)
            .FirstOrDefault();

        private Dictionary<int, GameState>? GameHistory { get; set; }

        private Dictionary<int, ClientHoldings>? ClientHoldingsHistory => GameHistory?
            .Where(kv => !kv.Value.IsInitial)
            .Select(kv => new { kv.Key, kv.Value.ClientData.ClientHoldings })
            .ToDictionary(data => data.Key, data => data.ClientHoldings);

        private SessionId? CurrentSessionId { get; set; }

        private ValidationResultModel? ValidationResult { get; set; }

        private bool IsValid => ValidationResult == null;

        private EditContext EditContext { get; set; } = new(new InvestmentSelection());

        private int DisposableIncome => GameData?.ClientData.DisposableIncome ?? 0;

        private int AvailableToInvest { get; set; }

        private ClientHoldings? ClientHoldings => GameData?.ClientData.ClientHoldings;

        private Modal? ModalWindow;

        private List<Action> ActionsAfterRender { get; set; } = new List<Action> { };

        private void ShowModal()
        {
            ModalWindow?.Show();
        }

        private void HideModal()
        {
            ModalWindow?.Hide();
        }

        protected override async void OnInitialized()
        {
            if (string.IsNullOrEmpty(SessionId) || !Guid.TryParse(SessionId, out var sessionGuid))
            {
                NavigationManager.NavigateTo($"/error");
                return;
            }

            CurrentSessionId = new SessionId(sessionGuid);

            await LoadPageBySessionId(CurrentSessionId);
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            ActionsAfterRender.ForEach(action => action());
            ActionsAfterRender.Clear();

            return Task.CompletedTask;
        }

        protected async void EditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            await ValidateInvestmentSelection();
        }

        private async Task ValidateInvestmentSelection()
        {
            if (CurrentSessionId != null)
            {
                await UpdateRemainingCashFlow(CurrentSessionId, InvestmentSelection);

                ValidationResult = await GameService.InvestmentSelectionValidate(CurrentSessionId, InvestmentSelection);

                //StateHasChanged();
            }
        }

        private async Task HandleValidSubmit()
        {
            if (CurrentSessionId != null)
            {
                //TODO what if this fails? 
                await GameService.InvestmentSelectionSubmit(CurrentSessionId, InvestmentSelection);

                await LoadPageBySessionId(CurrentSessionId);
            }
        }

        private async Task LoadPageBySessionId(SessionId sessionId)
        {
            GameHistory = await GameService.GetAll(sessionId);

            if (GameData == null)
            {
                NavigationManager.NavigateTo($"/error");
                return;
            }

            if (GameData.IsFinished)
                NavigationManager.NavigateTo($"/finishedgame/{sessionId.Id}");

            InvestmentSelection = new(new(
                StockValue: GameData.ClientData.ClientHoldings.Stocks.Value,
                BondValue: 0,
                SavingsAccountValue: GameData.ClientData.ClientHoldings.SavingsAccount.Amount,
                LoanValue: GameData.ClientData.ClientHoldings.Loans.Sum(l => l.Amount)
            ));

            await ValidateInvestmentSelection();

            EditContext = new EditContext(InvestmentSelection);

            EditContext.OnFieldChanged += EditContext_OnFieldChanged;

            ActionsAfterRender.Add(ShowModal);

            StateHasChanged();
        }

        private async Task UpdateRemainingCashFlow(SessionId sessionId, InvestmentSelection investmentSelection)
        {
            var availableToInvest = await GameService.GetAvailableToInvest(sessionId, investmentSelection);

            AvailableToInvest = availableToInvest?.Amount ?? 0;
        }

        private async Task StockSelectionChanged(int newValue)
        {
            InvestmentSelection.StockValue = newValue;

            await ValidateInvestmentSelection();
        }
    }
}
