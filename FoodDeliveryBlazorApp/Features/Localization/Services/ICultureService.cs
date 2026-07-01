using FoodDeliveryBlazorApp.Features.Localization.Models;

namespace FoodDeliveryBlazorApp.Features.Localization.Services;

public interface ICultureService
{
    IReadOnlyList<LanguageOption> SupportedLanguages { get; }

    LanguageOption Current { get; }

    Task SetCultureAsync(string code);

    Task<bool> SyncLanguageAsync(string? code);
}
