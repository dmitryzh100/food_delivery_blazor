namespace FoodDeliveryBlazorApp.Features.Home.Models;

public sealed record DeliveryAddress
{
    public required string Tag { get; init; }

    public required string FullAddress { get; init; }
}
