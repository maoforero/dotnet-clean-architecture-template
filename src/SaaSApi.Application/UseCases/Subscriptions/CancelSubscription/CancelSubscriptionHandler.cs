using SaaSApi.Domain;

public class CancelSubscriptionHandler
{
    private readonly ISubscriptionRepository _subscriptionrepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CancelSubscriptionHandler(
        ISubscriptionRepository subscriptionRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    )
    {
        _subscriptionrepository = subscriptionRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CancelSubscriptionResult> HandleAsync(CancelSubscriptionCommand command, CancellationToken ct)
    {
        var userId = await _userRepository.GetByIdAsync(command.UserId, ct);
        if(userId == null) throw new ArgumentException("User Id doesnt exist");

        var subscription = await _subscriptionrepository.GetActiveByUserIdAsync(command.UserId, ct);
        if(subscription == null) throw new ArgumentException("Subscription doesnt exist");

        subscription.Cancel();

        await _subscriptionrepository.UpdateAsync(subscription, ct);
        await _unitOfWork.CommitAsync(ct);

        return new CancelSubscriptionResult
        {
            SubscriptionId = subscription.Id,
            Status = subscription.Status,
            EndDate = subscription.EndDate
        };
    }
}