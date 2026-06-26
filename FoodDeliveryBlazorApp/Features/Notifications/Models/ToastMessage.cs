using FoodDeliveryBlazorApp.Features.Notifications.Enums;

namespace FoodDeliveryBlazorApp.Features.Notifications.Models;

public sealed record ToastMessage(string Text, ToastType Type);
