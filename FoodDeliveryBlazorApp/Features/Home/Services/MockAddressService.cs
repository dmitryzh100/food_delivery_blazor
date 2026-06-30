using FoodDeliveryBlazorApp.Features.Home.Models;
using FoodDeliveryBlazorApp.Resources;
using Microsoft.Extensions.Localization;

namespace FoodDeliveryBlazorApp.Features.Home.Services;

public sealed class MockAddressService(IStringLocalizer<SharedResource> localizer) : IAddressService
{
    public Task<IReadOnlyList<DeliveryAddress>> GetAddressesAsync()
    {
        IReadOnlyList<DeliveryAddress> addresses =
        [
            new DeliveryAddress { Tag = localizer["AddressTagHome"], FullAddress = "4102 Pretty View Lane" },
            new DeliveryAddress { Tag = localizer["AddressTagWork"], FullAddress = "23 Halloway Road, Suite 5" },
            new DeliveryAddress { Tag = localizer["AddressTagGym"], FullAddress = "768 Sunset Boulevard" },
        ];

        return Task.FromResult(addresses);
    }
}
