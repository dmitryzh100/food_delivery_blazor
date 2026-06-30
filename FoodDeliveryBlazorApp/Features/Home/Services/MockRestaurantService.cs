using FoodDeliveryBlazorApp.Features.Home.Enums;
using FoodDeliveryBlazorApp.Features.Home.Models;
using FoodDeliveryBlazorApp.Resources;
using Microsoft.Extensions.Localization;

namespace FoodDeliveryBlazorApp.Features.Home.Services;

public sealed class MockRestaurantService(IStringLocalizer<SharedResource> localizer) : IRestaurantService
{
    private const string Image1 = "images/home/featured_restaurant_1.png";
    private const string Image2 = "images/home/featured_restaurant_2.png";

    public Task<IReadOnlyList<Restaurant>> GetFeaturedAsync()
    {
        IReadOnlyList<Restaurant> featured =
        [
            new Restaurant
            {
                Name = "McDonald's",
                ImageSrc = Image1,
                Rating = 4.5,
                ReviewCount = "25+",
                Delivery = localizer["RestaurantDeliveryFree"],
                DeliveryTime = localizer["RestaurantDeliveryMins", "10-15"],
                Tags = [localizer["FoodBurger"], localizer["FoodChicken"], localizer["FoodFastFood"]],
                Categories = [FoodCategory.Burger],
                IsVerified = true,
                IsFavorite = true,
            },
            new Restaurant
            {
                Name = "Pizza Hut",
                ImageSrc = Image2,
                Rating = 4.7,
                ReviewCount = "99+",
                Delivery = localizer["RestaurantDeliveryPaid", 2],
                DeliveryTime = localizer["RestaurantDeliveryMins", "20-30"],
                Tags = [localizer["FoodPizza"], localizer["FoodPasta"], localizer["FoodItalian"]],
                Categories = [FoodCategory.Pizza],
                IsVerified = true,
            },
            new Restaurant
            {
                Name = "Taco Bell",
                ImageSrc = Image1,
                Rating = 4.3,
                ReviewCount = "75+",
                Delivery = localizer["RestaurantDeliveryPaid", 1],
                DeliveryTime = localizer["RestaurantDeliveryMins", "15-20"],
                Tags = [localizer["FoodMexican"], localizer["FoodTacos"], localizer["FoodFastFood"]],
                Categories = [FoodCategory.Mexican],
                IsFavorite = true,
            },
            new Restaurant
            {
                Name = "Dunkin'",
                ImageSrc = Image2,
                Rating = 4.6,
                ReviewCount = "40+",
                Delivery = localizer["RestaurantDeliveryFree"],
                DeliveryTime = localizer["RestaurantDeliveryMins", "5-10"],
                Tags = [localizer["FoodDonut"], localizer["FoodCoffee"], localizer["FoodBakery"]],
                Categories = [FoodCategory.Donat],
                IsVerified = true,
            },
            new Restaurant
            {
                Name = "Wok Express",
                ImageSrc = Image1,
                Rating = 4.8,
                ReviewCount = "60+",
                Delivery = localizer["RestaurantDeliveryFree"],
                DeliveryTime = localizer["RestaurantDeliveryMins", "20-25"],
                Tags = [localizer["FoodAsian"], localizer["FoodNoodles"], localizer["FoodWok"]],
                Categories = [FoodCategory.Asian],
            },
        ];

        return Task.FromResult(featured);
    }
}
