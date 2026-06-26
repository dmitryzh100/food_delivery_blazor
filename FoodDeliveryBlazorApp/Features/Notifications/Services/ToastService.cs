using FoodDeliveryBlazorApp.Features.Notifications.Enums;
using FoodDeliveryBlazorApp.Features.Notifications.Models;

namespace FoodDeliveryBlazorApp.Features.Notifications.Services;

public sealed class ToastService : IToastService
{
    public event Action<ToastMessage>? OnShow;

    public void Show(string text, ToastType type)
    {
        OnShow?.Invoke(new ToastMessage(text, type));
    }

    public void ShowSuccess(string text)
    {
        Show(text, ToastType.Success);
    }

    public void ShowError(string text)
    {
        Show(text, ToastType.Error);
    }
}
