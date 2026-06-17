using System.Text.Json;
using Microsoft.JSInterop;

namespace FoodDeliveryBlazorApp.Services;

public sealed class LocalStorageService : ILocalStorageService
{
    private readonly IJSRuntime _jsRuntime;

    public LocalStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async ValueTask SetItemAsync<T>(string key, T value)
    {
        string json = JsonSerializer.Serialize(value);

        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, json);
    }

    public async ValueTask<T?> GetItemAsync<T>(string key)
    {
        string? json = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", key);

        if (string.IsNullOrEmpty(json))
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(json);
    }

    public async ValueTask RemoveItemAsync(string key)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
    }
}
