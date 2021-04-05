using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PensionGame.Api.Data_Access.Data_Objects
{
    public sealed class GameState
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public Guid? Guid { get; set; }

        public Domain.Resources.GameData.GameState? Game { get; init; }
    }
}
