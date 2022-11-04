using Shop.Domain;
using Microsoft.EntityFrameworkCore;
namespace Shop.Application.Interfaces
{
    public interface IShopDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
