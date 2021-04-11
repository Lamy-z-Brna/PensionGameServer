﻿using System;
using System.Threading.Tasks;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

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

        private EditContext editContext = new EditContext(new InvestmentSelection());

        protected override async void OnInitialized()
        {
            editContext = new EditContext(investmentSelection);

            if (string.IsNullOrEmpty(sessionId))
                return; //TODO vypisat nejaku hlasku

            if (!Guid.TryParse(sessionId, out var sessionGuid))
                return; //TODO vypisat nejaku inu hlasku

            currentSessionId = new SessionId(sessionGuid);

            gameData = await GameService.GameStateGet(currentSessionId);

            editContext.OnFieldChanged += editContext_OnFieldChanged;

            StateHasChanged();
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

                gameData = await GameService.GameStateGet(currentSessionId);
            }
        }
    }
}