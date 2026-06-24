using Microsoft.JSInterop;

namespace FoodDeliveryBlazorApp.Features.Connectivity.Services;

public sealed class ConnectivityService(IJSRuntime jsRuntime) : IConnectivityService, IAsyncDisposable
{
    private DotNetObjectReference<ConnectivityService>? _selfReference;
    private bool _initialized;

    public bool IsOnline { get; private set; } = true;

    public event Action? StatusChanged;

    public async Task InitializeAsync()
    {
        if (_initialized)
        {
            return;
        }

        _initialized = true;
        _selfReference = DotNetObjectReference.Create(this);

        IsOnline = await jsRuntime.InvokeAsync<bool>("connectivity.getStatus");

        await jsRuntime.InvokeVoidAsync("connectivity.initialize", _selfReference);
    }

    [JSInvokable]
    public void OnConnectivityChanged(bool isOnline)
    {
        if (IsOnline == isOnline)
        {
            return;
        }

        IsOnline = isOnline;

        StatusChanged?.Invoke();
    }

    public async ValueTask DisposeAsync()
    {
        if (_initialized)
        {
            try
            {
                await jsRuntime.InvokeVoidAsync("connectivity.dispose");
            }
            catch (JSDisconnectedException)
            {
            }
        }

        _selfReference?.Dispose();
    }
}
