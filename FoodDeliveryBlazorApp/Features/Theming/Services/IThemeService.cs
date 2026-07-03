using FoodDeliveryBlazorApp.Features.Theming.Enums;

namespace FoodDeliveryBlazorApp.Features.Theming.Services;

public interface IThemeService
{
    AppTheme Current { get; }

    event Action? Changed;

    Task InitializeAsync();

    Task SetThemeAsync(AppTheme theme);

    Task ToggleAsync();
}
