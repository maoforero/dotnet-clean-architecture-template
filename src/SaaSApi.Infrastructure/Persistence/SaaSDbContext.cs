using Microsoft.EntityFrameworkCore;
using SaaSApi.Domain;

public class SaaSDbContext : DbContext
{
    public SaaSDbContext(DbContextOptions<SaaSDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Plan> Plans => Set<Plan>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaaSDbContext).Assembly);
    }
}