
public class PlanRepository : IPlanRepository
{
    private readonly SaaSDbContext _context;

    public PlanRepository(SaaSDbContext context)
    {
        _context = context;
    }

    public Task AddAsync(Plan entity, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Plan> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Plan?> GetWithNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Plan entity, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}