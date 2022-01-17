using System.Net.Http.Headers;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace PurchaseNexus.Client.Auth;

public interface IAuthService
{
    Task<AuthenticatedUser> Login(AuthenticationUser userForAuth);
    Task Logout();
}

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ILocalStorageService _localStorage;

    public AuthService(
        HttpClient httpClient,
        AuthenticationStateProvider authStateProvider,
        ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _authStateProvider = authStateProvider;
        _localStorage = localStorage;
    }

    public async Task<AuthenticatedUser> Login(AuthenticationUser userForAuth)
    {
        var data = new FormUrlEncodedContent(
            new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", userForAuth.Email),
                new KeyValuePair<string, string>("password", userForAuth.Password)
            });

        var authResult = await _httpClient.PostAsync("https://localhost:xxxx/token", data);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (!authResult.IsSuccessStatusCode) return null; // whitespace

        var result = System.Text.Json.JsonSerializer.Deserialize<AuthenticatedUser>(
            authContent,
            new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        await _localStorage.SetItemAsync("authToken", result.AccessToken);

        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.AccessToken);

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.AccessToken);

        return result;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}
