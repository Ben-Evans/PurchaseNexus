namespace PurchaseNexus.Shared.Models;

public class TodoList : BaseList<TodoItem>
{
    public TodoList(string name) : base(name)
    {
    }
}
