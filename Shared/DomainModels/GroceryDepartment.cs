namespace PurchaseNexus.Shared.DomainModels;

public class GroceryDepartment : INamedDomainModel
{
    public GroceryDepartment(string name, bool productsMostlyRefrigerated)
    {
        Name = name;
        ProductsMostlyRefrigerated = productsMostlyRefrigerated;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public bool ProductsMostlyRefrigerated { get; set; }
}
