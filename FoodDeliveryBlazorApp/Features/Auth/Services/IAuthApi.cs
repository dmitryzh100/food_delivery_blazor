using FoodDeliveryBlazorApp.Features.Auth.Models;

namespace FoodDeliveryBlazorApp.Features.Auth.Services;

public interface IAuthApi
{
    Task<AuthResult> LoginAsync(LoginModel model);

    Task<AuthResult> SignUpAsync(SignUpModel model);
}
