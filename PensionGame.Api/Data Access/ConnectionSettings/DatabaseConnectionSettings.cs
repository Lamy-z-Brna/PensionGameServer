namespace PensionGame.Api.Data_Access.ConnectionSettings
{
    public record DatabaseConnectionSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
    }
}
