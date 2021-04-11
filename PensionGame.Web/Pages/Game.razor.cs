using System;
using System.Threading.Tasks;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq;

namespace PensionGame.Web.Pages
{
    public partial class Game
    {
        [Parameter]
        public string? sessionId { get; set; }

        InvestmentSelectionModel investmentSelection = new InvestmentSelectionModel(new InvestmentSelection());

        GameState? gameData;

        SessionId? currentSessionId;

        int TotalCashFlow => gameData?.ClientData.DisposableIncome + investmentSelection.LoanValue ?? 0;
        int RemainingCashFlow => TotalCashFlow - (investmentSelection.BondValue + investmentSelection.StockValue + investmentSelection.SavingsAccountValue);

        bool? success = null;
        bool validationOkay = true;

        EditContext editContext = new EditContext(new InvestmentSelection());

        private const string StocksInfo = "Stocks are a highly volatile liquid investment that has a high average returns. The price of stock market unit can vary widely from year to year, however you are able to buy and sell down units freely.";
        private const string BondsInfo = "Bonds are a long term investment with above average returns, but low liquidity. Bonds yield coupons of the same amount every year until they expire (10 years). You cannot disinvest bonds and have to wait until they expire.";
        private const string SavingsAccountInfo = "An investment with very small but guaranteed returns. You can add and withdraw your investment at any moment, making it highly liquid. Any remaining disposable income will be automatically invested here.";
        private const string LoansInfo = "A very expensive way to get extra money for investments. Interest will be charged every year until you pay your loans back.";

        protected override async void OnInitialized()
        {
            if (string.IsNullOrEmpty(sessionId))
                return; //TODO vypisat nejaku hlasku

            if (!Guid.TryParse(sessionId, out var sessionGuid))
                return; //TODO vypisat nejaku inu hlasku

            currentSessionId = new SessionId(sessionGuid);

            await LoadPageBySessionId(currentSessionId);
        }

        protected async void editContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            if (currentSessionId != null)
            {
                validationOkay = await GameService.InvestmentSelectionValidate(currentSessionId, investmentSelection);

                StateHasChanged();
            }
        }

        private async Task HandleValidSubmit()
        {
            if (currentSessionId != null)
            {
                success = await GameService.InvestmentSelectionSubmit(currentSessionId, investmentSelection);

                await LoadPageBySessionId(currentSessionId);
            }
        }

        private async Task LoadPageBySessionId(SessionId sessionId)
        {
            gameData = await GameService.GameStateGet(sessionId);

            investmentSelection = new InvestmentSelectionModel(new InvestmentSelection()
            {
                StockValue = gameData.ClientData.ClientHoldings.Stocks.Value,
                BondValue = 0,
                SavingsAccountValue = gameData.ClientData.ClientHoldings.SavingsAccount.Amount,
                LoanValue = gameData.ClientData.ClientHoldings.Loans.Sum(l => l.Amount)
            });

            editContext = new EditContext(investmentSelection);

            editContext.OnFieldChanged += editContext_OnFieldChanged;

            StateHasChanged();
        }
    }
}
