using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WhatsAppChatbot.Model;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Định nghĩa các DbSet cho các bảng trong database
    public DbSet<Customer?> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>(c =>
        {
            c.ToTable(nameof(Customer));

            c.HasKey(c => c.Id);
        });

        modelBuilder.Entity<Order>(o =>
        {
            o.ToTable(nameof(Order));

            o.HasKey(o => o.Id);

            o.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
        });
    }
}