
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly SaaSDbContext _context;

    public UserRepository(SaaSDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(User entity, CancellationToken ct = default)
    {
       await _context.Users.AddAsync(entity, ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var user = await GetByIdAsync(id, ct);
        if(user != null) _context.Users.Remove(user);
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Users.FindAsync(id, ct);
    }

    public async Task<User> GetWithSubscriptionAsync(string email, CancellationToken ct)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, ct);
    }

    public Task UpdateAsync(User entity, CancellationToken ct = default)
    {
        _context.Users.Update(entity);
        return Task.CompletedTask;
    }
}