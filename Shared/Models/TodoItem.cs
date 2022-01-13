using System.Diagnostics.CodeAnalysis;

namespace PurchaseNexus.Shared.Models;

public class TodoItem
{
    public TodoItem(string title, int todoListId)
    {
        Title = title;
        TodoListId = todoListId;
    }

    /// <summary>
    /// Parameterless Constructor for use with EF
    /// </summary>
    private TodoItem() => DbInit();

    public int Id { get; set; }

    public int TodoListId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Note { get; set; } = string.Empty;

    public TodoItemPriority Priority { get; set; }

    public TodoItemState State { get; set; }

    public bool Done { get; set; }

    public TodoList? TodoList { get; set; }

    [MemberNotNull(nameof(TodoList))]
    private void DbInit()
    {
        TodoList = NotNullHelper.NavigationProp<TodoList>();
    }
}
