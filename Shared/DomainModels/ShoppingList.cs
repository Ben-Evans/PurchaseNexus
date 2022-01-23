namespace PurchaseNexus.Shared.DomainModels;

public class ShoppingList : BaseList<ShoppingItem>
{
    public ShoppingList(string name) : base(name)
    {
    }
}
