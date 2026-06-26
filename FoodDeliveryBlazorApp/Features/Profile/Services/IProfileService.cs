using FoodDeliveryBlazorApp.Features.Profile.Models;

namespace FoodDeliveryBlazorApp.Features.Profile.Services;

public interface IProfileService
{
    Task<UserProfile> GetProfileAsync();

    Task SaveProfileAsync(UserProfile profile);
}
