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

    public Task<CreateSubscriptionResult> HandleAsync(CreateSubscriptionCommand command)
    {

    }
}