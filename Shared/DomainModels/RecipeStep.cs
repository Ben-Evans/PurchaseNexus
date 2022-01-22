namespace PurchaseNexus.Shared.DomainModels;

public class RecipeStep : IDomainModel
{
    public RecipeStep(
        string description,
        int stepOrder)
        // Recipe recipe)
    {
        Description = description;
        StepOrder = stepOrder;
        // Recipe = recipe;
    }

    public int Id { get; set; }

    public string Description { get; set; }

    public int StepOrder { get; set; }

    public Recipe Recipe { get; set; }
    public int RecipeId { get; set; }
}
