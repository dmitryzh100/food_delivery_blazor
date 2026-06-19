using FoodDeliveryBlazorApp.Features.Home.Enums;
using FoodDeliveryBlazorApp.Features.Home.Models;

namespace FoodDeliveryBlazorApp.Features.Home.Services;

public sealed class MockRestaurantService : IRestaurantService
{
    private const string Image1 = "images/home/featured_restaurant_1.png";
    private const string Image2 = "images/home/featured_restaurant_2.png";

    private static readonly IReadOnlyList<Restaurant> Featured =
    [
        new Restaurant
        {
            Name = "McDonald's",
            ImageSrc = Image1,
            Rating = 4.5,
            ReviewCount = "25+",
            Delivery = "free delivery",
            DeliveryTime = "10-15 mins",
            Tags = ["Burger", "Chicken", "Fast food"],
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
            Delivery = "$2 delivery",
            DeliveryTime = "20-30 mins",
            Tags = ["Pizza", "Pasta", "Italian"],
            Categories = [FoodCategory.Pizza],
            IsVerified = true,
        },
        new Restaurant
        {
            Name = "Taco Bell",
            ImageSrc = Image1,
            Rating = 4.3,
            ReviewCount = "75+",
            Delivery = "$1 delivery",
            DeliveryTime = "15-20 mins",
            Tags = ["Mexican", "Tacos", "Fast food"],
            Categories = [FoodCategory.Mexican],
            IsFavorite = true,
        },
        new Restaurant
        {
            Name = "Dunkin'",
            ImageSrc = Image2,
            Rating = 4.6,
            ReviewCount = "40+",
            Delivery = "free delivery",
            DeliveryTime = "5-10 mins",
            Tags = ["Donut", "Coffee", "Bakery"],
            Categories = [FoodCategory.Donat],
            IsVerified = true,
        },
        new Restaurant
        {
            Name = "Wok Express",
            ImageSrc = Image1,
            Rating = 4.8,
            ReviewCount = "60+",
            Delivery = "free delivery",
            DeliveryTime = "20-25 mins",
            Tags = ["Asian", "Noodles", "Wok"],
            Categories = [FoodCategory.Asian],
        },
    ];

    public Task<IReadOnlyList<Restaurant>> GetFeaturedAsync()
    {
        return Task.FromResult(Featured);
    }
}
