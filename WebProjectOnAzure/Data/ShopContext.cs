using WebProjectOnAzure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace WebProjectOnAzure.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext()
        {

        }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
           
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-5315223\\SQLEXPRESS;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
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
