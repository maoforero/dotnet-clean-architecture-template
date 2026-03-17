public interface IUserRepository : IRepository<User>
{
    Task<User> GetWithSubscriptionAsync(string email, CancellationToken ct);
}