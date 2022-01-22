using PurchaseNexus.Server.Extensions;

namespace PurchaseNexus.Server.Repositories;

public interface IFoodInventoryRepository
{
    IQueryable<Food> GetModels(bool? enableTracking = default, params string[] includedPropertyPaths);
    Task<Food?> GetModel(int id, bool? enableTracking = default, params string[] includedPropertyPaths);
    Task<bool> Save(params Food[] foods);
    void Delete(params Food[] foods);
}

public class FoodInventoryRepository : IFoodInventoryRepository
{
    private readonly ApplicationDbContext _dbAccess;

    public FoodInventoryRepository(ApplicationDbContext dbAccess)
    {
        _dbAccess = dbAccess;
    }

    public IQueryable<Food> GetModels(bool? enableTracking = default, params string[] includedPropertyPaths)
    {
        return _dbAccess.Foods
            .IncludeProperties(includedPropertyPaths)
            .WithTracking(enableTracking);
    }

    public async Task<Food?> GetModel(int id, bool? enableTracking = default, params string[] includedPropertyPaths)
    {
        var food = await GetModels(enableTracking, includedPropertyPaths)
            .FirstOrDefaultAsync(x => x.Id == id);
        return food;
    }

    public async Task<bool> Save(Food[] foods)
    {
        foreach (var food in foods)
        {
            if (food.IsSaved()) await _dbAccess.AddAsync(food);
            /*else if (food.Id > 0) _dbAccess.Update(food); // TODO: Unnessesary? Should always be tracked anyways
            else throw new NotImplementedException("Discovered unexpected data state.");*/
            else if (food.Id < 0) throw new NotImplementedException("Discovered unexpected data state.");
        }
        var saveSuccess = (await _dbAccess.SaveChangesAsync()) > 0;
        return saveSuccess;
    }

    public void Delete(params Food[] foods)
    {
        _dbAccess.RemoveRange(foods);
    }
}
