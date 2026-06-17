using FoodDeliveryBlazorApp.Features.Auth.Models;

namespace FoodDeliveryBlazorApp.Features.Auth.Services;

public sealed class AuthService(IAuthApi authApi, TokenAuthenticationStateProvider authStateProvider) : IAuthService
{
    public async Task<AuthResult> LoginAsync(LoginModel model)
    {
        AuthResult result = await authApi.LoginAsync(model);

        await PersistOnSuccessAsync(result);

        return result;
    }

    public async Task<AuthResult> SignUpAsync(SignUpModel model)
    {
        AuthResult result = await authApi.SignUpAsync(model);

        await PersistOnSuccessAsync(result);

        return result;
    }

    public async Task LogoutAsync()
    {
        await authStateProvider.MarkUserLoggedOutAsync();
    }

    private async Task PersistOnSuccessAsync(AuthResult result)
    {
        if (result is { Succeeded: true, Tokens: not null, User: not null })
        {
            await authStateProvider.MarkUserAuthenticatedAsync(result.Tokens, result.User);
        }
    }
}
