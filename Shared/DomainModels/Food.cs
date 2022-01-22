namespace PurchaseNexus.Shared.DomainModels;

public class Food : Product, IDeletable
{
    public Food(
        string name,
        // ProductType productType, // TODO: Reevaluate
        int quantity = 1,
        int quantityToAddWhenDisposed = 0)
        : base(name, quantity, quantityToAddWhenDisposed)
    {
    }

    public DateTime? ExpiryDate { get; set; } // TODO: Switch to DateOnly? when SQL/EF supports it

    public bool? IsRefrigerated { get; set; }

    public double? Measurement { get; set; }

    public MeasurementType? MeasurementType { get; set; }
    public int? MeasurementTypeId { get; set; }

    public GroceryDepartment? GroceryDepartment { get; set; }
    public int? GroceryDepartmentId { get; set; }

    public bool ToDelete { get; set; }

    /*[NotMapped]
    public double? MeasurementValue => ProductValue.SafeDivide(Measurement);*/
}
