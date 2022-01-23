namespace PurchaseNexus.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingItemsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ShoppingItemsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ShoppingItem), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ShoppingItem>> GetItem(int id)
    {
        ShoppingItem? item = await _context.ShoppingItems.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        return item;
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutItem(int id, ShoppingItem item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        _context.Entry(item).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ItemExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(typeof(ShoppingItem), StatusCodes.Status201Created)]
    public async Task<ActionResult<ShoppingItem>> PostItem(ShoppingItem item)
    {
        _context.ShoppingItems.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteItem(int id)
    {
        ShoppingItem? item = await _context.ShoppingItems.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        _context.ShoppingItems.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ItemExists(int id)
    {
        return _context.ShoppingItems.Any(e => e.Id == id);
    }
}
