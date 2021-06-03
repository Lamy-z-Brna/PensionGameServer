namespace PensionGame.Api.Data_Access.ConnectionSettings
{
    public abstract record DatabaseSettings<T>
    {
        public string DatabaseName { get; set; } = string.Empty;

        public string CollectionName { get; set; } = string.Empty;
    }
}
