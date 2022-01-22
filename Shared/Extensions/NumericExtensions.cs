namespace PurchaseNexus.Shared.Extensions;

public static class NumericExtensions
{
    public static double? SafeDivide(this double? numerator, double? denominator)
    {
        if (numerator == null || denominator == null) return default;
        else if (denominator == 0) return default;

        return numerator / denominator;
    }
}
