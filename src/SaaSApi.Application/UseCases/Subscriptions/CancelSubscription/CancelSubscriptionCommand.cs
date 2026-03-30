public record CancelSubscriptionCommand
{
    public Guid PlanId { get; init; }
}