namespace PurchaseNexus.Server.Controllers;

public interface IFoodInventoryController
{
    Task<IActionResult> GetInventory([FromBody] FoodQuery query);
    Task<IActionResult> GetFood([FromQuery] int id);
    Task<IActionResult> UpdateFood([FromQuery] int id, [FromBody] Food food);
}

public class FoodInventoryController : BaseApiController<IFoodInventoryController>, IFoodInventoryController
{
    private readonly IFoodInventoryService _service;

    public FoodInventoryController(
        IFoodInventoryService service,
        ILogger<IFoodInventoryController> logger)
        : base(logger)
    {
        _service = service;
    }

    [HttpGet]
    [ApiVersion("1.0")]
    [Consumes(System.Net.Mime.MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Food>))] // TODO: Add elsewhere
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetInventory([FromBody] FoodQuery query)
    {
        try
        {
            var foods = await _service.GetFoods(query);
            return Ok(foods);
        }
        catch (ArgumentNullException ex) { return LogBadRequest(ex); }
        catch (Exception ex) { return LogInternalServerError(ex); }
    }

    /// <summary>
    /// Gets a single food item based on id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <remarks>
    ///     Sample Request:
    ///     {
    ///         "id": 1
    ///     }
    /// </remarks>
    [HttpGet("{id}")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public async Task<IActionResult> GetFood([FromQuery] int id)
    {
        try
        {
            var item = await _service.GetFood(id);
            return Ok(item);
        }
        catch (ArgumentNullException ex) { return LogBadRequest(ex); }
        catch (ArgumentOutOfRangeException ex) { return LogBadRequest(ex); }
        catch (Exception ex) { return LogInternalServerError(ex); }
    }

    [HttpPost]
    [ApiVersion("1.0")]
    public async Task<IActionResult> UpdateFood([FromQuery] int id, [FromBody] Food food)
    {
        try
        {
            if (!ModelState.IsValid) return LogBadRequest(new ArgumentException("ModelState found to be invalid.", nameof(ModelState)));
            else if (food.Id != id) return LogBadRequest(new ArgumentException("Arguements provided do not match.", nameof(id)));

            var savedItemId = await _service.CreateOrUpdateFood(food);
            return CreateOrUpdateResponse(food.Id, savedItemId, nameof(GetFood)); // TODO: nameof(UpdateFood) or nameof(GetFood)
        }
        catch (ValidationException ex) { return LogValidationProblem(ex); }
        catch (DbUpdateException ex) { return LogInternalServerError(ex); }
        catch (Exception ex) { return LogInternalServerError(ex); }
    }
}
