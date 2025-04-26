using System.Net.Http.Json;
using TorboxApi.Http;
using TorboxApi.Http.Exceptions;
using TorboxApi.Http.Extensions;
using TorboxApi.Http.Serialization;
using TorboxApi.Models;
using TorboxApi.Validation;
using TorboxApi.Validation.Extensions;

namespace TorboxApi.Services;

public class IntegrationsService : BaseService
{
    internal IntegrationsService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>
    /// ### Overview
    ///
    /// Allows you to get an authorization token for using the user's account. Callback is located at `/oauth/{provider}/callback` which will verify the token recieved from the OAuth, then redirect you finally to `https://torbox.app/{provider}/success?token={token}&expires_in={expires_in}&expires_at={expires_at}`
    ///
    /// #### Providers:
    ///
    /// - "google" -> Google Drive
    ///
    /// - "dropbox" -> Dropbox
    ///
    /// - "discord" -> Discord
    ///
    /// - "onedrive" -> Azure AD/Microsoft/Onedrive
    ///
    ///
    /// ### Authorization
    ///
    /// No authorization needed. This is a whitelabel OAuth solution.
    /// </summary>
    public async Task AuthenticateOauthAsync(
        string apiVersion,
        string provider,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(apiVersion, nameof(apiVersion));
        ArgumentNullException.ThrowIfNull(provider, nameof(provider));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var apiVersionValidationResult = new StringValidator().ValidateRequired<string?>(
            (string?)apiVersion
        );
        if (apiVersionValidationResult != null)
        {
            validationResults.Add(apiVersionValidationResult);
        }
        ;
        var providerValidationResult = new StringValidator().ValidateRequired<string?>(
            (string?)provider
        );
        if (providerValidationResult != null)
        {
            validationResults.Add(providerValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(
            HttpMethod.Get,
            "{api_version}/api/integration/oauth/{provider}"
        )
            .SetPathParameter("api_version", apiVersion)
            .SetPathParameter("provider", provider)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessfulResponse();
    }

    /// <summary>
    /// ### Overview
    ///
    /// Queues a job to upload the specified file or zip to the Google Drive account sent with the `google_token` key. To get this key, either get an OAuth2 token using `/oauth/google` or your own solution. Make sure when creating the OAuth link, you add the scope `https://www.googleapis.com/auth/drive.file` so TorBox has access to the user's Drive.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task QueueGoogleDriveAsync(
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
            "{api_version}/api/integration/googledrive"
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
    /// Queues a job to upload the specified file or zip to Pixeldrain.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task QueuePixeldrainAsync(
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
            "{api_version}/api/integration/pixeldrain"
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
    /// Queues a job to upload the specified file or zip to the OneDrive sent with the `onedrive_token` key. To get this key, either get an OAuth2 token using `/oauth/onedrive` or your own solution. Make sure when creating the OAuth link you use the scope `files.readwrite.all`. This is compatible with all different types of Microsoft accounts.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task QueueOnedriveAsync(
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

        var request = new RequestBuilder(HttpMethod.Post, "{api_version}/api/integration/onedrive")
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
    /// Queues a job to upload the specified file or zip to the GoFile account sent with the `gofile_token` _(optional)_. To get this key, login to your GoFile account and go [here](https://gofile.io/myProfile). Copy the **Account API Token**. This is what you will use as the `gofile_token`, if you choose to use it. If you don't use an Account API Token, GoFile will simply create an anonymous file. This file will expire after inactivity.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task QueueGofileAsync(
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

        var request = new RequestBuilder(HttpMethod.Post, "{api_version}/api/integration/gofile")
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
    /// Queues a job to upload the specified file or zip to the 1Fichier account sent with the `onefichier_token` key (optional). To get this key you must be a Premium or Premium Gold member at 1Fichier. If you are upgraded, [go to the parameters page](https://1fichier.com/console/params.pl), and get an **API Key**. This is what you will use as the `onefichier_token`, if you choose to use it. If you don't use an API Key, 1Fichier will simply create an anonymous file.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task Queue1fichierAsync(
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

        var request = new RequestBuilder(HttpMethod.Post, "{api_version}/api/integration/1fichier")
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
    /// Gets all the jobs attached to a user account. This is good for an overall view of the jobs, such as on a dashboard, or something similar.
    ///
    /// ### Statuses
    ///
    /// - "pending" -> Upload is still waiting in the queue. Waiting for spot to upload.
    /// - "uploading" -> Upload is uploading to the proper remote. Progress will be updated as upload continues.
    /// - "completed" -> Upload has successfully been uploaded. Progress will be at 1, and the download URL will be populated.
    ///
    /// - "failed" -> The upload has failed. Check the Detail key for information.
    ///
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task<GetAllJobsOkResponse> GetAllJobsAsync(
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

        var request = new RequestBuilder(HttpMethod.Get, "{api_version}/api/integration/jobs")
            .SetPathParameter("api_version", apiVersion)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetAllJobsOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>
    /// ### Overview
    ///
    /// Gets a specifc job using the Job's ID. To get the ID, you will have to Get All Jobs, and get the ID you want.
    ///
    /// ### Statuses
    ///
    /// - "pending" -> Upload is still waiting in the queue. Waiting for spot to upload.
    /// - "uploading" -> Upload is uploading to the proper remote. Progress will be updated as upload continues.
    /// - "completed" -> Upload has successfully been uploaded. Progress will be at 1, and the download URL will be populated.
    /// - "failed" -> The upload has failed. Check the Detail key for information.
    ///
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task<string> GetSpecificJobAsync(
        string apiVersion,
        string jobId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(apiVersion, nameof(apiVersion));
        ArgumentNullException.ThrowIfNull(jobId, nameof(jobId));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var apiVersionValidationResult = new StringValidator().ValidateRequired<string?>(
            (string?)apiVersion
        );
        if (apiVersionValidationResult != null)
        {
            validationResults.Add(apiVersionValidationResult);
        }
        ;
        var jobIdValidationResult = new StringValidator().ValidateRequired<string?>((string?)jobId);
        if (jobIdValidationResult != null)
        {
            validationResults.Add(jobIdValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(
            HttpMethod.Get,
            "{api_version}/api/integration/job/{job_id}"
        )
            .SetPathParameter("api_version", apiVersion)
            .SetPathParameter("job_id", jobId)
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
    /// Cancels a job or deletes the job. Cancels while in progess (pending, uploading), or deletes the job any other time. It will delete it from the database completely.
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task CancelSpecificJobAsync(
        string apiVersion,
        string jobId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(apiVersion, nameof(apiVersion));
        ArgumentNullException.ThrowIfNull(jobId, nameof(jobId));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var apiVersionValidationResult = new StringValidator().ValidateRequired<string?>(
            (string?)apiVersion
        );
        if (apiVersionValidationResult != null)
        {
            validationResults.Add(apiVersionValidationResult);
        }
        ;
        var jobIdValidationResult = new StringValidator().ValidateRequired<string?>((string?)jobId);
        if (jobIdValidationResult != null)
        {
            validationResults.Add(jobIdValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(
            HttpMethod.Delete,
            "{api_version}/api/integration/job/{job_id}"
        )
            .SetPathParameter("api_version", apiVersion)
            .SetPathParameter("job_id", jobId)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessfulResponse();
    }

    /// <summary>
    /// ### Overview
    ///
    /// Gets all jobs that match a specific hash. Good for checking on specific downloads such as a download page, that could contain a lot of jobs.
    ///
    /// ### Statuses
    ///
    /// - "pending" -> Upload is still waiting in the queue. Waiting for spot to upload.
    /// - "uploading" -> Upload is uploading to the proper remote. Progress will be updated as upload continues.
    /// - "completed" -> Upload has successfully been uploaded. Progress will be at 1, and the download URL will be populated.
    /// - "failed" -> The upload has failed. Check the Detail key for information.
    ///
    ///
    /// ### Authorization
    ///
    /// Requires an API key using the Authorization Bearer Header.
    /// </summary>
    public async Task<GetAllJobsByHashOkResponse> GetAllJobsByHashAsync(
        string apiVersion,
        string hash,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(apiVersion, nameof(apiVersion));
        ArgumentNullException.ThrowIfNull(hash, nameof(hash));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var apiVersionValidationResult = new StringValidator().ValidateRequired<string?>(
            (string?)apiVersion
        );
        if (apiVersionValidationResult != null)
        {
            validationResults.Add(apiVersionValidationResult);
        }
        ;
        var hashValidationResult = new StringValidator().ValidateRequired<string?>((string?)hash);
        if (hashValidationResult != null)
        {
            validationResults.Add(hashValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(
            HttpMethod.Get,
            "{api_version}/api/integration/jobs/{hash}"
        )
            .SetPathParameter("api_version", apiVersion)
            .SetPathParameter("hash", hash)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetAllJobsByHashOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }
}
