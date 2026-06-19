using FoodDeliveryBlazorApp.Features.Home.Enums;

namespace FoodDeliveryBlazorApp.Features.Home.Models;

public sealed record CategoryChip
{
    public required FoodCategory Category { get; init; }

    public required string Label { get; init; }

    // CSS background-size / background-position that crop this category's icon
    // out of the shared categories.png sprite into the chip's icon viewport.
    public required string SpriteSize { get; init; }

    public required string SpritePosition { get; init; }
}
