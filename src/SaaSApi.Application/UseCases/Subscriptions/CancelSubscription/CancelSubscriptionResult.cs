public record CancelSubscriptionResult
{
    public Guid SubscriptionId { get; init; }
    public SubscriptionStatus Status { get; init; }
    public DateTime EndDate { get; init; }
}