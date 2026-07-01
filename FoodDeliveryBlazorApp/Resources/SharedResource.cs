using System.Globalization;
using System.Resources;

namespace FoodDeliveryBlazorApp.Resources;

public sealed class SharedResource
{
    private static readonly ResourceManager Manager =
        new("FoodDeliveryBlazorApp.Resources.SharedResource", typeof(SharedResource).Assembly);

    public static string ValidationFullNameRequired => Resolve(nameof(ValidationFullNameRequired));

    public static string ValidationFullNameMinLength => Resolve(nameof(ValidationFullNameMinLength));

    public static string ValidationEmailRequired => Resolve(nameof(ValidationEmailRequired));

    public static string ValidationEmailInvalid => Resolve(nameof(ValidationEmailInvalid));

    public static string ValidationPasswordRequired => Resolve(nameof(ValidationPasswordRequired));

    public static string ValidationPasswordMinLength => Resolve(nameof(ValidationPasswordMinLength));

    private static string Resolve(string key)
    {
        return Manager.GetString(key, CultureInfo.CurrentUICulture) ?? key;
    }
}
