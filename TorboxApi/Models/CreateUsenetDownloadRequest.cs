using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record CreateUsenetDownloadRequest(
    /// <value>An NZB File. Optional.</value>
    [property:
        JsonPropertyName("file"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        byte[]? File = null,
    /// <value>An accessible link to an NZB file. Cannot be a redirection. Optional.</value>
    [property:
        JsonPropertyName("link"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Link = null
);
