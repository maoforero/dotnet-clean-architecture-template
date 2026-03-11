using SaaSApi.Domain;

public interface ISubscriptionRepository : IRepository<Subscription>
{
    Task<Subscription?> GetActiveByUserIdAsync (Guid userId);
}