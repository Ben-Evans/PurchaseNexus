namespace PurchaseNexus.Client.Pages.Todo;

public partial class TodoLists
{
    [CascadingParameter] public TodoState State { get; set; } = NotNullHelper.CascadingParam<TodoState>();

    private ElementReference _titleInput;

    private ElementReference _newListModal;

    private TodoList _newTodoList = new (string.Empty);

    private CustomValidation _customValidation = NotNullHelper.Ref<CustomValidation>();

    private async Task NewList()
    {
        _newTodoList = new TodoList(string.Empty);

        await Task.Delay(500);

        if (_titleInput.Context != null)
        {
            await _titleInput.FocusAsync();
        }
    }

    private async Task CreateNewList()
    {
        _customValidation.ClearErrors();

        try
        {
            var list = await State.TodoListsClient.PostTodoListAsync(_newTodoList);

            State.TodoLists.Add(list);

            await SelectList(list);

            State.JS.InvokeVoid(JsInteropConstants.HideModal, _newListModal);
        }
        catch (ApiException ex)
        {
            var problemDetails = JsonConvert.DeserializeObject<ValidationProblemDetails>(ex.Response);

            if (problemDetails != null)
            {
                _customValidation.DisplayErrors(problemDetails.Errors);
            }
        }

    }

    private bool IsSelected(TodoList list) => State.SelectedList?.Id == list.Id;

    private async Task SelectList(TodoList list)
    {
        if (IsSelected(list)) return;

        State.SelectedList = await State.TodoListsClient.GetTodoListAsync(list.Id);
    }
}
