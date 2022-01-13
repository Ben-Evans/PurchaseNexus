﻿namespace PurchaseNexus.Shared.Models;

public class TodoItem
{
    public TodoItem(string title, int listId)
    {
        Title = title;
        ListId = listId;
    }

    public int Id { get; set; }

    public int ListId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Note { get; set; } = string.Empty;

    public TodoItemPriority Priority { get; set; }

    public TodoItemState State { get; set; }

    public bool Done { get; set; }

    public TodoList? List { get; set; }
}
