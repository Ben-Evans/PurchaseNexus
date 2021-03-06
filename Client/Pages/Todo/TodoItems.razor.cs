namespace PurchaseNexus.Client.Pages.Todo;

public partial class TodoItems
{
    [CascadingParameter] public TodoState State { get; set; } = NotNullHelper.CascadingParam<TodoState>();

    public TodoItem? SelectedItem { get; set; }

    private ElementReference _titleInput;

    private ElementReference _listOptionsModal;

    public bool IsSelectedItem(TodoItem item) => SelectedItem == item;

    private async Task AddItem()
    {
        if (State.SelectedList is null) throw new NullReferenceException($"Called {nameof(AddItem)} with null {nameof(State.SelectedList)}");

        TodoItem newItem = new(string.Empty, State.SelectedList.Id);

        State.SelectedList.Items.Add(newItem);

        await EditItem(newItem);
    }

    private async Task ToggleDone(TodoItem item, ChangeEventArgs args)
    {
        if (args is not null && args.Value is bool value)
        {
            item.Done = value;

            await State.TodoItemsClient.PutTodoItemAsync(item.Id, item);
        }
    }

    private async Task EditItem(TodoItem item)
    {
        SelectedItem = item;

        await Task.Delay(50);

        if (_titleInput.Context != null)
        {
            await _titleInput.FocusAsync();
        }
    }

    private async Task UnselectItem()
    {
        await SaveItem();
        SelectedItem = null; // Called onBlur, therefore unselect item
    }

    private async Task SaveItem()
    {
        // TODO: Log issue then throw exception
        if (SelectedItem is null) throw new NullReferenceException($"Called {nameof(SaveItem)} with null {nameof(SelectedItem)}");
        else if (State.SelectedList is null) throw new NullReferenceException($"Called {nameof(SaveItem)} with null {nameof(State.SelectedList)}");

        if (SelectedItem.Id == 0)
        {
            if (string.IsNullOrWhiteSpace(SelectedItem.Name))
            {
                State.SelectedList.Items.Remove(SelectedItem);
            }
            else
            {
                var item = await State.TodoItemsClient.PostTodoItemAsync(SelectedItem);

                SelectedItem.Id = item.Id;
            }
        }
        else
        {
            if (string.IsNullOrWhiteSpace(SelectedItem.Name))
            {
                await State.TodoItemsClient.DeleteTodoItemAsync(SelectedItem.Id);
                State.SelectedList.Items.Remove(SelectedItem);
            }
            else
            {
                await State.TodoItemsClient.PutTodoItemAsync(SelectedItem.Id, SelectedItem);
            }
        }
    }

    private async Task SaveList()
    {
        if (State.SelectedList is null) throw new NullReferenceException($"Called {nameof(SaveList)} with null {nameof(State.SelectedList)}");

        await State.TodoListsClient.PutTodoListAsync(State.SelectedList.Id, State.SelectedList);

        State.JS.InvokeVoid(JsInteropConstants.HideModal, _listOptionsModal);

        State.SyncList();
    }

    private async Task DeleteList()
    {
        if (State.SelectedList is null) throw new NullReferenceException($"Called {nameof(DeleteList)} with null {nameof(State.SelectedList)}");

        await State.TodoListsClient.DeleteTodoListAsync(State.SelectedList.Id);

        State.JS.InvokeVoid(JsInteropConstants.HideModal, _listOptionsModal);

        await State.DeleteList();
    }
}
