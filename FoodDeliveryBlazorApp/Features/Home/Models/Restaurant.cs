using FoodDeliveryBlazorApp.Features.Home.Enums;

namespace FoodDeliveryBlazorApp.Features.Home.Models;

public sealed record Restaurant
{
    public required string Name { get; init; }

    public required string ImageSrc { get; init; }

    public required double Rating { get; init; }

    public required string ReviewCount { get; init; }

    public required string Delivery { get; init; }

    public required string DeliveryTime { get; init; }

    public required IReadOnlyList<string> Tags { get; init; }

    public required IReadOnlyList<FoodCategory> Categories { get; init; }

    public bool IsVerified { get; init; }

    public bool IsFavorite { get; init; }
}
