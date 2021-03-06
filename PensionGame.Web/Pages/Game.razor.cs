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
        [Parameter]
        public string? SessionId { get; set; }

        private InvestmentSelectionModel InvestmentSelection { get; set; } = new(new());

        private GameState? GameData => GameHistory?
            .OrderByDescending(kv => kv.Key)
            .Select(kv => kv.Value)
            .FirstOrDefault();

        private Dictionary<int, GameState>? GameHistory { get; set; }

        private SessionId? CurrentSessionId { get; set; }

        private string? SessionName { get; set; }

        private ValidationResultModel? ValidationResult { get; set; }

        private bool IsValid => GameData != null && ValidationResult == null;

        private EditContext EditContext { get; set; } = new(new InvestmentSelection());

        private int DisposableIncome => GameData?.ClientData.DisposableIncome ?? 0;

        private int AvailableToInvest { get; set; }

        private ClientHoldings? ClientHoldings => GameData?.ClientData.ClientHoldings;

        private Modal? ModalWindow;

        private List<Action> ActionsAfterRender { get; set; } = new List<Action> { };

        private int CurrentStockValue => GameData?.ClientData.ClientHoldings.Stocks.Value ?? 0;

        private int CurrentSavingsAccountValue => GameData?.ClientData.ClientHoldings.SavingsAccount.Amount ?? 0;

        private int CurrentLoanValue => GameData?.ClientData.ClientHoldings.Loans.TotalLoanValue ?? 0;

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

            SessionName = (await SessionService.GetSession(sessionGuid))?.Name;
            
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
            }
        }

        private async Task HandleValidSubmit()
        {
            if (CurrentSessionId != null)
            {
                var currentGameSession = await GameService.Get(CurrentSessionId);

                if (currentGameSession?.Year > GameData?.Year)
                    await LoadPageBySessionId(CurrentSessionId);
                else
                {
                    //TODO what if this fails? 
                    await GameService.InvestmentSelectionSubmit(CurrentSessionId, InvestmentSelection);

                    await LoadPageBySessionId(CurrentSessionId);
                }
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
                StockValue: CurrentStockValue,
                BondValue: 0,
                SavingsAccountValue: CurrentSavingsAccountValue,
                LoanValue: CurrentLoanValue
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

        private async Task StockSelectionChanged(int? newValue)
        {
            InvestmentSelection.StockValue = newValue ?? CurrentStockValue;

            await ValidateInvestmentSelection();
        }

        private async Task BondSelectionChanged(int? newValue)
        {
            InvestmentSelection.BondValue = newValue ?? 0;

            await ValidateInvestmentSelection();
        }

        private async Task SavingsAccountSelectionChanged(int? newValue)
        {
            InvestmentSelection.SavingsAccountValue = newValue ?? CurrentSavingsAccountValue;

            await ValidateInvestmentSelection();
        }

        private async Task LoanSelectionChanged(int? newValue)
        {
            InvestmentSelection.LoanValue = newValue ?? CurrentLoanValue;

            await ValidateInvestmentSelection();
        }
    }
}
