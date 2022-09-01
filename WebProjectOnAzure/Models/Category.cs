using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebProjectOnAzure.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        [DataType(DataType.ImageUrl)]
        public string? CategoryPhoto { get; set; }
        public List<Product>? Product { get; set; }
    }
}
