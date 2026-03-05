public class Plan : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Money Price { get; private set; }
    public BillingCycle BillingCycle { get; private set; }
    public bool IsActive { get; private set; } = true;

    private Plan()
    {
        
    }

    public static Plan Create(string name, string description, Money money, BillingCycle billingCycle)
    {
        if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must have a valid parameters.");
        if(string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description must have valid parameters.");
        
        var plan = new Plan();
        plan.Name = name;
        plan.Description = description;
        plan.Price = money;
        plan.BillingCycle = billingCycle;

        return plan;
    }
}