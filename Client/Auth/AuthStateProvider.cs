﻿using System.Net.Http.Headers;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace PurchaseNexus.Client.Auth;

public class AuthStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationState _anonymous;

    public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");

        if (string.IsNullOrWhiteSpace(token)) return _anonymous;

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

        var claimsIdentity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType");
        var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
        return new AuthenticationState(claimsPrinciple);
    }

    public void NotifyUserAuthentication(string token)
    {
        var claimsIdentity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType");
        var authenticatedUser = new ClaimsPrincipal(claimsIdentity);
        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        NotifyAuthenticationStateChanged(authState);
    }

    public void NotifyUserLogout()
    {
        var authState = Task.FromResult(_anonymous);
        NotifyAuthenticationStateChanged(authState);
    }
}
