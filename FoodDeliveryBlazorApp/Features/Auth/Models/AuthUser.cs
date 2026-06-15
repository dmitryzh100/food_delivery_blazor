namespace FoodDeliveryBlazorApp.Features.Auth.Models;

public sealed class AuthUser
{
    public string Email { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;
}
