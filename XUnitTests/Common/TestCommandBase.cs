using Shop.Domain;
using Shop.Persistence;

namespace XUnitTests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ShopContext Context;

        public TestCommandBase()
        {
            Context = ShopContextFactory.Create();
        }

        public void Dispose()
        {
            ShopContextFactory.Destroy(Context);
        }
    }
}
