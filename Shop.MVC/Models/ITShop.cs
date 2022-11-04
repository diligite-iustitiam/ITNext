using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebProjectOnAzure.Models
{
    
    public class ITShop 
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        
        [BsonElement("Brand")]
        [Required]
        public string? Brand { get; set; }
        [BsonElement("Model")]
        [Required]
        public string? Model { get; set; }
        [BsonElement("Description")]
        [Required]
        public string? ITProductDescription { get; set; }
        [BsonElement("Price")]
        [Display(Name = "Price($)")]  
        public decimal? ITProductPrice { get; set; }
        [BsonElement("ImageUrl")]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string? ITProductPhoto { get; set; }

        
        
    }
}
