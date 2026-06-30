namespace FoodDeliveryBlazorApp.Features.Localization.Services;

public interface ILanguageApi
{
    Task UpdateLanguageAsync(string email, string languageCode);

    Task<string?> GetLanguageAsync(string email);
}
