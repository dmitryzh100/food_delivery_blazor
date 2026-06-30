using FoodDeliveryBlazorApp.Services;

namespace FoodDeliveryBlazorApp.Features.Localization.Services;

public sealed class MockLanguageApi : ILanguageApi
{
    private const int SimulatedLatencyMs = 400;
    private const string StorageKey = "foodhub.userLanguages";

    private readonly ILocalStorageService _localStorage;

    public MockLanguageApi(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task UpdateLanguageAsync(string email, string languageCode)
    {
        await Task.Delay(SimulatedLatencyMs);

        Dictionary<string, string> languages = await LoadAsync();
        languages[NormalizeEmail(email)] = languageCode;

        await _localStorage.SetItemAsync(StorageKey, languages);
    }

    public async Task<string?> GetLanguageAsync(string email)
    {
        Dictionary<string, string> languages = await LoadAsync();

        return languages.TryGetValue(NormalizeEmail(email), out string? code) ? code : null;
    }

    private async Task<Dictionary<string, string>> LoadAsync()
    {
        Dictionary<string, string>? languages = await _localStorage.GetItemAsync<Dictionary<string, string>>(StorageKey);

        return languages ?? new Dictionary<string, string>();
    }

    private static string NormalizeEmail(string email)
    {
        return email.Trim().ToLowerInvariant();
    }
}
