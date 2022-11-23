using System.Threading.Tasks;
using Shop.Application.Common.Exceptions;
using Shop.Application.Products.Commands.UpdateProduct;
using Microsoft.EntityFrameworkCore;
using XUnitTests.Common;
using Xunit;

namespace XUnitTests.Products.Commands
{
    public class UpdateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateProductCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateProductCommandHandler(Context);
            var updatedBrand = "new Brand";

            // Act
            await handler.Handle(new UpdateProductCommand
            {
                ProductID = ShopContextFactory.ProductIdForUpdate,
                ProductBrand = updatedBrand
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Products.SingleOrDefaultAsync(product =>
                product.ProductID == ShopContextFactory.ProductIdForUpdate &&
                product.ProductBrand == updatedBrand));
        }

        [Fact]
        public async Task UpdateProductCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateProductCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateProductCommand
                    {
                        ProductID = 30
                    },
                    CancellationToken.None));
        }

        
    }
}
