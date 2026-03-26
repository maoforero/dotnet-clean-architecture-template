using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController: ControllerBase
{
    private readonly CreateSubscriptionHandler _subscriptionHandler;
    private readonly ILogger<SubscriptionController> _logger;

    public SubscriptionController(CreateSubscriptionHandler subscriptionHandler, ILogger<SubscriptionController> logger)
    {
        _subscriptionHandler = subscriptionHandler;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSubscriptionCommand  susCommand, CancellationToken ct)
    {
        if(susCommand ==  null)
            return BadRequest("Data is missing");

        _logger.LogInformation("Request received to cerate a nre subscription.");
        var result = await _subscriptionHandler.HandleAsync(susCommand, ct);
        return CreatedAtAction(nameof(Create), result);
    } 

}