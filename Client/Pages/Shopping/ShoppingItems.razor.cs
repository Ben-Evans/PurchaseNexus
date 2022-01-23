namespace PurchaseNexus.Client.Pages.Shopping;

public partial class ShoppingItems
{
    [CascadingParameter] public ShoppingState State { get; set; } = NotNullHelper.CascadingParam<ShoppingState>();

    public ShoppingItem? SelectedItem { get; set; }

    private ElementReference _itemNameInput;

    private ElementReference _listOptionsModal;

    public bool IsSelectedItem(ShoppingItem item) => SelectedItem == item;

    private async Task AddItem()
    {
        if (State.SelectedList is null) throw new NullReferenceException($"Called {nameof(AddItem)} with null {nameof(State.SelectedList)}");

        ShoppingItem newItem = new(string.Empty, State.SelectedList.Id);

        State.SelectedList.Items.Add(newItem);

        await EditItem(newItem);
    }

    private async Task ToggleDone(ShoppingItem item, ChangeEventArgs args)
    {
        if (args is not null && args.Value is bool value)
        {
            item.Done = value;

            await State.ListItemsClient.PutItemAsync(item.Id, item);
        }
    }

    private async Task EditItem(ShoppingItem item)
    {
        SelectedItem = item;

        await Task.Delay(50);

        if (_itemNameInput.Context != null)
        {
            await _itemNameInput.FocusAsync();
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
                var item = await State.ListItemsClient.PostItemAsync(SelectedItem);

                SelectedItem.Id = item.Id;
            }
        }
        else
        {
            if (string.IsNullOrWhiteSpace(SelectedItem.Name))
            {
                await State.ListItemsClient.DeleteItemAsync(SelectedItem.Id);
                State.SelectedList.Items.Remove(SelectedItem);
            }
            else
            {
                await State.ListItemsClient.PutItemAsync(SelectedItem.Id, SelectedItem);
            }
        }
    }

    private async Task SaveList()
    {
        if (State.SelectedList is null) throw new NullReferenceException($"Called {nameof(SaveList)} with null {nameof(State.SelectedList)}");

        await State.ListsClient.PutListAsync(State.SelectedList.Id, State.SelectedList);

        State.JS.InvokeVoid(JsInteropConstants.HideModal, _listOptionsModal);

        State.SyncList();
    }

    private async Task DeleteList()
    {
        if (State.SelectedList is null) throw new NullReferenceException($"Called {nameof(DeleteList)} with null {nameof(State.SelectedList)}");

        await State.ListsClient.DeleteListAsync(State.SelectedList.Id);

        State.JS.InvokeVoid(JsInteropConstants.HideModal, _listOptionsModal);

        await State.DeleteList();
    }
}
