using System.Text.Json;
using FoodDeliveryBlazorApp.Features.ErrorHandling.Models;
using Microsoft.Extensions.Logging;

namespace FoodDeliveryBlazorApp.Features.ErrorHandling.Services;

public sealed class MockErrorLogApi(ILogger<MockErrorLogApi> logger) : IErrorLogApi
{
    private const int SimulatedLatencyMs = 400;
    private const string Endpoint = "api/error-logs";

    private static readonly JsonSerializerOptions SerializerOptions = new() { WriteIndented = true };

    public async Task SaveAsync(ErrorLogEntry entry, CancellationToken cancellationToken = default)
    {
        string requestBody = JsonSerializer.Serialize(entry, SerializerOptions);

        logger.LogInformation("Saving error log to DB via POST {Endpoint}{NewLine}{RequestBody}", Endpoint, Environment.NewLine, requestBody);

        await Task.Delay(SimulatedLatencyMs, cancellationToken);
    }
}
