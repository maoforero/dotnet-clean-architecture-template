using SaaSApi.Domain;

public class SubscriptionRepository : ISubscriptionRepository
{

    private readonly SaaSDbContext _context;

    public SubscriptionRepository(SaaSDbContext context)
    {
        _context = context;
    }

    public Task AddAsync(Subscription entity, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Subscription?> GetActiveByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Subscription>> GetAllAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Subscription> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Subscription entity, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}