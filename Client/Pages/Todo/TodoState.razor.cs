namespace PurchaseNexus.Client.Pages.Todo;

public partial class TodoState
{
    [Parameter] public RenderFragment ChildContent { get; set; }

    [Inject] public ITodoListsClient TodoListsClient { get; set; } = NotNullHelper.Injected<ITodoListsClient>();

    [Inject] public ITodoItemsClient TodoItemsClient { get; set; } = NotNullHelper.Injected<ITodoItemsClient>();

    [Inject] public IJSInProcessRuntime JS { get; set; } = NotNullHelper.Injected<IJSInProcessRuntime>();

    public ICollection<TodoList> TodoLists { get; set; } = new List<TodoList>();

    private TodoList _selectedList = NotNullHelper.OnInit<TodoList>();

    public TodoList SelectedList
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
        var list = TodoLists.First(l => l.Id == SelectedList.Id);

        list.Title = SelectedList.Title;

        StateHasChanged();
    }

    public async Task DeleteList()
    {
        var list = TodoLists.First(l => l.Id == SelectedList.Id);

        TodoLists.Remove(list);

        SelectedList = await TodoListsClient.GetTodoListAsync(TodoLists.First().Id);

        StateHasChanged();
    }

    public bool Initialised { get; set; }

    protected override async Task OnInitializedAsync()
    {
        TodoLists = await TodoListsClient.GetTodoListsAsync();
        SelectedList = await TodoListsClient.GetTodoListAsync(TodoLists.First().Id);
        Initialised = true;
    }
}
