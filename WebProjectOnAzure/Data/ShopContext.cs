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
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderDetail>? OrderDetails { get; set; }
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
            
            //modelBuilder.Entity<Product>().Property(i => i.ProductPrice).HasColumnType("decimal(18,4)"); ;
            //modelBuilder.Entity<Order>().Property(i => i.Total).HasColumnType("decimal(18,4)");
            //modelBuilder.Entity<OrderDetail>().Property(i => i.UnitPrice).HasColumnType("decimal(18,4)");

            //modelBuilder.Entity<Cart>().HasOne<Product>(e => e.Product).WithMany(g => g.Cart).HasForeignKey(s => s.ID);
            //modelBuilder.Entity<OrderDetail>()
            //    .HasKey(c => new { c.ID, c.OrderId });

       //     modelBuilder.Entity<Product>()
       //.HasOne<Category>(e => e.Category)
       //.WithMany(g => g.Product)
       //.HasForeignKey(s => s.CategoryID);


        }
    }
}
