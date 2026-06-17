using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryBlazorApp.Features.Auth.Models;

public sealed class SignUpModel
{
    [Required(ErrorMessage = "Full name is required")]
    [MinLength(2, ErrorMessage = "Enter your full name")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Enter a valid email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = string.Empty;
}
