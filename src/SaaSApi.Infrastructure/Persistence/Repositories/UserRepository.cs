
public class UserRepository : IUserRepository
{
    public Task AddAsync(User entity, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetWithSubscriptionAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User entity, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}