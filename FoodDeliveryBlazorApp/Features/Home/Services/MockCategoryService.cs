using FoodDeliveryBlazorApp.Features.Home.Enums;
using FoodDeliveryBlazorApp.Features.Home.Models;
using FoodDeliveryBlazorApp.Resources;
using Microsoft.Extensions.Localization;

namespace FoodDeliveryBlazorApp.Features.Home.Services;

public sealed class MockCategoryService(IStringLocalizer<SharedResource> localizer) : ICategoryService
{
    public Task<IReadOnlyList<CategoryChip>> GetCategoriesAsync()
    {
        IReadOnlyList<CategoryChip> categories =
        [
            new CategoryChip { Category = FoodCategory.Burger, Label = localizer["FoodBurger"], SpriteSize = "251.1px 188.3px", SpritePosition = "-16.0px -46.1px" },
            new CategoryChip { Category = FoodCategory.Donat, Label = localizer["FoodDonat"], SpriteSize = "409.5px 307.1px", SpritePosition = "-137.5px -187.4px" },
            new CategoryChip { Category = FoodCategory.Pizza, Label = localizer["FoodPizza"], SpriteSize = "382.2px 286.7px", SpritePosition = "-293.2px -170.9px" },
            new CategoryChip { Category = FoodCategory.Mexican, Label = localizer["FoodMexican"], SpriteSize = "369.9px 277.4px", SpritePosition = "-202.9px -85.7px" },
            new CategoryChip { Category = FoodCategory.Asian, Label = localizer["FoodAsian"], SpriteSize = "354.6px 266.0px", SpritePosition = "-266.9px -80.3px" },
        ];

        return Task.FromResult(categories);
    }
}
