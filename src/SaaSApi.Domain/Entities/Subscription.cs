namespace SaaSApi.Domain;

public class Subscription : BaseEntity
{
    public Guid Id { get; private set; }
    public Guid PlanId { get; private set; }
    public SubscriptionStatus Status { get; private set; }
    public BillingCycle BillingCycle { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
}
