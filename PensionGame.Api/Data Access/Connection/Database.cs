using MongoDB.Bson;
using MongoDB.Driver;
using PensionGame.Api.Data_Access.ConnectionSettings;

namespace PensionGame.Api.Data_Access.Connection
{
    public abstract class Database<T>
    {
        protected IMongoCollection<T> ObjectCollection { get; }

        public Database(DatabaseSettings<T> databaseSettings, DatabaseConnectionSettings databaseConnectionSettings)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
#pragma warning restore CS0618 // Type or member is obsolete
            var client = new MongoClient(databaseConnectionSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            ObjectCollection = database.GetCollection<T>(databaseSettings.CollectionName);
        }
    }
}
