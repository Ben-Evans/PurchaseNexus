namespace PurchaseNexus.Client.Pages.Todo;

public partial class TodoState
{
    [Parameter] public RenderFragment ChildContent { get; set; } = NotNullHelper.Param<RenderFragment>();

    [Inject] public ITodoListsClient TodoListsClient { get; set; } = NotNullHelper.Injected<ITodoListsClient>();

    [Inject] public ITodoItemsClient TodoItemsClient { get; set; } = NotNullHelper.Injected<ITodoItemsClient>();

    [Inject] public IJSInProcessRuntime JS { get; set; } = NotNullHelper.Injected<IJSInProcessRuntime>();

    public ICollection<TodoList> TodoLists { get; set; } = new List<TodoList>();

    private TodoList? _selectedList;

    public TodoList? SelectedList
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
        var defaultTodoList = TodoLists.FirstOrDefault(l => l.Id == SelectedList?.Id);
        if (SelectedList is null) throw new NullReferenceException($"Called {nameof(SyncList)} with null {nameof(SelectedList)}");
        else if (defaultTodoList is null) throw new NullReferenceException($"Called {nameof(SyncList)} with null {nameof(defaultTodoList)}");

        defaultTodoList.Title = SelectedList.Title;

        StateHasChanged();
    }

    public async Task DeleteList()
    {
        var defaultTodoList = TodoLists.FirstOrDefault(l => l.Id == SelectedList?.Id);
        if (defaultTodoList is null) throw new NullReferenceException($"Called {nameof(DeleteList)} with null {nameof(defaultTodoList)}");

        TodoLists.Remove(defaultTodoList);

        defaultTodoList = TodoLists.FirstOrDefault();
        SelectedList = defaultTodoList is not null ? await TodoListsClient.GetTodoListAsync(defaultTodoList.Id) : default;

        StateHasChanged();
    }

    public bool Initialized { get; set; }

    protected override async Task OnInitializedAsync()
    {
        TodoLists = await TodoListsClient.GetTodoListsAsync();
        var selectedListId = TodoLists.FirstOrDefault()?.Id;
        SelectedList = selectedListId is not null ? await TodoListsClient.GetTodoListAsync(selectedListId.Value) : default;
        Initialized = true;
    }
}
