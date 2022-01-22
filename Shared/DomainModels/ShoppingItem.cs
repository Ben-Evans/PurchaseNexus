namespace PurchaseNexus.Shared.DomainModels;

// Uses same properties as Product, but shouldn't need to rely on Product existing
public class ShoppingItem : Product
{
    public ShoppingItem(
        string name,
        // ProductType productType, // TODO: Reevaluate
        bool isPurchased,
        bool allowSubstitutions,
        // ShoppingList shoppingList,
        int quantity = 1,
        int quantityToAddWhenDisposed = 0)
        : base(name, quantity, quantityToAddWhenDisposed)
    {
        IsPurchased = isPurchased;
        AllowSubstitutions = allowSubstitutions;
        //ShoppingList = shoppingList;
    }

    public bool IsPurchased { get; set; }

    public string? Notes { get; set; }

    public bool AllowSubstitutions { get; set; } // For use with (Preferred)Brand & (Preferred)Store

    public ShoppingList ShoppingList { get; set; }
    public int ShoppingListId { get; set; }
}
