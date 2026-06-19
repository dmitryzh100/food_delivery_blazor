using FoodDeliveryBlazorApp.Features.Home.Models;

namespace FoodDeliveryBlazorApp.Features.Home.Services;

public interface ICategoryService
{
    Task<IReadOnlyList<CategoryChip>> GetCategoriesAsync();
}
