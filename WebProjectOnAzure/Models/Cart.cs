using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;
namespace WebProjectOnAzure.Models
{
    public class Cart
    {
        [Key]
        public int RecordID { get; set; }
        public string? CartID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Product? Product { get; set; }
    }
}
