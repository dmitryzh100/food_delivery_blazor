using FoodDeliveryBlazorApp.Features.Theming.Enums;
using Microsoft.JSInterop;

namespace FoodDeliveryBlazorApp.Features.Theming.Services;

public sealed class ThemeService(IJSRuntime jsRuntime) : IThemeService
{
    private AppTheme _current = AppTheme.Light;
    private bool _initialized;

    public AppTheme Current => _current;

    public event Action? Changed;

    public async Task InitializeAsync()
    {
        if (_initialized)
        {
            return;
        }

        string resolved = await jsRuntime.InvokeAsync<string>("foodHubTheme.resolveInitial");

        _current = Parse(resolved);
        _initialized = true;

        await jsRuntime.InvokeVoidAsync("foodHubTheme.apply", ToStorageValue(_current));
    }

    public async Task SetThemeAsync(AppTheme theme)
    {
        _initialized = true;

        if (theme == _current)
        {
            return;
        }

        _current = theme;

        string value = ToStorageValue(theme);

        await jsRuntime.InvokeVoidAsync("foodHubTheme.set", value);
        await jsRuntime.InvokeVoidAsync("foodHubTheme.apply", value);

        Changed?.Invoke();
    }

    public async Task ToggleAsync()
    {
        AppTheme next = _current == AppTheme.Dark ? AppTheme.Light : AppTheme.Dark;

        await SetThemeAsync(next);
    }

    private static AppTheme Parse(string? value)
    {
        return string.Equals(value, "dark", StringComparison.OrdinalIgnoreCase)
            ? AppTheme.Dark
            : AppTheme.Light;
    }

    private static string ToStorageValue(AppTheme theme)
    {
        return theme == AppTheme.Dark ? "dark" : "light";
    }
}
