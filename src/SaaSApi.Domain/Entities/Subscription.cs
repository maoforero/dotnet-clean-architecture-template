namespace SaaSApi.Domain;

public class Subscription : BaseEntity
{
    public Guid PlanId { get; private set; }
    public Guid UserId { get; private set; }
    public SubscriptionStatus Status { get; private set; } = SubscriptionStatus.Trial;
    public BillingCycle BillingCycle { get; private set; }
    public DateTime StartDate { get; private set; } = DateTime.UtcNow;
    public DateTime EndDate { get; private set; }

    private Subscription(){ }

    public static Subscription Create(Guid planId, Guid userId, BillingCycle billingCycle)
    {
        var subscription = new Subscription();
        subscription.UserId = userId;
        subscription.PlanId = planId;


        subscription.EndDate = billingCycle switch
        {
            BillingCycle.Monthly => DateTime.UtcNow.AddMonths(1),
            BillingCycle.Quarter => DateTime.UtcNow.AddMonths(3),
            BillingCycle.Semester => DateTime.UtcNow.AddMonths(6),
            BillingCycle.Annual => DateTime.UtcNow.AddYears(1),
            _ =>  throw new ArgumentException("Invalid billing cycle")
        };

        return subscription;
    }

    public void Cancel()
    {
        if(Status == SubscriptionStatus.Cancelled || Status == SubscriptionStatus.Expired)
            throw new InvalidOperationException("Status is already cancelled or expired");

        Status = SubscriptionStatus.Cancelled;
    }

    public void Upgrade(Plan plan)
    {
        // Recibimos plan
        
        // Debemos cambiar el planId
        var newPlan = Plan.Create(plan.Name, plan.Description, plan.Price, plan.BillingCycle);
    }
}
