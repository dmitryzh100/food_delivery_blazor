using FoodDeliveryBlazorApp.Features.Home.Enums;

namespace FoodDeliveryBlazorApp.Features.Home.Models;

public sealed record PopularItem
{
    public required string Name { get; init; }

    public required string Description { get; init; }

    public required string ImageSrc { get; init; }

    public required decimal Price { get; init; }

    public required double Rating { get; init; }

    public required string ReviewCount { get; init; }

    public required FoodCategory Category { get; init; }
}
