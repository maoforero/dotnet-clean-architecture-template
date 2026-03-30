public class CancelSubscriptionHandler
{
    private readonly IPlanRepository _planRepository;
    private readonly ISubscriptionRepository _subscriptionrepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CancelSubscriptionHandler(
        IPlanRepository planRepository,
        ISubscriptionRepository subscriptionRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    )
    {
        _planRepository = planRepository;
        _subscriptionrepository = subscriptionRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CancelSubscriptionResult> HandleAsync()
    {
        
    }
}