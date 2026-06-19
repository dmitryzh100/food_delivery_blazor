using FoodDeliveryBlazorApp.Features.Home.Enums;
using FoodDeliveryBlazorApp.Features.Home.Models;

namespace FoodDeliveryBlazorApp.Features.Home.Services;

public sealed class MockCategoryService : ICategoryService
{
    // Positions measured from categories.png (a 4x2 sheet of vivid food icons).
    // Each icon is fitted into the 56px chip viewport, so size/position differ per icon.
    private static readonly IReadOnlyList<CategoryChip> Categories =
    [
        new CategoryChip { Category = FoodCategory.Burger, Label = "Burger", SpriteSize = "251.1px 188.3px", SpritePosition = "-16.0px -46.1px" },
        new CategoryChip { Category = FoodCategory.Donat, Label = "Donat", SpriteSize = "409.5px 307.1px", SpritePosition = "-137.5px -187.4px" },
        new CategoryChip { Category = FoodCategory.Pizza, Label = "Pizza", SpriteSize = "382.2px 286.7px", SpritePosition = "-293.2px -170.9px" },
        new CategoryChip { Category = FoodCategory.Mexican, Label = "Mexican", SpriteSize = "369.9px 277.4px", SpritePosition = "-202.9px -85.7px" },
        new CategoryChip { Category = FoodCategory.Asian, Label = "Asian", SpriteSize = "354.6px 266.0px", SpritePosition = "-266.9px -80.3px" },
    ];

    public Task<IReadOnlyList<CategoryChip>> GetCategoriesAsync()
    {
        return Task.FromResult(Categories);
    }
}
