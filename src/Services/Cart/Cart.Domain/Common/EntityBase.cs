using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cart.Domain.Common;

public class EntityBase
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}
