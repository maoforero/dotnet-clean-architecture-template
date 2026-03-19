using SaaSApi.Domain;

public class CreateSubscriptionHandler
{
    private readonly IPlanRepository _planRepository;
    private readonly ISubscriptionRepository _subcriptionRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSubscriptionHandler
    (
        IPlanRepository planRepository,
        ISubscriptionRepository subscriptionRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
        
    )
    {
        _planRepository = planRepository;
        _subcriptionRepository = subscriptionRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateSubscriptionResult> HandleAsync(CreateSubscriptionCommand command, CancellationToken ct)
    {
        var userid = await _userRepository.GetByIdAsync(command.UserId);
        if(userid == null) throw new ArgumentException("User Id is null");

        var planId = await _planRepository.GetByIdAsync(command.PlanId);
        if(planId == null) throw new ArgumentException("Plan Id must is null");

        var subscription =  Subscription.Create(command.PlanId, command.UserId, command.BillingCycle);

        await _subcriptionRepository.AddAsync(subscription);
        await _unitOfWork.CommitAsync(ct);

       return new CreateSubscriptionResult
       {
            SubscriptionId = subscription.Id,
            Status = subscription.Status,
            EndDate = subscription.EndDate
       };
    }
}