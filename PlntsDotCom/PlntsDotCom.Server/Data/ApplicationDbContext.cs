using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlntsDotCom.Server.Data.EntityTypeConfigurations;

namespace PlntsDotCom.Server.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderedItem> OrderedItems => Set<OrderedItem>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Status> Statuses => Set<Status>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserSeedConfig());
        modelBuilder.ApplyConfiguration(new CategorySeedConfig());
        modelBuilder.ApplyConfiguration(new InvoiceSeedConfig());
        modelBuilder.ApplyConfiguration(new OrderSeedConfig());
        modelBuilder.ApplyConfiguration(new OrderedItemSeedConfig());
        modelBuilder.ApplyConfiguration(new ProductSeedConfig());
        modelBuilder.ApplyConfiguration(new ReviewSeedConfig());
        modelBuilder.ApplyConfiguration(new StatusSeedConfig());
    }

}