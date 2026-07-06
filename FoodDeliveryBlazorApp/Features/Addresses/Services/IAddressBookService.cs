using FoodDeliveryBlazorApp.Features.Addresses.Models;

namespace FoodDeliveryBlazorApp.Features.Addresses.Services;

public interface IAddressBookService
{
    Task<IReadOnlyList<SavedAddress>> GetAddressesAsync();

    Task SetPrimaryAsync(Guid id);

    Task ReorderAsync(IReadOnlyList<Guid> orderedIds);

    Task DeleteAsync(Guid id);
}
