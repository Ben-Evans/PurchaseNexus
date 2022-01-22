namespace PurchaseNexus.Shared.DomainModels;

public class ProductPurchaseHistory : IDomainModel
{
    public ProductPurchaseHistory(
        double purchasePrice,
        DateTime purchaseDate)
        //Product product)
    {
        PurchasePrice = purchasePrice;
        PurchaseDate = purchaseDate;
        //Product = product;
    }

    public int Id { get; set; }

    public double PurchasePrice { get; set; }

    public DateTime PurchaseDate { get; set; } // TODO: Switch to DateOnly? when SQL/EF supports it

    public bool? PurchasedOnSale { get; set; }

    public double? RegularPrice { get; set; }

    public Product Product { get; set; }
    public int ProductId { get; set; }
}
