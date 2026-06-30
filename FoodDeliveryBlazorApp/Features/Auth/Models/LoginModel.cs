using System.ComponentModel.DataAnnotations;
using FoodDeliveryBlazorApp.Resources;

namespace FoodDeliveryBlazorApp.Features.Auth.Models;

public sealed class LoginModel
{
    [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationEmailRequired))]
    [EmailAddress(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationEmailInvalid))]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationPasswordRequired))]
    [MinLength(6, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = nameof(SharedResource.ValidationPasswordMinLength))]
    public string Password { get; set; } = string.Empty;
}
