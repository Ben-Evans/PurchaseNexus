namespace PurchaseNexus.Shared.Extensions;

public static class ModelExtensions
{
    public static bool IsSaved<T>(this T model)
        where T : class, IHasId
    {
        return model.Id > 0;
    }
}
