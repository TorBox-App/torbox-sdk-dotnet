namespace TorboxApi.Http.Handlers;

/// <summary>
/// A handler for adding a token to the request.
/// </summary>
public class TokenHandler : DelegatingHandler
{
    public string? Token { get; set; }
    public string? Header { get; set; } = "Authorization";
    public string Prefix { get; init; } = "Bearer";

    public TokenHandler(HttpMessageHandler? innerHandler = null)
        : base(innerHandler ?? new HttpClientHandler()) { }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        if (Token is not null && Header is not null)
        {
            if (request.Headers.Contains(Header))
                request.Headers.Remove(Header);
            request.Headers.Add(Header, $"{Prefix} {Token}");
        }

        return base.SendAsync(request, cancellationToken);
    }
}
