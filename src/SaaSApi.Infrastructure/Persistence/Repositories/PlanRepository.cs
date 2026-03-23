
using Microsoft.EntityFrameworkCore;

public class PlanRepository : IPlanRepository
{
    private readonly SaaSDbContext _context;

    public PlanRepository(SaaSDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Plan entity, CancellationToken ct = default)
    {
        await _context.Plans.AddAsync(entity, ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var plan = await GetByIdAsync(id, ct);
        if(plan != null) _context.Plans.Remove(plan);
    }

    public async Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Plans.ToListAsync();
    }

    public async Task<Plan> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Plans.FindAsync(id, ct);
    }

    public async Task<Plan?> GetWithNameAsync(string name, CancellationToken ct = default)
    {
        return await _context.Plans.FirstOrDefaultAsync(p => p.Name == name, ct);
    }

    public Task UpdateAsync(Plan entity, CancellationToken ct = default)
    {
        _context.Plans.Update(entity);
        return Task.CompletedTask;
    }
}