namespace FoodDeliveryBlazorApp.Features.Auth.Models;

public sealed class AuthResult
{
    public bool Succeeded { get; init; }

    public string? Error { get; init; }

    public AuthTokens? Tokens { get; init; }

    public AuthUser? User { get; init; }

    public static AuthResult Success(AuthTokens tokens, AuthUser user)
    {
        return new AuthResult
        {
            Succeeded = true,
            Tokens = tokens,
            User = user,
        };
    }

    public static AuthResult Failure(string error)
    {
        return new AuthResult
        {
            Succeeded = false,
            Error = error,
        };
    }
}
