namespace FoodDeliveryBlazorApp.Features.Onboarding.Enums;

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
