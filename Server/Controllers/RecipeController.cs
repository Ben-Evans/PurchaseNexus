namespace PurchaseNexus.Server.Controllers;

public interface IRecipeController
{
}

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase, IRecipeController
{
}
