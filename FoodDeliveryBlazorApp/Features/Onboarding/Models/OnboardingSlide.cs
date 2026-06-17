using FoodDeliveryBlazorApp.Features.Onboarding.Enums;

namespace FoodDeliveryBlazorApp.Features.Onboarding.Models;

/// <summary>
/// A single step of the onboarding carousel: the hero photo, the orbiting
/// icons composed around it and the marketing copy shown underneath.
/// </summary>
public sealed record OnboardingSlide
{
    public required int Index { get; init; }

    public required string Photo { get; init; }

    public required string PhotoAlt { get; init; }

    public required string Title { get; init; }

    public required string Subtitle { get; init; }

    public required OrbitBadgeShape BadgeShape { get; init; }

    public HeroPhotoFit PhotoFit { get; init; } = HeroPhotoFit.Portrait;

    public required IReadOnlyList<string> Icons { get; init; }
}
