using Shop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Application.Interfaces;

namespace Shop.Persistence
{
    public class ShopContext : DbContext, IShopDbContext
    {
       
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
           
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<decimal, double>(
    v => (double)v,
    v => (decimal)v);
            modelBuilder
    .Entity<Product>()
    .Property(e => e.Price)
    .HasConversion(converter);
            modelBuilder
    .Entity<OrderDetail>()
    .Property(e => e.UnitPrice)
    .HasConversion(converter);
            modelBuilder
    .Entity<Order>()
    .Property(e => e.Total)
    .HasConversion(converter);

            modelBuilder.Entity<Product>()
       .HasOne<Category>(e => e.Category)
       .WithMany(g => g.Product)
       .HasForeignKey(s => s.CategoryID);
            

        }
    }
}
