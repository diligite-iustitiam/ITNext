using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProjectOnAzure.Models
{
    
    public class Product
    {
        [BindNever]
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }

        [DisplayName("Category")]
        public int CategoryID { get; set; }

        

        [Required(ErrorMessage = "A Product Brand is required")]
        [StringLength(160)]
        public string? ProductBrand{ get; set; }
        [Required(ErrorMessage = "A Product Model is required")]
        [StringLength(160)]
        public string? ProductModel { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100000.00,
            ErrorMessage = "Price must be between 0.01 and 100000.00")]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string? ProductImage { get; set; }

        public virtual Category? Category { get; set; }
        
        public virtual List<OrderDetail>? OrderDetails { get; set; }
    }
}
