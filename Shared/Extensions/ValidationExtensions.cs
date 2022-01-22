namespace PurchaseNexus.Shared.Extensions;

public static class ValidationExtensions
{
    public static IRuleBuilderOptions<T, TProperty> IsInEnumeration<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        where TProperty : Enumeration?
    {
        return ruleBuilder.Must(x => x.IsValidEnumeration()).WithMessage($"Invalid {nameof(Enumeration)} detected.");
    }
}
