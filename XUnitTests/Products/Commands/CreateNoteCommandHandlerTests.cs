
using Microsoft.EntityFrameworkCore;
using XUnitTests.Common;
using Shop.Application.Products.CreateProduct;

namespace XUnitTests.Products.Commands
{
    public class CreateProductCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateProductCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateProductCommandHandler(Context);
            var productBrand = "Lenovo";
            var productModel = "A391";

            // Act
            var productId = await handler.Handle(
                new CreateProductCommand
                {
                    ProductID = 39,
                    CategoryID = 1,
                    ProductBrand = "Lenovo",
                    ProductModel = "A391",
                    Price = 231,
                    ProductDescription = "Expenisve",                  
                    ProductImage = "Nice to have"
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Products.SingleOrDefaultAsync(product =>
                    product.ProductID == productId && product.ProductBrand == productBrand &&
                    product.ProductModel == productModel));
        }
    }
}
