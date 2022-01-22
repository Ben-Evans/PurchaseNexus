namespace PurchaseNexus.Server.Validators;

public interface IFoodValidator : Shared.Validators.IFoodValidator
{
}

public class FoodValidator : Shared.Validators.FoodValidator, IFoodValidator
{
    public FoodValidator() : base()
    {
    }
}
