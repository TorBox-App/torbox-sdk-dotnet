using Environment = TorboxApi.Http.Environment;

namespace TorboxApi.Config;

/// <summary>
/// Configuration options for the TorboxApiClient.
/// </summary>
public record TorboxApiConfig(
    /// <value>The environment to use for the SDK.</value>
    Environment? Environment = null,
    /// <value>The access token.</value>
    string? AccessToken = null
);
