using FoodDeliveryBlazorApp.Features.Notifications.Enums;
using FoodDeliveryBlazorApp.Features.Notifications.Models;

namespace FoodDeliveryBlazorApp.Features.Notifications.Services;

public interface IToastService
{
    event Action<ToastMessage>? OnShow;

    void Show(string text, ToastType type);

    void ShowSuccess(string text);

    void ShowError(string text);
}
