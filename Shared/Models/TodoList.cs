namespace PurchaseNexus.Shared.Models;

public class TodoList
{
    public TodoList(string title)
    {
        Title = title;
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public ICollection<TodoItem> Items { get; set; } = new List<TodoItem>();
}
