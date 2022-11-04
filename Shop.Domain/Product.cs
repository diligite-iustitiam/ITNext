

namespace Shop.Domain
{
    
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string? ProductBrand{ get; set; }
        public string? ProductModel { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string? ProductImage { get; set; }
        public virtual Category? Category { get; set; }
        public virtual List<OrderDetail>? OrderDetails { get; set; }
        
    }
}
