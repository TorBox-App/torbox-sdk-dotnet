using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record CreateWebDownloadOkResponseData(
    [property:
        JsonPropertyName("auth_id"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? AuthId = null,
    [property:
        JsonPropertyName("hash"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Hash = null,
    [property:
        JsonPropertyName("webdownload_id"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? WebdownloadId = null
);
