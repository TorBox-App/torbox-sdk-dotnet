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

public class UsenetService : BaseService
{
    internal UsenetService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>
    /// ### Overview
    ///
    /// Creates a usenet download under your account. Simply send **either** a link, or an nzb file. Once they have been checked, they will begin downloading assuming your account has available active download slots, and they aren't too large.
    ///
    /// #### Post Processing Options:
    ///
    /// All post processing options that the Usenet client will perform before TorBox's own processing to make the files available. It is recommended you either don't send this parameter, or keep it at `-1` for default, which will give only the wanted files.
    ///
    /// - `-1`, Default. This runs repairs, and extractions as well as deletes the source files leaving only the wanted downloaded files.
    ///
    /// - `0`, None. No post-processing at all. Just download all the files (including all PAR2). TorBox will still do its normal processing to make the download available, but no repairs, or extraction will take place.
    ///
    /// - `1`, Repair. Download files and do a PAR2 verification. If the verification fails, download more PAR2 files and attempt to repair the files.
    ///
    /// - `2`, Repair and Unpack. Download all files, do a PAR2 verification and unpack the files. The final folder will also include the RAR and ZIP files.
    ///
    /// - `3`, Repair, Unpack and Delete. Download all files, do a PAR2 verification, unpack the files to the final folder and delete the source files.
    ///
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task<CreateUsenetDownloadOkResponse> CreateUsenetDownloadAsync(
        CreateUsenetDownloadRequest input,
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
            "{api_version}/api/usenet/createusenetdownload"
        )
            .SetPathParameter("api_version", apiVersion)
            .SetContentAsMultipartFormData(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<CreateUsenetDownloadOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>
    /// ### Overview
    ///
    /// Controls a usenet download. By sending the usenet download's ID and the type of operation you want to perform, it will send that request to the usenet client.
    ///
    /// Operations are either:
    ///
    /// - **Delete** `deletes the nzb from the client and your account permanently`
    ///
    /// - **Pause** `pauses a nzb's download`
    ///
    /// - **Resume** `resumes a paused usenet download`
    ///
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task ControlUsenetDownloadAsync(
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
            "{api_version}/api/usenet/controlusenetdownload"
        )
            .SetPathParameter("api_version", apiVersion)
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
    /// <param name="usenetId">The usenet download's ID that you want to download</param>
    /// <param name="fileId">The files's ID that you want to download</param>
    /// <param name="zipLink">If you want a zip link. Required if no file_id. Takes precedence over file_id if both are given.</param>
    /// <param name="userIp">The user's IP to determine the closest CDN. Optional.</param>
    /// <param name="redirect">If you want to redirect the user to the CDN link. This is useful for creating permalinks so that you can just make this request URL the link.</param>
    public async Task RequestDownloadLink1Async(
        string apiVersion,
        string? token = null,
        string? usenetId = null,
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/usenet/requestdl")
            .SetPathParameter("api_version", apiVersion)
            .SetOptionalQueryParameter("token", token)
            .SetOptionalQueryParameter("usenet_id", usenetId)
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
    /// Gets the user's usenet download list. This gives you the needed information to perform other usenet actions. Unlike Torrents, this information is updated on its own every 5 seconds for live usenet downloads.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    /// <param name="bypassCache">Allows you to bypass the cached data, and always get fresh information. Useful if constantly querying for fresh download stats. Otherwise, we request that you save our database a few calls.</param>
    /// <param name="id">Determines the usenet download requested, will return an object rather than list. Optional.</param>
    /// <param name="offset">Determines the offset of items to get from the database. Default is 0. Optional.</param>
    /// <param name="limit">Determines the number of items to recieve per request. Default is 1000. Optional.</param>
    public async Task<GetUsenetListOkResponse> GetUsenetListAsync(
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/usenet/mylist")
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
                .Content.ReadFromJsonAsync<GetUsenetListOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>
    /// ### Overview
    ///
    /// Takes in a list of comma separated usenet hashes and checks if the usenet download is cached. This endpoint only gets a max of around 100 at a time, due to http limits in queries. If you want to do more, you can simply do more hash queries. Such as:
    /// `?hash=XXXX&hash=XXXX&hash=XXXX`
    ///
    /// or `?hash=XXXX,XXXX&hash=XXXX&hash=XXXX,XXXX`
    /// and this will work too. Performance is very fast. Less than 1 second per 100. Time is approximately O(log n) time for those interested in taking it to its max. That is without caching as well. This endpoint stores a cache for an hour.
    ///
    /// You may also pass a `format` parameter with the format you want the data in. Options are either `object` or `list`. You can view examples of both below.
    ///
    /// To get the hash of a usenet download, pass the link or file through an md5 hash algo and it will return the proper hash for it.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    /// <param name="hash">The list of usenet hashes you want to check. Comma seperated. To find the hash, md5 the link of the usenet link or file.</param>
    /// <param name="format">Format you want the data in. Acceptable is either "object" or "list". List is the most performant option as it doesn't require modification of the list.</param>
    public async Task GetUsenetCachedAvailabilityAsync(
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/usenet/checkcached")
            .SetPathParameter("api_version", apiVersion)
            .SetOptionalQueryParameter("hash", hash)
            .SetOptionalQueryParameter("format", format)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessfulResponse();
    }
}
