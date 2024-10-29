using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BuyWave.Catalog.Entities;

public class ProductDetail
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProductDetailID { get; set; }
    public string ProductDescription { get; set; }
    public string ProductInfo { get; set; }
    public string ProductId { get; set; }
    [BsonIgnore]
    public Product Product { get; set; }

}
