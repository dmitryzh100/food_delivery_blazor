namespace FoodDeliveryBlazorApp.Features.Profile.Models;

public sealed class UserProfile
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string AvatarUrl { get; set; } = "images/avatar.png";
}
