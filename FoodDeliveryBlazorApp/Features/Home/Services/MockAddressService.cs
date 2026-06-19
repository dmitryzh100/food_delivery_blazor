using FoodDeliveryBlazorApp.Features.Home.Models;

namespace FoodDeliveryBlazorApp.Features.Home.Services;

public sealed class MockAddressService : IAddressService
{
    private static readonly IReadOnlyList<DeliveryAddress> Addresses =
    [
        new DeliveryAddress { Tag = "Home", FullAddress = "4102 Pretty View Lane" },
        new DeliveryAddress { Tag = "Work", FullAddress = "23 Halloway Road, Suite 5" },
        new DeliveryAddress { Tag = "Gym", FullAddress = "768 Sunset Boulevard" },
    ];

    public Task<IReadOnlyList<DeliveryAddress>> GetAddressesAsync()
    {
        return Task.FromResult(Addresses);
    }
}
