using FoodDeliveryBlazorApp.Features.Home.Models;

namespace FoodDeliveryBlazorApp.Features.Home.Services;

public interface IRestaurantService
{
    Task<IReadOnlyList<Restaurant>> GetFeaturedAsync();
}
