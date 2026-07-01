using FoodDeliveryBlazorApp.Features.Home.Enums;
using FoodDeliveryBlazorApp.Features.Home.Models;
using FoodDeliveryBlazorApp.Resources;
using Microsoft.Extensions.Localization;

namespace FoodDeliveryBlazorApp.Features.Home.Services;

public sealed class MockPopularItemService(IStringLocalizer<SharedResource> localizer) : IPopularItemService
{
    public Task<IReadOnlyList<PopularItem>> GetPopularAsync()
    {
        IReadOnlyList<PopularItem> items =
        [
            new PopularItem
            {
                Name = localizer["ItemPepperoniPizzaName"],
                Description = localizer["ItemPepperoniPizzaDesc"],
                ImageSrc = "images/home/food_1.jpg",
                Price = 9.50m,
                Rating = 4.7,
                ReviewCount = "120+",
                Category = FoodCategory.Pizza,
            },
            new PopularItem
            {
                Name = localizer["ItemCreamyPastaName"],
                Description = localizer["ItemCreamyPastaDesc"],
                ImageSrc = "images/home/food_2.jpg",
                Price = 8.25m,
                Rating = 4.5,
                ReviewCount = "60+",
                Category = FoodCategory.Asian,
            },
            new PopularItem
            {
                Name = localizer["ItemCapreseSaladName"],
                Description = localizer["ItemCapreseSaladDesc"],
                ImageSrc = "images/home/food_3.jpg",
                Price = 7.50m,
                Rating = 4.4,
                ReviewCount = "45+",
                Category = FoodCategory.Mexican,
            },
            new PopularItem
            {
                Name = localizer["ItemSpaghettiBologneseName"],
                Description = localizer["ItemSpaghettiBologneseDesc"],
                ImageSrc = "images/home/food_4.jpg",
                Price = 7.25m,
                Rating = 4.6,
                ReviewCount = "80+",
                Category = FoodCategory.Mexican,
            },
            new PopularItem
            {
                Name = localizer["ItemGrilledSteakName"],
                Description = localizer["ItemGrilledSteakDesc"],
                ImageSrc = "images/home/food_5.jpg",
                Price = 6.95m,
                Rating = 4.3,
                ReviewCount = "30+",
                Category = FoodCategory.Burger,
            },
            new PopularItem
            {
                Name = localizer["ItemChickenNoodlesName"],
                Description = localizer["ItemChickenNoodlesDesc"],
                ImageSrc = "images/home/popular_item_1.png",
                Price = 8.75m,
                Rating = 4.6,
                ReviewCount = "70+",
                Category = FoodCategory.Asian,
            },
            new PopularItem
            {
                Name = localizer["ItemBerryDelightName"],
                Description = localizer["ItemBerryDelightDesc"],
                ImageSrc = "images/home/popular_item_2.png",
                Price = 5.50m,
                Rating = 4.8,
                ReviewCount = "90+",
                Category = FoodCategory.Donat,
            },
        ];

        return Task.FromResult(items);
    }
}
