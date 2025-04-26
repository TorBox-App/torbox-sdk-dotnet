using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record CreateWebDownloadRequest(
    /// <value>An accessible link to any file on the internet. Cannot be a redirection.</value>
    [property:
        JsonPropertyName("link"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Link = null
);
