using FoodDeliveryBlazorApp.Features.Auth;
using FoodDeliveryBlazorApp.Features.Auth.Models;
using FoodDeliveryBlazorApp.Features.Profile.Models;

namespace FoodDeliveryBlazorApp.Features.Profile.Services;

public sealed class ProfileService(TokenAuthenticationStateProvider authStateProvider) : IProfileService
{
    private const string DefaultAvatar = "images/avatar.png";

    public async Task<UserProfile> GetProfileAsync()
    {
        AuthUser? user = await authStateProvider.GetCurrentUserAsync();

        return new UserProfile
        {
            FullName = user?.FullName ?? string.Empty,
            Email = user?.Email ?? string.Empty,
            PhoneNumber = user?.PhoneNumber ?? string.Empty,
            AvatarUrl = string.IsNullOrEmpty(user?.AvatarUrl) ? DefaultAvatar : user.AvatarUrl,
        };
    }

    public async Task SaveProfileAsync(UserProfile profile)
    {
        AuthUser user = await authStateProvider.GetCurrentUserAsync() ?? new AuthUser();

        user.FullName = profile.FullName;
        user.Email = profile.Email;
        user.PhoneNumber = profile.PhoneNumber;
        user.AvatarUrl = profile.AvatarUrl == DefaultAvatar ? string.Empty : profile.AvatarUrl;

        await authStateProvider.UpdateUserAsync(user);
    }
}
