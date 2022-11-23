using AutoMapper;
using System;
using Shop.Application.Interfaces;
using Shop.Application.Common.Mappings;
using Shop.Persistence;
using Xunit;
namespace XUnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public ShopContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = ShopContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IShopDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            ShopContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
