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

public class TorrentsService : BaseService
{
    internal TorrentsService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>
    /// ### Overview
    ///
    /// Creates a torrent under your account. Simply send **either** a magnet link, or a torrent file. Once they have been checked, they will begin downloading assuming your account has available active download slots, and they aren't too large.
    ///
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task<CreateTorrentOkResponse> CreateTorrentAsync(
        CreateTorrentRequest input,
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
            "{api_version}/api/torrents/createtorrent"
        )
            .SetPathParameter("api_version", apiVersion)
            .SetContentAsMultipartFormData(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<CreateTorrentOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>
    /// ### Overview
    ///
    /// Controls a torrent. By sending the torrent's ID and the type of operation you want to perform, it will send that request to the torrent client.
    ///
    /// Operations are either:
    ///
    /// - **Reannounce** `reannounces the torrent to get new peers`
    ///
    /// - **Delete** `deletes the torrent from the client and your account permanently`
    ///
    /// - **Resume** `resumes a paused torrent`
    ///
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task<ControlTorrentOkResponse> ControlTorrentAsync(
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

        var request = new RequestBuilder(
            HttpMethod.Post,
            "{api_version}/api/torrents/controltorrent"
        )
            .SetPathParameter("api_version", apiVersion)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<ControlTorrentOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
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
    /// <param name="torrentId">The torrent's ID that you want to download</param>
    /// <param name="fileId">The files's ID that you want to download</param>
    /// <param name="zipLink">If you want a zip link. Required if no file_id. Takes precedence over file_id if both are given.</param>
    /// <param name="userIp">The user's IP to determine the closest CDN. Optional.</param>
    /// <param name="redirect">If you want to redirect the user to the CDN link. This is useful for creating permalinks so that you can just make this request URL the link.</param>
    public async Task<RequestDownloadLinkOkResponse> RequestDownloadLinkAsync(
        string apiVersion,
        string? token = null,
        string? torrentId = null,
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/torrents/requestdl")
            .SetPathParameter("api_version", apiVersion)
            .SetOptionalQueryParameter("token", token)
            .SetOptionalQueryParameter("torrent_id", torrentId)
            .SetOptionalQueryParameter("file_id", fileId)
            .SetOptionalQueryParameter("zip_link", zipLink)
            .SetOptionalQueryParameter("user_ip", userIp)
            .SetOptionalQueryParameter("redirect", redirect)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<RequestDownloadLinkOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>
    /// ### Overview
    ///
    /// Gets the user's torrent list. This gives you the needed information to perform other torrent actions. This information only gets updated every 600 seconds, or when the _Request Update On Torrent_ request is sent to the _relay API_.
    ///
    /// #### Download States:
    ///
    /// - "downloading" -> The torrent is currently downloading.
    ///
    /// - "uploading" -> The torrent is currently seeding.
    ///
    /// - "stalled (no seeds)" -> The torrent is trying to download, but there are no seeds connected to download from.
    ///
    /// - "paused" -> The torrent is paused.
    ///
    /// - "completed" -> The torrent is completely downloaded. Do not use this for download completion status.
    ///
    /// - "cached" -> The torrent is cached from the server.
    ///
    /// - "metaDL" -> The torrent is downloading metadata from the hoard.
    ///
    /// - "checkingResumeData" -> The torrent is checking resumable data.
    ///
    ///
    /// All other statuses are basic qBittorrent states. [Check out here for the full list](https://github.com/qbittorrent/qBittorrent/wiki/WebUI-API-(qBittorrent-4.1)#torrent-management).
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    /// <param name="bypassCache">Allows you to bypass the cached data, and always get fresh information. Useful if constantly querying for fresh download stats. Otherwise, we request that you save our database a few calls.</param>
    /// <param name="id">Determines the torrent requested, will return an object rather than list. Optional.</param>
    /// <param name="offset">Determines the offset of items to get from the database. Default is 0. Optional.</param>
    /// <param name="limit">Determines the number of items to recieve per request. Default is 1000. Optional.</param>
    public async Task<GetTorrentListOkResponse> GetTorrentListAsync(
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/torrents/mylist")
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
                .Content.ReadFromJsonAsync<GetTorrentListOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>
    /// ### Overview
    ///
    /// Takes in a list of comma separated torrent hashes and checks if the torrent is cached. This endpoint only gets a max of around 100 at a time, due to http limits in queries. If you want to do more, you can simply do more hash queries. Such as:
    /// `?hash=XXXX&hash=XXXX&hash=XXXX`
    ///
    /// or `?hash=XXXX,XXXX&hash=XXXX&hash=XXXX,XXXX`
    /// and this will work too. Performance is very fast. Less than 1 second per 100. Time is approximately O(log n) time for those interested in taking it to its max. That is without caching as well. This endpoint stores a cache for an hour.
    ///
    /// You may also pass a `format` parameter with the format you want the data in. Options are either `object` or `list`. You can view examples of both below.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    /// <param name="hash">The list of torrent hashes you want to check. Comma seperated.</param>
    /// <param name="format">Format you want the data in. Acceptable is either "object" or "list". List is the most performant option as it doesn't require modification of the list.</param>
    /// <param name="listFiles">Allows you to list the files found inside the cached data.</param>
    public async Task<GetTorrentCachedAvailabilityOkResponse> GetTorrentCachedAvailabilityAsync(
        string apiVersion,
        string? hash = null,
        string? format = null,
        string? listFiles = null,
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/torrents/checkcached")
            .SetPathParameter("api_version", apiVersion)
            .SetOptionalQueryParameter("hash", hash)
            .SetOptionalQueryParameter("format", format)
            .SetOptionalQueryParameter("list_files", listFiles)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetTorrentCachedAvailabilityOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>
    /// ### Overview
    ///
    /// Exports the magnet or torrent file. Requires a type to be passed. If type is **magnet**, it will return a JSON response with the magnet as a string in the _data_ key. If type is **file**, it will return a bittorrent file as a download. Not compatible with cached downloads.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    /// <param name="torrentId">The torrent's ID.</param>
    /// <param name="type_">Either "magnet" or "file". Tells how the API what to get, and what to respond as. If magnet, it returns a JSON response with the magnet as a string in the data key. If file, it responds with a torrent file download.</param>
    public async Task<ExportTorrentDataOkResponse> ExportTorrentDataAsync(
        string apiVersion,
        string? torrentId = null,
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/torrents/exportdata")
            .SetPathParameter("api_version", apiVersion)
            .SetOptionalQueryParameter("torrent_id", torrentId)
            .SetOptionalQueryParameter("type", type_)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<ExportTorrentDataOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>
    /// ### Overview
    ///
    /// A general route that allows you to give a hash, and TorBox will return data about the torrent. This data is retrieved from the Bittorrent network, so expect it to take some time. If the request goes longer than 10 seconds, TorBox will cancel it. You can adjust this if you like, but the default is 10 seconds. This route is cached as well, so subsequent requests will be instant.
    ///
    /// ### Authorization
    ///
    /// None required.
    /// </summary>
    /// <param name="hash">Hash of the torrent you want to get info for. This is required.</param>
    /// <param name="timeout">The amount of time you want TorBox to search for the torrent on the Bittorrent network. If the number of seeders is low or even zero, this value may be helpful to move up. Default is 10. Optional.</param>
    public async Task<GetTorrentInfoOkResponse> GetTorrentInfoAsync(
        string apiVersion,
        string? hash = null,
        string? timeout = null,
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/torrents/torrentinfo")
            .SetPathParameter("api_version", apiVersion)
            .SetOptionalQueryParameter("hash", hash)
            .SetOptionalQueryParameter("timeout", timeout)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetTorrentInfoOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>
    /// ### Overview
    ///
    /// Same as the GET route, but allows posting data such as magnet, and torrent files.
    ///
    /// Hashes will have precedence over magnets, and magnets will have precedence over torrent files.
    ///
    /// Only proper torrent files are accepted.
    ///
    /// At least one of hash, magnet, or torrent file is required.
    ///
    /// A general route that allows you to give a hash, and TorBox will return data about the torrent. This data is retrieved from the Bittorrent network, so expect it to take some time. If the request goes longer than 10 seconds, TorBox will cancel it. You can adjust this if you like, but the default is 10 seconds. This route is cached as well, so subsequent requests will be instant.
    ///
    /// ### Authorization
    ///
    /// None required.
    /// </summary>
    public async Task<GetTorrentInfo1OkResponse> GetTorrentInfo1Async(
        GetTorrentInfo1Request input,
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

        var request = new RequestBuilder(HttpMethod.Post, "{api_version}/api/torrents/torrentinfo")
            .SetPathParameter("api_version", apiVersion)
            .SetContentAsMultipartFormData(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetTorrentInfo1OkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }
}
