public record CreateSubscriptionCommand
{
    public Guid UserId { get; init; }
    public Guid PlanId { get; init; }
    public BillingCycle BillingCycle { get; init; }
}