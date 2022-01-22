namespace PurchaseNexus.Shared.Extensions;

public static class EnumerationExtensions
{
    public static IList<TEnum> GetEnumerations<TEnum>(this Type enumProvider)
        where TEnum : Enumeration
    {
        var enumProvType = enumProvider.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
        var enumProvValues = enumProvType.Select(f => f.GetValue(null));
        var enumProvs = enumProvValues.Cast<TEnum>().ToList();

        return enumProvs;
    }

    public static bool IsValidEnumeration<TEnum>(this TEnum? enumeration)
        where TEnum : Enumeration?
    {
        // return enumeration == null || GetAll<TEnum>().Contains(enumeration);
        throw new NotImplementedException();
    }
}
