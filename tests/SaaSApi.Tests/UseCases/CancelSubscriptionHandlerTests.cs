using Microsoft.VisualBasic;
using Moq;
using SaaSApi.Domain;
using Xunit.Sdk;

public class CancelSubscriptionHandlerTest
{
    [Fact]
    public async Task HandleAsync_WhenUserNotFound_ThrowsArgumentException()
    {
        // Arrange
        var iSubscriptionRepository = new Mock<ISubscriptionRepository>();
        var iUserRepository = new Mock<IUserRepository>();
        var iUnitOfWork = new Mock<IUnitOfWork>();

        var handler = new CancelSubscriptionHandler(
            iSubscriptionRepository.Object,
            iUserRepository.Object,
            iUnitOfWork.Object
        );

        iUserRepository
            .Setup(r => r.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((User?)null);

        var command = new CancelSubscriptionCommand {UserId = Guid.NewGuid()};

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => 
            handler.HandleAsync(command, CancellationToken.None));
    }

    [Fact]
    public async Task HandleAsync_WhenSubscriptionNotFound_ThrowsArgumentException()
    {
        // Arrange
        var iSubscriptionRepository = new Mock<ISubscriptionRepository>();
        var iUserRepository = new Mock<IUserRepository>();
        var iUnitOfWork = new Mock<IUnitOfWork>();

        var handlerSubs = new CancelSubscriptionHandler(
            iSubscriptionRepository.Object,
            iUserRepository.Object,
            iUnitOfWork.Object
        );

        var user = User.Create("John", "Doe", "JohnDoe@Email.com");

        iUserRepository
            .Setup(u => u.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((user));

        iSubscriptionRepository
            .Setup(s => s.GetActiveByUserIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Subscription?)null);

        var command = new CancelSubscriptionCommand {UserId = Guid.NewGuid()};

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() =>
            handlerSubs.HandleAsync(command, CancellationToken.None));            
    }

    
    [Fact]
    public async Task HandleAsync_WhenSubscriptionAlreadyCancelled_ThrowsInvalidOperationException()
    {
        // Arrange
        var iSubscriptionRepository = new Mock<ISubscriptionRepository>();
        var iUserRepository = new Mock<IUserRepository>();
        var iUnitOfWork = new Mock<IUnitOfWork>();

        var handler = new CancelSubscriptionHandler(
            iSubscriptionRepository.Object,
            iUserRepository.Object,
            iUnitOfWork.Object
        );

        var user = User.Create("John", "Doe", "JohnDoe@Email.com");
        var plan = Plan.Create("Basic", "Basic plan", new Money(10, "USD"), BillingCycle.Monthly);
        var subs = Subscription.Create( plan.Id, user.Id,  BillingCycle.Monthly);

        subs.Cancel();

        iUserRepository
            .Setup(r => r.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((user));

        iSubscriptionRepository
            .Setup(s => s.GetActiveByUserIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(subs);

        var command = new CancelSubscriptionCommand {UserId = Guid.NewGuid()};

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => 
            handler.HandleAsync(command, CancellationToken.None));
    }
}