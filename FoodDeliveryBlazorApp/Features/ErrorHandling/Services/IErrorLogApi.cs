using FoodDeliveryBlazorApp.Features.ErrorHandling.Models;

namespace FoodDeliveryBlazorApp.Features.ErrorHandling.Services;

public interface IErrorLogApi
{
    Task SaveAsync(ErrorLogEntry entry, CancellationToken cancellationToken = default);
}
