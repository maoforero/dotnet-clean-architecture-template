namespace SaaSApi.Domain;

public class Subscription : BaseEntity
{
    public Guid PlanId { get; private set; }
    public Guid UserId { get; private set; }
    public SubscriptionStatus Status { get; private set; } = SubscriptionStatus.Trial;
    public BillingCycle BillingCycle { get; private set; }
    public DateTime StartDate { get; private set; } = DateTime.UtcNow;
    public DateTime EndDate { get; private set; }

    public static Subscription Create(Guid planId, Guid userId, BillingCycle billingCycle)
    {
        var subscription = new Subscription();
        subscription.UserId = userId;

        switch (billingCycle)
        {
            case BillingCycle.Monthly:
                subscription.EndDate = DateTime.UtcNow.AddMonths(1);
                break;
            case BillingCycle.Quarter:
                subscription.EndDate = DateTime.UtcNow.AddMonths(3);
                break;
            case BillingCycle.Semester:
                subscription.EndDate = DateTime.UtcNow.AddMonths(6);
                break;
            case BillingCycle.Annual:
                subscription.EndDate = DateTime.UtcNow.AddYears(1);
                break;
        }

        return subscription;
    }
}
