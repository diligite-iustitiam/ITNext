using MediatR;
namespace Shop.Application.Products.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public int ProductID { get; set; }
       
        public int CategoryID { get; set; }

        public string? ProductBrand { get; set; }
      
        public string? ProductModel { get; set; }
        
        public string? ProductDescription { get; set; }
        
        public decimal Price { get; set; }
       
        public string? ProductImage { get; set; }        

    }
}
