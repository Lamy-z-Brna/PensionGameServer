using MongoDB.Driver;
using PensionGame.Api.Data_Access.ConnectionSettings;

namespace PensionGame.Api.Data_Access.Connection
{
    public abstract class Database<T>
    {
        protected IMongoCollection<T> ObjectCollection { get; }

        public Database(DatabaseConnectionSettings<T> databaseConnectionSettings)
        {
            var client = new MongoClient(databaseConnectionSettings.ConnectionString);
            var database = client.GetDatabase(databaseConnectionSettings.DatabaseName);

            ObjectCollection = database.GetCollection<T>(databaseConnectionSettings.CollectionName);
        }
    }
}
