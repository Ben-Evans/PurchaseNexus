namespace PurchaseNexus.Shared.Utilities;

public static class NotNullHelper
{
    public static T Injected<T>() where T : class => null!;
    public static T NavigationProp<T>() where T : class => null!;
    public static T OnInit<T>() where T : class => null!;
    public static T Param<T>() where T : class => null!;
    public static T CascadingParam<T>() where T : class => null!;
    public static T Ref<T>() where T : class => null!;
}
