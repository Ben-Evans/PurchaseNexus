﻿namespace PurchaseNexus.Shared;

public class TodoList
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public ICollection<TodoItem> Items { get; set; } = new List<TodoItem>();
}
