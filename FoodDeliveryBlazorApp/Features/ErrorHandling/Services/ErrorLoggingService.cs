using System.Collections;
using FoodDeliveryBlazorApp.Features.ErrorHandling.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace FoodDeliveryBlazorApp.Features.ErrorHandling.Services;

public sealed class ErrorLoggingService(
    IErrorLogApi errorLogApi,
    NavigationManager navigation,
    IJSRuntime jsRuntime,
    ILogger<ErrorLoggingService> logger) : IErrorLoggingService
{
    public async Task LogAsync(Exception exception)
    {
        try
        {
            ErrorLogEntry entry = await BuildEntryAsync(exception);

            await errorLogApi.SaveAsync(entry);
        }
        catch (Exception loggingError)
        {
            logger.LogError(loggingError, "Failed to persist application error log.");
        }
    }

    private async Task<ErrorLogEntry> BuildEntryAsync(Exception exception)
    {
        string? userAgent = await TryGetUserAgentAsync();

        return new ErrorLogEntry
        {
            Message = exception.Message,
            ExceptionType = exception.GetType().FullName ?? exception.GetType().Name,
            Source = exception.Source,
            StackTrace = exception.StackTrace,
            HelpLink = exception.HelpLink,
            HResult = exception.HResult,
            InnerException = exception.InnerException?.ToString(),
            Detail = exception.ToString(),
            Data = ExtractData(exception),
            OccurredAtUtc = DateTimeOffset.UtcNow,
            PageUrl = navigation.Uri,
            UserAgent = userAgent,
        };
    }

    private async Task<string?> TryGetUserAgentAsync()
    {
        try
        {
            return await jsRuntime.InvokeAsync<string>("diagnostics.getUserAgent");
        }
        catch (Exception)
        {
            return null;
        }
    }

    private static IReadOnlyDictionary<string, string?> ExtractData(Exception exception)
    {
        Dictionary<string, string?> data = new();

        foreach (DictionaryEntry item in exception.Data)
        {
            string key = item.Key.ToString() ?? string.Empty;
            data[key] = item.Value?.ToString();
        }

        return data;
    }
}
