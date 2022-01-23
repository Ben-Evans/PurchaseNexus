namespace PurchaseNexus.Shared.DomainModels;

// TODO: Uses same properties as Product, but shouldn't need to rely on Product existing?
public class ShoppingItem : BaseListItem<ShoppingList>
{
    public ShoppingItem(string name, int listId) : base(name, listId)
    {
    }
}
