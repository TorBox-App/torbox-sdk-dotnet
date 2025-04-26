using System.Net.Http.Headers;
using System.Net.Http.Json;
using TorboxApi.Http;
using TorboxApi.Http.Exceptions;
using TorboxApi.Http.Extensions;
using TorboxApi.Http.Serialization;
using TorboxApi.Models;
using TorboxApi.Validation;
using TorboxApi.Validation.Extensions;

namespace TorboxApi.Services;

public class WebDownloadsDebridService : BaseService
{
    internal WebDownloadsDebridService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>
    /// ### Overview
    ///
    /// Creates a web download under your account. Simply send a link to any file on the internet. Once it has been checked, it will begin downloading assuming your account has available active download slots, and they aren't too large.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task<CreateWebDownloadOkResponse> CreateWebDownloadAsync(
        CreateWebDownloadRequest input,
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

        var request = new RequestBuilder(
            HttpMethod.Post,
            "{api_version}/api/webdl/createwebdownload"
        )
            .SetPathParameter("api_version", apiVersion)
            .SetContentAsMultipartFormData(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<CreateWebDownloadOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>
    /// ### Overview
    ///
    /// Controls a web download. By sending the web download's ID and the type of operation you want to perform, it will send that request to the debrid client.
    ///
    /// Operations are either:
    ///
    /// - **Delete** `deletes the download from the client and your account permanently`
    ///
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    /// <param name="id">Determines the web download requested, will return an object rather than list. Optional.</param>
    public async Task ControlWebDownloadAsync(
        object input,
        string apiVersion,
        string? bypassCache = null,
        string? id = null,
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

        var request = new RequestBuilder(
            HttpMethod.Post,
            "{api_version}/api/webdl/controlwebdownload"
        )
            .SetPathParameter("api_version", apiVersion)
            .SetOptionalQueryParameter("bypass_cache", bypassCache)
            .SetOptionalQueryParameter("id", id)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessfulResponse();
    }

    /// <summary>
    /// ### Overview
    ///
    /// Requests the download link from the server. Because downloads are metered, TorBox cannot afford to allow free access to the links directly. This endpoint opens the link for 3 hours for downloads. Once a download is started, the user has nearly unlilimited time to download the file. The 1 hour time limit is simply for starting downloads. This prevents long term link sharing.
    ///
    /// ### Permalinks
    ///
    /// Instead of generating many CDN urls by requesting this endpoint, you can instead create a permalink such as: `https://api.torbox.app/v1/api/torrents/requestdl?token=APIKEY&torrent_id=NUMBER&file_id=NUMBER&redirect=true` and when a user clicks on it, it will automatically redirect them to the CDN link. This saves requests and doesn't abuse the API. Use this method rather than saving CDN links as they are not permanent. To invalidate these permalinks, simply reset your API token or delete the item from your dashboard.
    ///
    /// ### Authorization
    ///
    /// Requires an API key as a parameter for the `token` parameter.
    /// </summary>
    /// <param name="token">Your API Key</param>
    /// <param name="webId">The web download's ID that you want to download</param>
    /// <param name="fileId">The files's ID that you want to download</param>
    /// <param name="zipLink">If you want a zip link. Required if no file_id. Takes precedence over file_id if both are given.</param>
    /// <param name="userIp">The user's IP to determine the closest CDN. Optional.</param>
    /// <param name="redirect">If you want to redirect the user to the CDN link. This is useful for creating permalinks so that you can just make this request URL the link.</param>
    public async Task RequestDownloadLink2Async(
        string apiVersion,
        string? token = null,
        string? webId = null,
        string? fileId = null,
        string? zipLink = null,
        string? userIp = null,
        string? redirect = null,
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/webdl/requestdl")
            .SetPathParameter("api_version", apiVersion)
            .SetOptionalQueryParameter("token", token)
            .SetOptionalQueryParameter("web_id", webId)
            .SetOptionalQueryParameter("file_id", fileId)
            .SetOptionalQueryParameter("zip_link", zipLink)
            .SetOptionalQueryParameter("user_ip", userIp)
            .SetOptionalQueryParameter("redirect", redirect)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessfulResponse();
    }

    /// <summary>
    /// ### Overview
    ///
    /// Gets the user's web download list. This gives you the needed information to perform other usenet actions. Unlike Torrents, this information is updated on its own every 5 seconds for live web downloads.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    /// <param name="bypassCache">Allows you to bypass the cached data, and always get fresh information. Useful if constantly querying for fresh download stats. Otherwise, we request that you save our database a few calls.</param>
    /// <param name="id">Determines the torrent requested, will return an object rather than list. Optional.</param>
    /// <param name="offset">Determines the offset of items to get from the database. Default is 0. Optional.</param>
    /// <param name="limit">Determines the number of items to recieve per request. Default is 1000. Optional.</param>
    public async Task<GetWebDownloadListOkResponse> GetWebDownloadListAsync(
        string apiVersion,
        string? bypassCache = null,
        string? id = null,
        string? offset = null,
        string? limit = null,
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/webdl/mylist")
            .SetPathParameter("api_version", apiVersion)
            .SetOptionalQueryParameter("bypass_cache", bypassCache)
            .SetOptionalQueryParameter("id", id)
            .SetOptionalQueryParameter("offset", offset)
            .SetOptionalQueryParameter("limit", limit)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetWebDownloadListOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>
    /// ### Overview
    ///
    /// Takes in a list of comma separated usenet hashes and checks if the web download is cached. This endpoint only gets a max of around 100 at a time, due to http limits in queries. If you want to do more, you can simply do more hash queries. Such as:
    /// `?hash=XXXX&hash=XXXX&hash=XXXX`
    ///
    /// or `?hash=XXXX,XXXX&hash=XXXX&hash=XXXX,XXXX`
    /// and this will work too. Performance is very fast. Less than 1 second per 100. Time is approximately O(log n) time for those interested in taking it to its max. That is without caching as well. This endpoint stores a cache for an hour.
    ///
    /// You may also pass a `format` parameter with the format you want the data in. Options are either `object` or `list`. You can view examples of both below.
    ///
    /// To get the hash of a web download, pass the link through an md5 hash algo and it will return the proper hash for it.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    /// <param name="hash">
    /// The list of web hashes you want to check. Comma seperated. To find the hash, md5 the link.
    /// </param>
    /// <param name="format">Format you want the data in. Acceptable is either "object" or "list". List is the most performant option as it doesn't require modification of the list.</param>
    public async Task GetWebDownloadCachedAvailabilityAsync(
        string apiVersion,
        string? hash = null,
        string? format = null,
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/webdl/checkcached")
            .SetPathParameter("api_version", apiVersion)
            .SetOptionalQueryParameter("hash", hash)
            .SetOptionalQueryParameter("format", format)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessfulResponse();
    }

    /// <summary>
    /// ### Overview
    ///
    /// A dynamic list of hosters that TorBox is capable of downloading through its paid service.
    ///
    /// - **Name** - a clean name for display use, the well known name of the service, should be recognizable to users.
    ///
    /// - **Domains** - an array of known domains that the hoster uses. While each may serve a different purpose it is still included.
    ///
    /// - **URL** - the main url of the service. This should take you to the home page or a service page of the hoster.
    ///
    /// - **Icon** - a square image, usually a favicon or logo, that represents the service, should be recognizable as the hoster's icon.
    ///
    /// - **Status** - whether this hoster can be used on TorBox or not at the current time. It is usually a good idea to check this value before submitting a download to TorBox's servers for download.
    ///
    /// - **Type** - values are either "hoster" or "stream". Both do the same thing, but is good to differentiate services used for different things.
    ///
    /// - **Note** - a string value (or null) that may give helpful information about the current status or state of a hoster. This can and should be shown to end users.
    ///
    /// - **Daily Link Limit** - the number of downloads a user can use per day. As a user submits links, once they hit this number, the API will deny them from adding anymore of this type of link. A zero value means that it is unlimited.
    ///
    /// - **Daily Link Used** - the number of downloads a user has already used. Usually zero unless you send authentication to the endpoint. This will return accurate values.
    ///
    /// - **Daily Bandwidth Limit** - the value in bytes that a user is allowed to download from this hoster. A zero value means that it is unlimited. It is recommended to use the Daily Link Limit instead.
    ///
    /// - **Daily Bandwidth Used** - the value in bytes that a user has already used to download from this hoster. Usually zero unless you send authentication to the endpoint. This will return accurate values.
    ///
    ///
    /// ### Authorization
    ///
    /// Optional authorization. Authorization is not required in this endpoint unless you want to get the user's live data. Requires an API key using the Authorization Bearer Header to get the live and accurate data for **Daily Link Used** and **Daily Bandwidth Used**.
    /// </summary>
    public async Task<GetHosterListOkResponse> GetHosterListAsync(
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/webdl/hosters")
            .SetPathParameter("api_version", apiVersion)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetHosterListOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }
}
