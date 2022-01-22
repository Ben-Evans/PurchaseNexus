namespace PurchaseNexus.Shared.DomainModels;

public class Store : INamedDomainModel
{
    public Store(string name, string url)
    {
        Name = name;
        Url = url;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Url { get; set; }

    public IList<Brand> AvailableBrands { get; set; } = new List<Brand>();

    public IList<Product> Products { get; set; } = new List<Product>();
}
