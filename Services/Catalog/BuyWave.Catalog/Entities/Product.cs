using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BuyWave.Catalog.Entities;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string ProductImageUrl { get; set; }
    public string ProductDescription { get; set; }
    public string CategoryID { get; set; }
    [BsonIgnore]
    public Category Category { get; set; }
}
