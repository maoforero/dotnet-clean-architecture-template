using Microsoft.EntityFrameworkCore;
using SaaSApi.Domain;

public class SaaSDbContext : DbContext
{
    public SaaSDbContext(DbContextOptions<SaaSDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
}