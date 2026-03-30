public record CancelSubscriptionCommand
{
    public Guid UserId { get; init; }
}