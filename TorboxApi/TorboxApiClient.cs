using TorboxApi.Config;
using TorboxApi.Http.Extensions;
using TorboxApi.Http.Handlers;
using TorboxApi.Services;
using Environment = TorboxApi.Http.Environment;

namespace TorboxApi;

public class TorboxApiClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly TokenHandler _accessTokenHandler;

    public TorrentsService Torrents { get; private set; }
    public UsenetService Usenet { get; private set; }
    public WebDownloadsDebridService WebDownloadsDebrid { get; private set; }
    public GeneralService General { get; private set; }
    public NotificationsService Notifications { get; private set; }
    public UserService User { get; private set; }
    public RssFeedsService RssFeeds { get; private set; }
    public IntegrationsService Integrations { get; private set; }
    public QueuedService Queued { get; private set; }

    public TorboxApiClient(TorboxApiConfig? config = null)
    {
        var retryHandler = new RetryHandler();
        _accessTokenHandler = new TokenHandler(retryHandler)
        {
            Header = "Authorization",
            Prefix = "Bearer",
            Token = config?.AccessToken,
        };

        _httpClient = new HttpClient(_accessTokenHandler)
        {
            BaseAddress = config?.Environment?.Uri ?? Environment.Default.Uri,
            DefaultRequestHeaders = { { "user-agent", "dotnet/7.0" } },
        };

        Torrents = new TorrentsService(_httpClient);
        Usenet = new UsenetService(_httpClient);
        WebDownloadsDebrid = new WebDownloadsDebridService(_httpClient);
        General = new GeneralService(_httpClient);
        Notifications = new NotificationsService(_httpClient);
        User = new UserService(_httpClient);
        RssFeeds = new RssFeedsService(_httpClient);
        Integrations = new IntegrationsService(_httpClient);
        Queued = new QueuedService(_httpClient);
    }

    /// <summary>
    /// Set the environment for the entire SDK.
    /// </summary>
    public void SetEnvironment(Environment environment)
    {
        SetBaseUrl(environment.Uri);
    }

    /// <summary>
    /// Sets the base URL for the entire SDK.
    /// </summary>
    public void SetBaseUrl(string baseUrl)
    {
        SetBaseUrl(new Uri(baseUrl));
    }

    /// <summary>
    /// Sets the base URL for the entire SDK.
    /// </summary>
    public void SetBaseUrl(Uri uri)
    {
        _httpClient.BaseAddress = uri.EnsureTrailingSlash();
    }

    /// <summary>
    /// Sets the access token for the entire SDK.
    /// </summary>
    public void SetAccessToken(string token)
    {
        _accessTokenHandler.Token = token;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}

// c029837e0e474b76bc487506e8799df5e3335891efe4fb02bda7a1441840310c
