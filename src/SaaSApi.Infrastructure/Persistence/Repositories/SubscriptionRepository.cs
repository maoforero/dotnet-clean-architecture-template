using Microsoft.EntityFrameworkCore;
using SaaSApi.Domain;

public class SubscriptionRepository : ISubscriptionRepository
{

    private readonly SaaSDbContext _context;

    public SubscriptionRepository(SaaSDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Subscription entity, CancellationToken ct = default)
    {
        await _context.AddAsync(entity, ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var sub = await GetByIdAsync(id, ct);
        if(sub != null) _context.Subscriptions.Remove(sub);
    }

    public async Task<Subscription?> GetActiveByUserIdAsync(Guid userId, CancellationToken ct = default)
    {
        return await _context.Subscriptions.FirstOrDefaultAsync(u => u.UserId == userId && u.Status == SubscriptionStatus.Active, ct);
    }

    public async Task<IEnumerable<Subscription>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Subscriptions.ToListAsync();
    }

    public async Task<Subscription?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Subscriptions.FindAsync(id, ct);
    }

    public Task UpdateAsync(Subscription entity, CancellationToken ct = default)
    {
        _context.Subscriptions.Update(entity);
        return Task.CompletedTask;
    }
}