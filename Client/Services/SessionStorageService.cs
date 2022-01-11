namespace PurchaseNexus.Client.Services;

public class SessionStorageService
{
    private readonly IJSRuntime _js;
    private readonly IJSInProcessRuntime _jsInProcess;

    public SessionStorageService(IJSRuntime js)
    {
        _js = js;
        _jsInProcess = (IJSInProcessRuntime)_js;
    }

    public async Task<T?> GetItemAsync<T>(string key)
    {
        var json = await _js.InvokeAsync<string>(
            "purchaseNexus.getSessionStorage",
            key);

        return !string.IsNullOrEmpty(json)
                ? System.Text.Json.JsonSerializer.Deserialize<T>(json)
                : default;
    }

    public async Task SetItemAsync<T>(string key, T item)
    {
        await _js.InvokeVoidAsync(
            "purchaseNexus.setSessionStorage",
            key,
            System.Text.Json.JsonSerializer.Serialize(item));
    }

    public void SetItem<T>(string key, T item)
    {
        _jsInProcess.InvokeVoid(
            "purchaseNexus.setSessionStorage",
            key,
            System.Text.Json.JsonSerializer.Serialize(item));
    }
}
