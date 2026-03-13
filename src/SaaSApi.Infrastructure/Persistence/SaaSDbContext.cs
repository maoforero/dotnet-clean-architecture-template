using Microsoft.EntityFrameworkCore;

public class SaaSDbcontext : DbContext
{
    public SaaSDbcontext(DbContextOptions<SaaSDbcontext> options) : base(options) { }
}