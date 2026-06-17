namespace FoodDeliveryBlazorApp.Features.Onboarding.Models;

/// <summary>
/// Visual treatment for the small icons that orbit the onboarding photo.
/// </summary>
public enum OrbitBadgeShape
{
    /// <summary>White rounded-square card holding a brand logo.</summary>
    Logo,

    /// <summary>Circular badge holding a photo thumbnail.</summary>
    Photo
}

/// <summary>
/// How the centre photo is framed inside the grey disc.
/// </summary>
public enum HeroPhotoFit
{
    /// <summary>A person cut-out: full disc width, anchored to the bottom and
    /// clipped along the disc while the head overflows the top.</summary>
    Portrait,

    /// <summary>A free-floating object (e.g. a bowl): centred inside the disc
    /// and allowed to overflow the disc edges.</summary>
    Centered
}

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
