using AutoMapper;
using Shop.Application.Products.Queries.GetProductList;
using Shop.Persistence;
using XUnitTests.Common;
using Shouldly;
using Xunit;
namespace XUnitTests.Products.Queries
{
    [Collection("QueryCollection")]
    public class GetProductListQueryHandlerTests
    {
        private readonly ShopContext Context;
        private readonly IMapper Mapper;

        public GetProductListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetProductListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetProductListQueryHandler(Mapper, Context);

            // Act
            var result = await handler.Handle(
                new GetProductListQuery
                {
                   
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ProductListVm>();
            result.Products.Count.ShouldBe(4);
        }
    }
}
