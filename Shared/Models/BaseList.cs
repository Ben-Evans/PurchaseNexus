namespace PurchaseNexus.Shared.Models;

public class BaseList<TItem> : INamedDomainModel
{
    public BaseList(string name)
    {
        Name = name;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public IList<TItem> Items { get; set; } = new List<TItem>();
}
