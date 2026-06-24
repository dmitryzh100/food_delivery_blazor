namespace FoodDeliveryBlazorApp.Features.ErrorHandling.Services;

public interface IErrorLoggingService
{
    Task LogAsync(Exception exception);
}
