using Moq;

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
        
    }

}