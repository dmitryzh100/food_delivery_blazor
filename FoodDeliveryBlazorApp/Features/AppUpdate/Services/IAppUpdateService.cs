namespace FoodDeliveryBlazorApp.Features.AppUpdate.Services;

public interface IAppUpdateService
{
    event Action? OnUpdateAvailable;

    Task InitializeAsync();

    Task ApplyUpdateAsync();
}
