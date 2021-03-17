namespace PensionGame.Api.Domain.Validation
{
    public record ValidationErrorModel
    {
        public string? Field { get; }

        public string Message { get; }

        public ValidationErrorModel(string message)
        {
            Message = message;
        }

        public ValidationErrorModel(string field, string message)
        {
            Field = !string.IsNullOrWhiteSpace(field) ? field : null;
            Message = message;
        }
    }
}
