using System.Net.Http.Json;
using TorboxApi.Http;
using TorboxApi.Http.Exceptions;
using TorboxApi.Http.Extensions;
using TorboxApi.Http.Serialization;
using TorboxApi.Validation;
using TorboxApi.Validation.Extensions;

namespace TorboxApi.Services;

public class QueuedService : BaseService
{
    internal QueuedService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>
    /// ### Overview
    ///
    /// Retrieves all of a user's queued downloads by type. If you want to get all 3 types, "torrent", "usenet" and "webdl" then you will need to run this request 3 times, each with the different type.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    /// <param name="bypassCache">Allows you to bypass the cached data, and always get fresh information. Useful if constantly querying for fresh download stats. Otherwise, we request that you save our database a few calls.</param>
    /// <param name="id">Determines the queued download requested, will return an object rather than list. Optional.</param>
    /// <param name="offset">Determines the offset of items to get from the database. Default is 0. Optional.</param>
    /// <param name="limit">Determines the number of items to recieve per request. Default is 1000. Optional.</param>
    /// <param name="type_">The type of the queued download you want to retrieve. Can be "torrent", "usenet" or "webdl". Optional. Default is "torrent".</param>
    public async Task GetQueuedDownloadsAsync(
        string apiVersion,
        string? bypassCache = null,
        string? id = null,
        string? offset = null,
        string? limit = null,
        string? type_ = null,
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/queued/getqueued")
            .SetPathParameter("api_version", apiVersion)
            .SetOptionalQueryParameter("bypass_cache", bypassCache)
            .SetOptionalQueryParameter("id", id)
            .SetOptionalQueryParameter("offset", offset)
            .SetOptionalQueryParameter("limit", limit)
            .SetOptionalQueryParameter("type", type_)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessfulResponse();
    }

    /// <summary>
    /// ### Overview
    ///
    /// Controls a queued torrent. By sending the queued torrent's ID and the type of operation you want to perform, it will perform that action on the queued torrent.
    ///
    /// Operations are either:
    ///
    /// - **Delete** `deletes the queued download from your account`
    ///
    /// - **Start** `starts a queued download, cannot be used with the "all" parameter`
    ///
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task ControlQueuedDownloadsAsync(
        object input,
        string apiVersion,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));
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

        var request = new RequestBuilder(HttpMethod.Post, "{api_version}/api/queued/controlqueued")
            .SetPathParameter("api_version", apiVersion)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessfulResponse();
    }
}
