using SaaSApi.Domain;

public class CreateSubscriptionHandler
{
    private readonly IPlanRepository _planRepository;
    private readonly ISubscriptionRepository _subcriptionRepository;
    private readonly IUserRepository _userRepository;

    public CreateSubscriptionHandler
    (
        IPlanRepository planRepository,
        ISubscriptionRepository subscriptionRepository,
        IUserRepository userRepository
    )
    {
        _planRepository = planRepository;
        _subcriptionRepository = subscriptionRepository;
        _userRepository = userRepository;    
    }

    public async Task<CreateSubscriptionResult> HandleAsync(CreateSubscriptionCommand command)
    {
        var userid = await _userRepository.GetByIdAsync(command.UserId);
        if(userid == null) throw new ArgumentException("User Id must not be null");

        var planId = await _planRepository.GetByIdAsync(command.PlanId);
        if(planId == null) throw new ArgumentException("Plan Id must not be null");

        var subscription =  Subscription.Create(command.PlanId, command.UserId, command.BillingCycle);

        await _subcriptionRepository.AddAsync(subscription);

       return new CreateSubscriptionResult
       {
            SubscriptionId = subscription.Id,
            Status = subscription.Status,
            EndDate = subscription.EndDate
       };
    }
}