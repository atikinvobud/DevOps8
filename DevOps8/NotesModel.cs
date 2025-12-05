using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend;

public class Notes
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public  string Id { get; set; } =null!;

    [BsonElement("title")]
    public required string Title { get; set; }
    
    [BsonElement("body")]
    public required string Body {get; set;}    
}