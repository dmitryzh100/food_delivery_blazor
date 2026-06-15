using FoodDeliveryBlazorApp.Features.Auth.Models;

namespace FoodDeliveryBlazorApp.Features.Auth.Services;

public sealed class AuthService : IAuthService
{
    private readonly IAuthApi _authApi;
    private readonly TokenAuthenticationStateProvider _authStateProvider;

    public AuthService(IAuthApi authApi, TokenAuthenticationStateProvider authStateProvider)
    {
        _authApi = authApi;
        _authStateProvider = authStateProvider;
    }

    public async Task<AuthResult> LoginAsync(LoginModel model)
    {
        AuthResult result = await _authApi.LoginAsync(model);

        await PersistOnSuccessAsync(result);

        return result;
    }

    public async Task<AuthResult> SignUpAsync(SignUpModel model)
    {
        AuthResult result = await _authApi.SignUpAsync(model);

        await PersistOnSuccessAsync(result);

        return result;
    }

    public async Task LogoutAsync()
    {
        await _authStateProvider.MarkUserLoggedOutAsync();
    }

    private async Task PersistOnSuccessAsync(AuthResult result)
    {
        if (result is { Succeeded: true, Tokens: not null, User: not null })
        {
            await _authStateProvider.MarkUserAuthenticatedAsync(result.Tokens, result.User);
        }
    }
}
