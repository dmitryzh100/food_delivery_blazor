using Microsoft.JSInterop;

namespace FoodDeliveryBlazorApp.Features.AppUpdate.Services;

public sealed class AppUpdateService(IJSRuntime jsRuntime) : IAppUpdateService, IDisposable
{
    private DotNetObjectReference<AppUpdateService>? _reference;

    public event Action? OnUpdateAvailable;

    public async Task InitializeAsync()
    {
        _reference = DotNetObjectReference.Create(this);

        await jsRuntime.InvokeVoidAsync("foodhubPwa.initialize", _reference);
    }

    public async Task ApplyUpdateAsync()
    {
        await jsRuntime.InvokeVoidAsync("foodhubPwa.applyUpdate");
    }

    [JSInvokable]
    public void NotifyUpdateAvailable()
    {
        OnUpdateAvailable?.Invoke();
    }

    public void Dispose()
    {
        _reference?.Dispose();
    }
}
