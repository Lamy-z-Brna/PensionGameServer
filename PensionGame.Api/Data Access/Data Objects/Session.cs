using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PensionGame.Api.Data_Access.Data_Objects
{
    public sealed class Session
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public Domain.Resources.Session.Session? Object { get; init; }
    }
}
