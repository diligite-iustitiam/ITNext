using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiOnAzure.Models
{
    public class ITShop
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string ITProductID { get; set; } = ObjectId.GenerateNewId().ToString();
        
        [BsonElement("Brand")]
        [JsonPropertyName("Brand")]
        [Required]
        public string? Brand { get; set; }
        [BsonElement("Model")]
        [JsonPropertyName("Model")]
        [Required]
        public string? Model { get; set; }
        [BsonElement("Description")]
        [JsonPropertyName("Description")]
        [Required]
        public string? ITProductDescription { get; set; }
        [BsonElement("Price")]
        [JsonPropertyName("Price")]
        [Display(Name = "Price($)")]  
        public decimal? ITProductPrice { get; set; }
        [BsonElement("ImageUrl")]
        [JsonPropertyName("Photo")]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string? ITProductPhoto { get; set; }

    }
}
