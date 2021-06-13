using Microsoft.AspNetCore.Components.Forms;
using PensionGame.Api.Domain.Validation;
using PensionGame.Web.Data;
using PensionGame.Web.Helpers;
using System.Threading.Tasks;

namespace PensionGame.Web.Pages
{
    public partial class NewSession
    {
        private NewSessionModel Session { get; } = new(new (500_000, 400_000, 25, 65, 100_000), FunNamesGenerator.Generate());

        private EditContext EditContext { get; set; } = new(new object());

        private ValidationResultModel? ValidationResult { get; set; }

        private bool IsValid => ValidationResult == null;

        protected override async void OnInitialized()
        {
            EditContext = await Task.FromResult(new EditContext(Session));

            EditContext.OnFieldChanged += EditContext_OnFieldChanged;
        }

        private async Task HandleValidSubmit()
        {
            var creationResult = await SessionService.CreateSession(Session.StartupParametersModel, Session?.Name ?? string.Empty);

            creationResult.Do(
                    sessionId => NavigationManager.NavigateTo($"/game/{sessionId.Id}"),
                    validationResult => ValidationResult = validationResult
                );
        }

        protected async void EditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            ValidationResult = await SessionService.ValidateSession(Session.StartupParametersModel, Session?.Name ?? string.Empty);

            StateHasChanged();
        }
    }
}