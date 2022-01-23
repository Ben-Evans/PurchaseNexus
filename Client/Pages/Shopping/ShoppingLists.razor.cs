namespace PurchaseNexus.Client.Pages.Shopping;

public partial class ShoppingLists
{
    [CascadingParameter] public ShoppingState State { get; set; } = NotNullHelper.CascadingParam<ShoppingState>();

    private ElementReference _listNameInput;

    private ElementReference _newListModal;

    private ShoppingList _newList = new (string.Empty);

    private CustomValidation _customValidation = NotNullHelper.Ref<CustomValidation>();

    private async Task NewList()
    {
        _newList = new(string.Empty);

        await Task.Delay(500);

        if (_listNameInput.Context != null)
        {
            await _listNameInput.FocusAsync();
        }
    }

    private async Task CreateNewList()
    {
        _customValidation.ClearErrors();

        try
        {
            var list = await State.ListsClient.PostListAsync(_newList);

            State.Lists.Add(list);

            await SelectList(list);

            State.JS.InvokeVoid(JsInteropConstants.HideModal, _newListModal);
        }
        catch (ApiException ex)
        {
            var problemDetails = JsonConvert.DeserializeObject<ValidationProblemDetails>(ex.Response);

            if (problemDetails is not null)
            {
                _customValidation.DisplayErrors(problemDetails.Errors);
            }
        }

    }

    private bool IsSelected(ShoppingList list) => State.SelectedList?.Id == list.Id;

    private async Task SelectList(ShoppingList list)
    {
        if (IsSelected(list)) return; // No need to re-select already selected list

        State.SelectedList = await State.ListsClient.GetListAsync(list.Id);
    }
}
