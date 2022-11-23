using System.Threading.Tasks;
using Shop.Application.Common.Exceptions;
using Shop.Application.Products.Commands.DeleteProduct;
using Shop.Application.Products.Commands.CreateProduct;
using XUnitTests.Common;
using Xunit;

namespace XUnitTests.Products.Commands
{
    public class DeleteNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteProductCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteProductCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteProductCommand
            {
                ProductID = ShopContextFactory.ProductIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Products.SingleOrDefault(product =>
                product.ProductID == ShopContextFactory.ProductIdForDelete));
        }

        [Fact]
        public async Task DeleteProductCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteProductCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteProductCommand
                    {
                        ProductID = 30,
                    },
                    CancellationToken.None));
        }

        
    }
}
