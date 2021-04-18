using MongoDB.Bson;
using MongoDB.Driver;
using PensionGame.Api.Data_Access.ConnectionSettings;

namespace PensionGame.Api.Data_Access.Connection
{
    public abstract class Database<T>
    {
        protected IMongoCollection<T> ObjectCollection { get; }

        public Database(DatabaseConnectionSettings<T> databaseConnectionSettings)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
#pragma warning restore CS0618 // Type or member is obsolete
            var client = new MongoClient(databaseConnectionSettings.ConnectionString);
            var database = client.GetDatabase(databaseConnectionSettings.DatabaseName);

            ObjectCollection = database.GetCollection<T>(databaseConnectionSettings.CollectionName);
        }
    }
}
