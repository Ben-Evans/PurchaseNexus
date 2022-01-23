namespace PurchaseNexus.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingListsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ShoppingListsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShoppingList>>> GetLists()
    {
        return await _context.ShoppingLists.ToListAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ShoppingList), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ShoppingList>> GetList(int id)
    {
        ShoppingList? list = await _context.ShoppingLists
            .Include(tl => tl.Items)
            .FirstOrDefaultAsync(tl => tl.Id == id);

        if (list == null)
        {
            return NotFound();
        }

        return list;
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutList(int id, ShoppingList list)
    {
        if (id != list.Id)
        {
            return BadRequest();
        }

        _context.Entry(list).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ListExists(id))
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
    [ProducesResponseType(typeof(ShoppingList), StatusCodes.Status201Created)]
    public async Task<ActionResult<ShoppingList>> PostList(ShoppingList list)
    {
        _context.ShoppingLists.Add(list);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetList), new { id = list.Id }, list);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteList(int id)
    {
        ShoppingList? list = await _context.ShoppingLists.FindAsync(id);
        if (list == null)
        {
            return NotFound();
        }

        _context.ShoppingLists.Remove(list);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ListExists(int id)
    {
        return _context.ShoppingLists.Any(e => e.Id == id);
    }
}
