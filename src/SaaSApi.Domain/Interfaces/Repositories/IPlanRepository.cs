public interface IPlanRepository : IRepository<Plan>
{
    Task<Plan?> GetWithNameAsync(string name, CancellationToken ct);
}