namespace PensionGame.Api.Data_Access.ConnectionSettings
{
    public record GameStateConnectionSettings
    {
        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;

        public string CollectionName { get; set; } = string.Empty;
    }
}
