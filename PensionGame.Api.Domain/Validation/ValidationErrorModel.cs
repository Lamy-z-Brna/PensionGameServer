namespace PensionGame.Api.Domain.Validation
{
    public record ValidationErrorModel(string Message, string? Field = null)
    {
    }
}
