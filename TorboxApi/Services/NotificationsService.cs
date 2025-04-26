using System.Net.Http.Json;
using TorboxApi.Http;
using TorboxApi.Http.Exceptions;
using TorboxApi.Http.Extensions;
using TorboxApi.Http.Serialization;
using TorboxApi.Models;
using TorboxApi.Validation;
using TorboxApi.Validation.Extensions;

namespace TorboxApi.Services;

public class NotificationsService : BaseService
{
    internal NotificationsService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>
    /// ### Overview
    ///
    /// Gets your notifications in an RSS Feed which allows you to use them with RSS Feed readers or notification services that can take RSS Feeds and listen to updates. As soon as a notification goes to your account, it will be added to your feed.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using as a query parameter using the `token` key.
    /// </summary>
    public async Task<string> GetRssNotificationFeedAsync(
        string apiVersion,
        string? token = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(apiVersion, nameof(apiVersion));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var apiVersionValidationResult = new StringValidator().ValidateRequired<string?>(
            (string?)apiVersion
        );
        if (apiVersionValidationResult != null)
        {
            validationResults.Add(apiVersionValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/notifications/rss")
            .SetPathParameter("api_version", apiVersion)
            .SetOptionalQueryParameter("token", token)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>
    /// ### Overview
    ///
    /// Gets your notifications in a JSON object that is easily parsable compared to the RSS Feed. Gives all the same data as the RSS Feed.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task<GetNotificationFeedOkResponse> GetNotificationFeedAsync(
        string apiVersion,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(apiVersion, nameof(apiVersion));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var apiVersionValidationResult = new StringValidator().ValidateRequired<string?>(
            (string?)apiVersion
        );
        if (apiVersionValidationResult != null)
        {
            validationResults.Add(apiVersionValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(
            HttpMethod.Get,
            "{api_version}/api/notifications/mynotifications"
        )
            .SetPathParameter("api_version", apiVersion)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetNotificationFeedOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>
    /// ### Overview
    ///
    /// Marks all of your notifications as read and deletes them permanently.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task ClearAllNotificationsAsync(
        string apiVersion,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(apiVersion, nameof(apiVersion));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var apiVersionValidationResult = new StringValidator().ValidateRequired<string?>(
            (string?)apiVersion
        );
        if (apiVersionValidationResult != null)
        {
            validationResults.Add(apiVersionValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(HttpMethod.Post, "{api_version}/api/notifications/clear")
            .SetPathParameter("api_version", apiVersion)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessfulResponse();
    }

    /// <summary>
    /// ### Overview
    ///
    /// Marks a single notification as read and permanently deletes it from your notifications. Requires a `notification_id` which can be found by getting your notification feed.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task ClearSingleNotificationAsync(
        string apiVersion,
        string notificationId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(apiVersion, nameof(apiVersion));
        ArgumentNullException.ThrowIfNull(notificationId, nameof(notificationId));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var apiVersionValidationResult = new StringValidator().ValidateRequired<string?>(
            (string?)apiVersion
        );
        if (apiVersionValidationResult != null)
        {
            validationResults.Add(apiVersionValidationResult);
        }
        ;
        var notificationIdValidationResult = new StringValidator().ValidateRequired<string?>(
            (string?)notificationId
        );
        if (notificationIdValidationResult != null)
        {
            validationResults.Add(notificationIdValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(
            HttpMethod.Post,
            "{api_version}/api/notifications/clear/{notification_id}"
        )
            .SetPathParameter("api_version", apiVersion)
            .SetPathParameter("notification_id", notificationId)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessfulResponse();
    }

    /// <summary>
    /// ### Overview
    ///
    /// Sends a test notification to all enabled notification types. This can be useful for validating setups. No need for any body in this request.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task SendTestNotificationAsync(
        string apiVersion,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(apiVersion, nameof(apiVersion));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var apiVersionValidationResult = new StringValidator().ValidateRequired<string?>(
            (string?)apiVersion
        );
        if (apiVersionValidationResult != null)
        {
            validationResults.Add(apiVersionValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(HttpMethod.Post, "{api_version}/api/notifications/test")
            .SetPathParameter("api_version", apiVersion)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessfulResponse();
    }
}
