using FoodDeliveryBlazorApp.Features.Home.Models;

namespace FoodDeliveryBlazorApp.Features.Home.Services;

public interface IPopularItemService
{
    Task<IReadOnlyList<PopularItem>> GetPopularAsync();
}
