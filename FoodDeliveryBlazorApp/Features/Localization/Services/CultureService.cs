using System.Globalization;
using FoodDeliveryBlazorApp.Features.Auth;
using FoodDeliveryBlazorApp.Features.Auth.Models;
using FoodDeliveryBlazorApp.Features.Localization.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FoodDeliveryBlazorApp.Features.Localization.Services;

public sealed class CultureService(
    IJSRuntime jsRuntime,
    ILanguageApi languageApi,
    TokenAuthenticationStateProvider authStateProvider,
    NavigationManager navigation) : ICultureService
{
    private static readonly IReadOnlyList<LanguageOption> Supported =
    [
        new LanguageOption("en", "English"),
        new LanguageOption("uk", "Українська"),
        new LanguageOption("fr", "Français"),
    ];

    public IReadOnlyList<LanguageOption> SupportedLanguages => Supported;

    public LanguageOption Current
    {
        get
        {
            string code = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            return Supported.FirstOrDefault(language => language.Code == code) ?? Supported[0];
        }
    }

    public async Task SetCultureAsync(string code)
    {
        if (!IsSupported(code) || code == Current.Code)
        {
            return;
        }

        await jsRuntime.InvokeVoidAsync("blazorCulture.set", code);

        AuthUser? user = await authStateProvider.GetCurrentUserAsync();

        if (user is not null && !string.IsNullOrEmpty(user.Email))
        {
            await languageApi.UpdateLanguageAsync(user.Email, code);

            user.Language = code;
            await authStateProvider.UpdateUserAsync(user);
        }

        navigation.NavigateTo(navigation.Uri, forceLoad: true);
    }

    public async Task<bool> SyncLanguageAsync(string? code)
    {
        if (string.IsNullOrEmpty(code) || !IsSupported(code) || code == Current.Code)
        {
            return false;
        }

        await jsRuntime.InvokeVoidAsync("blazorCulture.set", code);

        return true;
    }

    private static bool IsSupported(string code)
    {
        return Supported.Any(language => language.Code == code);
    }
}
