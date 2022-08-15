using Microsoft.AspNetCore;
using WebProjectOnAzure.Models;
using Microsoft.EntityFrameworkCore;
namespace WebProjectOnAzure.Data;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
   
    }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Message>()
            .HasOne<AppUser>(a => a.Sender)
            .WithMany(d => d.Messages)
            .HasForeignKey(d => d.UserID);
    }
}
