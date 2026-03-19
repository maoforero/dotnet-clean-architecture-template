
public class UnitOfWork : IUnitOfWork
{
    private readonly SaaSDbContext _saasDbContext;

    public UnitOfWork(SaaSDbContext saaSDbContext)
    {
        _saasDbContext = saaSDbContext;
    }

    public async Task CommitAsync(CancellationToken ct)
    {
        await _saasDbContext.SaveChangesAsync(ct);
    }
}