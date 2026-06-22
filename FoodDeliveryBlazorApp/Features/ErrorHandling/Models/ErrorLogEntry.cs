namespace FoodDeliveryBlazorApp.Features.ErrorHandling.Models;

public sealed class ErrorLogEntry
{
    public string Message { get; init; } = string.Empty;

    public string ExceptionType { get; init; } = string.Empty;

    public string? Source { get; init; }

    public string? StackTrace { get; init; }

    public string? HelpLink { get; init; }

    public int HResult { get; init; }

    public string? InnerException { get; init; }

    public string Detail { get; init; } = string.Empty;

    public IReadOnlyDictionary<string, string?> Data { get; init; } = new Dictionary<string, string?>();

    public DateTimeOffset OccurredAtUtc { get; init; }

    public string? PageUrl { get; init; }

    public string? UserAgent { get; init; }
}
