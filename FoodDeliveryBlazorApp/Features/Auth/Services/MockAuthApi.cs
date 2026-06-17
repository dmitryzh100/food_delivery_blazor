using FoodDeliveryBlazorApp.Features.Auth.Models;
using FoodDeliveryBlazorApp.Services;

namespace FoodDeliveryBlazorApp.Features.Auth.Services;

public sealed class MockAuthApi : IAuthApi
{
    private const int SimulatedLatencyMs = 700;
    private const string AccountsStorageKey = "foodhub.mockAccounts";

    private readonly ILocalStorageService _localStorage;

    public MockAuthApi(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<AuthResult> LoginAsync(LoginModel model)
    {
        await Task.Delay(SimulatedLatencyMs);

        Dictionary<string, MockAccount> accounts = await LoadAccountsAsync();

        if (!accounts.TryGetValue(NormalizeEmail(model.Email), out MockAccount? account) || account.Password != model.Password)
        {
            return AuthResult.Failure("Invalid email or password.");
        }

        AuthUser user = new() { Email = model.Email, FullName = account.FullName };

        return AuthResult.Success(CreateTokens(), user);
    }

    public async Task<AuthResult> SignUpAsync(SignUpModel model)
    {
        await Task.Delay(SimulatedLatencyMs);

        Dictionary<string, MockAccount> accounts = await LoadAccountsAsync();
        string key = NormalizeEmail(model.Email);

        if (accounts.ContainsKey(key))
        {
            return AuthResult.Failure("An account with this email already exists.");
        }

        accounts[key] = new MockAccount { FullName = model.FullName, Password = model.Password };
        await _localStorage.SetItemAsync(AccountsStorageKey, accounts);

        AuthUser user = new() { Email = model.Email, FullName = model.FullName };

        return AuthResult.Success(CreateTokens(), user);
    }

    private async Task<Dictionary<string, MockAccount>> LoadAccountsAsync()
    {
        Dictionary<string, MockAccount>? accounts = await _localStorage.GetItemAsync<Dictionary<string, MockAccount>>(AccountsStorageKey);

        if (accounts is null || accounts.Count == 0)
        {
            return new Dictionary<string, MockAccount>
            {
                ["user@foodhub.com"] = new MockAccount { FullName = "Arlene Mccoy", Password = "password" },
            };
        }

        return accounts;
    }

    private static string NormalizeEmail(string email)
    {
        return email.Trim().ToLowerInvariant();
    }

    private static AuthTokens CreateTokens()
    {
        return new AuthTokens
        {
            AccessToken = $"mock-access-{Guid.NewGuid():N}",
            RefreshToken = $"mock-refresh-{Guid.NewGuid():N}",
        };
    }

    private sealed class MockAccount
    {
        public string FullName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
