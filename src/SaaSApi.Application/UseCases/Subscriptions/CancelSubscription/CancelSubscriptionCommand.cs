public record CancelSubscriptionCommand
{
    public Guid UserId { get; init; }
    public Guid PlanId { get; init; }
}