namespace FoodDeliveryBlazorApp.Features.Connectivity.Services;

public interface IConnectivityService
{
    bool IsOnline { get; }

    event Action? StatusChanged;

    Task InitializeAsync();
}
