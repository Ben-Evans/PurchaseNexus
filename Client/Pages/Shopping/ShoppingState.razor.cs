namespace PurchaseNexus.Client.Pages.Shopping;

public partial class ShoppingState
{
    [Parameter] public RenderFragment ChildContent { get; set; } = NotNullHelper.Param<RenderFragment>();

    [Inject] public IShoppingListsClient ListsClient { get; set; } = NotNullHelper.Injected<IShoppingListsClient>();

    [Inject] public IShoppingItemsClient ListItemsClient { get; set; } = NotNullHelper.Injected<IShoppingItemsClient>();

    [Inject] public IJSInProcessRuntime JS { get; set; } = NotNullHelper.Injected<IJSInProcessRuntime>();

    public ICollection<ShoppingList> Lists { get; set; } = new List<ShoppingList>();

    private ShoppingList? _selectedList;

    public ShoppingList? SelectedList
    {
        get => _selectedList;
        set
        {
            _selectedList = value;
            StateHasChanged();
        }
    }

    public void SyncList()
    {
        var defaultList = Lists.FirstOrDefault(l => l.Id == SelectedList?.Id);
        if (SelectedList is null) throw new NullReferenceException($"Called {nameof(SyncList)} with null {nameof(SelectedList)}");
        else if (defaultList is null) throw new NullReferenceException($"Called {nameof(SyncList)} with null {nameof(defaultList)}");

        defaultList.Name = SelectedList.Name;

        StateHasChanged();
    }

    public async Task DeleteList()
    {
        var defaultList = Lists.FirstOrDefault(l => l.Id == SelectedList?.Id);
        if (defaultList is null) throw new NullReferenceException($"Called {nameof(DeleteList)} with null {nameof(defaultList)}");

        Lists.Remove(defaultList);

        defaultList = Lists.FirstOrDefault();
        SelectedList = defaultList is not null ? await ListsClient.GetListAsync(defaultList.Id) : default;

        StateHasChanged();
    }

    public bool Initialized { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Lists = await ListsClient.GetListsAsync();
        var selectedListId = Lists.FirstOrDefault()?.Id;
        SelectedList = selectedListId is not null ? await ListsClient.GetListAsync(selectedListId.Value) : default;
        Initialized = true;
    }
}
