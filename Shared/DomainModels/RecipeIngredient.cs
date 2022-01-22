namespace PurchaseNexus.Shared.DomainModels;

public class RecipeIngredient : INamedDomainModel
{
    public RecipeIngredient(
        string name,
        double requiredMeasurement)
        /*MeasurementType measurementType,
        Recipe recipe)*/
    {
        Name = name;
        RequiredMeasurement = requiredMeasurement;
        /*MeasurementType = measurementType;
        Recipe = recipe;*/
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public double RequiredMeasurement { get; set; }

    public MeasurementType MeasurementType { get; set; }
    public int MeasurementTypeId { get; set; }

    public Recipe Recipe { get; set; }
    public int RecipeId { get; set; }
}
