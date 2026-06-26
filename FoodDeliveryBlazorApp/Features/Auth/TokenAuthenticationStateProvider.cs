using System.Security.Claims;
using FoodDeliveryBlazorApp.Features.Auth.Models;
using FoodDeliveryBlazorApp.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace FoodDeliveryBlazorApp.Features.Auth;

public sealed class TokenAuthenticationStateProvider : AuthenticationStateProvider
{
    public const string TokensStorageKey = "foodhub.authTokens";
    public const string UserStorageKey = "foodhub.authUser";

    private const string AuthenticationType = "mockAuth";

    private readonly ILocalStorageService _localStorage;

    public TokenAuthenticationStateProvider(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        AuthTokens? tokens = await _localStorage.GetItemAsync<AuthTokens>(TokensStorageKey);

        if (tokens is null || string.IsNullOrEmpty(tokens.AccessToken))
        {
            return new AuthenticationState(CreateAnonymous());
        }

        AuthUser? user = await _localStorage.GetItemAsync<AuthUser>(UserStorageKey);

        return new AuthenticationState(CreatePrincipal(user));
    }

    public async Task MarkUserAuthenticatedAsync(AuthTokens tokens, AuthUser user)
    {
        await _localStorage.SetItemAsync(TokensStorageKey, tokens);
        await _localStorage.SetItemAsync(UserStorageKey, user);

        ClaimsPrincipal principal = CreatePrincipal(user);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
    }

    public ValueTask<AuthUser?> GetCurrentUserAsync()
    {
        return _localStorage.GetItemAsync<AuthUser>(UserStorageKey);
    }

    public async Task UpdateUserAsync(AuthUser user)
    {
        await _localStorage.SetItemAsync(UserStorageKey, user);

        ClaimsPrincipal principal = CreatePrincipal(user);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
    }

    public async Task MarkUserLoggedOutAsync()
    {
        await _localStorage.RemoveItemAsync(TokensStorageKey);
        await _localStorage.RemoveItemAsync(UserStorageKey);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(CreateAnonymous())));
    }

    private static ClaimsPrincipal CreateAnonymous()
    {
        return new ClaimsPrincipal(new ClaimsIdentity());
    }

    private static ClaimsPrincipal CreatePrincipal(AuthUser? user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, string.IsNullOrWhiteSpace(user?.FullName) ? user?.Email ?? "User" : user.FullName),
            new Claim(ClaimTypes.Email, user?.Email ?? string.Empty),
        };

        ClaimsIdentity identity = new(claims, AuthenticationType);

        return new ClaimsPrincipal(identity);
    }
}
