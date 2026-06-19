using FoodDeliveryBlazorApp.Features.Home.Models;

namespace FoodDeliveryBlazorApp.Features.Home.Services;

public interface IAddressService
{
    Task<IReadOnlyList<DeliveryAddress>> GetAddressesAsync();
}
