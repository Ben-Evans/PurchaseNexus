namespace PurchaseNexus.Shared.DomainModels;

public class Recipe : INamedDomainModel
{
    public Recipe(string name)
    {
        Name = name;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public int? CookTimeMinutes { get; set; }

    public string? SourceName { get; set; }

    public string? SourceUrl { get; set; }

    public string? ServerImagePath { get; set; }

    public IList<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public IList<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();
}
