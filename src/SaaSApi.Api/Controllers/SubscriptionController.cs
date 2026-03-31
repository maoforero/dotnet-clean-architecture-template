using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController: ControllerBase
{
    private readonly CreateSubscriptionHandler _subscriptionHandler;
    private readonly CancelSubscriptionHandler _cancelSubscriptionHandler;
    private readonly ILogger<SubscriptionController> _logger;

    public SubscriptionController(
        CreateSubscriptionHandler subscriptionHandler, 
        CancelSubscriptionHandler cancelSubscriptionHandler,
        ILogger<SubscriptionController> logger)
    {
        _subscriptionHandler = subscriptionHandler;
        _cancelSubscriptionHandler  = cancelSubscriptionHandler;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSubscriptionCommand  susCommand, CancellationToken ct)
    {
        if(susCommand ==  null)
            return BadRequest("Data is missing");

        _logger.LogInformation("Request received to cerate a new subscription.");
        var result = await _subscriptionHandler.HandleAsync(susCommand, ct);
        return CreatedAtAction(nameof(Create), result);
    } 


    [HttpDelete("{userId}")]
    public async Task<IActionResult> Cancel(Guid userId, CancellationToken ct)
    {
        _logger.LogInformation("Request received to cancel a subscription.");
        var command = new CancelSubscriptionCommand{UserId = userId};
        var result = await _cancelSubscriptionHandler.HandleAsync(command, ct);
        return Ok(result);
    }
}