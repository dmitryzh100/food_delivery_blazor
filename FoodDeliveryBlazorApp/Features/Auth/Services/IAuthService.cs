using FoodDeliveryBlazorApp.Features.Auth.Models;

namespace FoodDeliveryBlazorApp.Features.Auth.Services;

public interface IAuthService
{
    Task<AuthResult> LoginAsync(LoginModel model);

    Task<AuthResult> SignUpAsync(SignUpModel model);

    Task LogoutAsync();
}
