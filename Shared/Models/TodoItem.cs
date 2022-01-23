namespace PurchaseNexus.Shared.Models;

public class TodoItem : BaseListItem<TodoList>
{
    public TodoItem(string name, int listId) : base(name, listId)
    {
    }
}
