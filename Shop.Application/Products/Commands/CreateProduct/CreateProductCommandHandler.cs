using Shop.Domain;
using MediatR;
using Shop.Application.Interfaces;

namespace Shop.Application.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IShopDbContext _shopDbContext;
        public CreateProductCommandHandler(IShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            
            var product = new Product()
            {
                ProductID = request.ProductID,
                ProductBrand = request.ProductBrand,
                ProductModel = request.ProductModel,
                ProductDescription = request.ProductDescription,
                Price = request.Price,
                ProductImage = request.ProductImage,
                CategoryID = request.CategoryID
            };
            
            await _shopDbContext.Products.AddAsync(product);
            await _shopDbContext.SaveChangesAsync(cancellationToken);
            

            return product.ProductID;
        }
    }
}
