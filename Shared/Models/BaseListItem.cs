namespace PurchaseNexus.Shared.Models;

public class BaseListItem<TList> : INamedDomainModel
    where TList : class
{
    public BaseListItem(string name, int listId)
    {
        Name = name;
        ListId = listId;
    }

    public int Id { get; set; }

    public int ListId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Note { get; set; } = string.Empty;

    public ListItemPriority Priority { get; set; }

    public ListItemState State { get; set; }

    public bool Done { get; set; }

    public TList? List { get; set; }
}
