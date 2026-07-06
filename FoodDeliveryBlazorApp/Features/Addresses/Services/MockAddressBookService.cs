using FoodDeliveryBlazorApp.Features.Addresses.Enums;
using FoodDeliveryBlazorApp.Features.Addresses.Models;

namespace FoodDeliveryBlazorApp.Features.Addresses.Services;

public sealed class MockAddressBookService : IAddressBookService
{
    private readonly List<SavedAddress> _addresses =
    [
        new SavedAddress
        {
            Id = Guid.NewGuid(),
            TagKey = "AddressTagHome",
            Kind = AddressKind.Home,
            Phone = "542-154-5184",
            FullAddress = "4261 Kembery Drive, Chicago, LSA",
            IsPrimary = true,
        },
        new SavedAddress
        {
            Id = Guid.NewGuid(),
            TagKey = "AddressTagOffice",
            Kind = AddressKind.Office,
            Phone = "610-092-3371",
            FullAddress = "88 Halloway Road, Suite 5, Chicago",
            IsPrimary = false,
        },
        new SavedAddress
        {
            Id = Guid.NewGuid(),
            TagKey = "AddressTagOther",
            Kind = AddressKind.Other,
            Phone = "415-233-7788",
            FullAddress = "768 Sunset Boulevard, Los Angeles",
            IsPrimary = false,
        },
    ];

    public Task<IReadOnlyList<SavedAddress>> GetAddressesAsync()
    {
        IReadOnlyList<SavedAddress> snapshot = _addresses.ToList();

        return Task.FromResult(snapshot);
    }

    public Task SetPrimaryAsync(Guid id)
    {
        SavedAddress? target = _addresses.FirstOrDefault(address => address.Id == id);

        if (target is not null)
        {
            _addresses.Remove(target);
            _addresses.Insert(0, target);

            MarkPrimary();
        }

        return Task.CompletedTask;
    }

    public Task ReorderAsync(IReadOnlyList<Guid> orderedIds)
    {
        List<SavedAddress> reordered = orderedIds
            .Select(id => _addresses.FirstOrDefault(address => address.Id == id))
            .OfType<SavedAddress>()
            .ToList();

        if (reordered.Count != _addresses.Count)
        {
            return Task.CompletedTask;
        }

        _addresses.Clear();
        _addresses.AddRange(reordered);

        MarkPrimary();

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        SavedAddress? target = _addresses.FirstOrDefault(address => address.Id == id);

        if (target is not null)
        {
            _addresses.Remove(target);

            MarkPrimary();
        }

        return Task.CompletedTask;
    }

    private void MarkPrimary()
    {
        for (int index = 0; index < _addresses.Count; index++)
        {
            _addresses[index].IsPrimary = index == 0;
        }
    }
}
