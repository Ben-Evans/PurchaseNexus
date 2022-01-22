using System.Text.Json;

namespace PurchaseNexus.Shared.DomainModels;

public class Brand : INamedDomainModel
{
    public Brand(string name)
    {
        Name = name;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public IList<Store> AvailableStores { get; set; } = new List<Store>();

    public IList<Product> Products { get; set; } = new List<Product>();

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
