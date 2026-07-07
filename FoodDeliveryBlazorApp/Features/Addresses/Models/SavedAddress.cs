using FoodDeliveryBlazorApp.Features.Addresses.Enums;

namespace FoodDeliveryBlazorApp.Features.Addresses.Models;

public sealed class SavedAddress
{
    public required Guid Id { get; init; }

    public required string TagKey { get; init; }

    public required AddressKind Kind { get; init; }

    public required string Phone { get; init; }

    public required string FullAddress { get; init; }

    public bool IsPrimary { get; set; }
}
