using AutoMapper;
using Shop.Application.Products.Queries.GetProductDetails;
using Shop.Persistence;
using Shouldly;
using XUnitTests.Common;

namespace XUnitTests.Products.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteDetailsQueryHandlerTests
    {
        private readonly ShopContext Context;
        private readonly IMapper Mapper;

        public GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetProductDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetProductDetailsQueryHandler(Mapper, Context);

            // Act
            var result = await handler.Handle(
                new GetProductDetailsQuery
                {
                    ProductID = 33
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ProductDetailsVm>();
            result.ProductBrand.ShouldBe("Moto");
            result.Price.ShouldBe(1);
        }
    }
}
