using FoodDeliveryBlazorApp.Features.Home.Enums;
using FoodDeliveryBlazorApp.Features.Home.Models;

namespace FoodDeliveryBlazorApp.Features.Home.Services;

public sealed class MockPopularItemService : IPopularItemService
{
    private static readonly IReadOnlyList<PopularItem> Items =
    [
        new PopularItem
        {
            Name = "Pepperoni pizza",
            Description = "double cheese & pepperoni",
            ImageSrc = "images/home/food_1.jpg",
            Price = 9.50m,
            Rating = 4.7,
            ReviewCount = "120+",
            Category = FoodCategory.Pizza,
        },
        new PopularItem
        {
            Name = "Creamy pasta",
            Description = "parmesan & herbs",
            ImageSrc = "images/home/food_2.jpg",
            Price = 8.25m,
            Rating = 4.5,
            ReviewCount = "60+",
            Category = FoodCategory.Asian,
        },
        new PopularItem
        {
            Name = "Caprese salad",
            Description = "tomato & mozzarella",
            ImageSrc = "images/home/food_3.jpg",
            Price = 7.50m,
            Rating = 4.4,
            ReviewCount = "45+",
            Category = FoodCategory.Mexican,
        },
        new PopularItem
        {
            Name = "Spaghetti bolognese",
            Description = "rich tomato & beef",
            ImageSrc = "images/home/food_4.jpg",
            Price = 7.25m,
            Rating = 4.6,
            ReviewCount = "80+",
            Category = FoodCategory.Mexican,
        },
        new PopularItem
        {
            Name = "Grilled steak",
            Description = "chimichurri & herbs",
            ImageSrc = "images/home/food_5.jpg",
            Price = 6.95m,
            Rating = 4.3,
            ReviewCount = "30+",
            Category = FoodCategory.Burger,
        },
        new PopularItem
        {
            Name = "Chicken noodles",
            Description = "wok tossed in soy",
            ImageSrc = "images/home/popular_item_1.png",
            Price = 8.75m,
            Rating = 4.6,
            ReviewCount = "70+",
            Category = FoodCategory.Asian,
        },
        new PopularItem
        {
            Name = "Berry delight",
            Description = "vanilla & fresh berries",
            ImageSrc = "images/home/popular_item_2.png",
            Price = 5.50m,
            Rating = 4.8,
            ReviewCount = "90+",
            Category = FoodCategory.Donat,
        },
    ];

    public Task<IReadOnlyList<PopularItem>> GetPopularAsync()
    {
        return Task.FromResult(Items);
    }
}
