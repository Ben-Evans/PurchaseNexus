namespace PurchaseNexus.Server.Controllers;

// [Authorize] // TODO: Uncomment once auth added
[ApiController]
[Route("api/[controller]")]
public class BaseApiController<TController> : ControllerBase
{
    public BaseApiController(ILogger<TController> logger)
    {
        Logger = logger;
    }

    protected ILogger<TController> Logger { get; set; }

    /*// PUT: api/[controller]/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, FoodDto food)
    {
        if (id != food.Id)
        {
            return BadRequest();
        }
        await _service.UpdateFood(food);
        return NoContent();
    }

    // POST: api/[controller]
    [HttpPost]
    public async Task<IActionResult> Post(FoodDto food)
    {
        await _service.AddFood(food);
        return CreatedAtAction(nameof(GetFood), new { id = food.Id }, food);
    }

    // DELETE: api/[controller]/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }*/

    protected IActionResult CreateOrUpdateResponse(int updatedItemId, int savedItemId, string actionName)
    {
        var itemSavedSuccessfully = savedItemId > 0;
        if (itemSavedSuccessfully)
        {
            if (updatedItemId == 0) return CreatedAtAction(actionName, savedItemId);
            else if (updatedItemId > 0) return AcceptedAtAction(actionName, updatedItemId);
        }

        return LogInternalServerError();
    }

    protected IActionResult LogInternalServerError(
        Exception? exceptionToLog = default,
        string messageToDisplay = "Unexpected server error occured.")
    {
        if (exceptionToLog != null) Logger.LogError(exceptionToLog, exceptionToLog.Message);

        return StatusCode(StatusCodes.Status500InternalServerError, messageToDisplay);
    }

    protected IActionResult LogValidationProblem(
        ValidationException? exceptionToLog = default,
        string messageToDisplay = "Validation error detected.")
    {
        if (exceptionToLog != null)
        {
            Logger.LogInformation(exceptionToLog, exceptionToLog.Message);
            messageToDisplay = exceptionToLog.Message;
        }

        return ValidationProblem(messageToDisplay);
    }

    protected IActionResult LogBadRequest(
        Exception? exceptionToLog = default,
        string messageToDisplay = "Submitted data found to be invalid.")
    {
        if (exceptionToLog != null) Logger.LogWarning(exceptionToLog, messageToDisplay);

        return BadRequest(messageToDisplay);
    }
}
