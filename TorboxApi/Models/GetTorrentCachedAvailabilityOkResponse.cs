using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record GetTorrentCachedAvailabilityOkResponse(
    [property:
        JsonPropertyName("data"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        object? Data = null,
    [property:
        JsonPropertyName("detail"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Detail = null,
    [property: JsonPropertyName("error")] string? Error = null,
    [property:
        JsonPropertyName("success"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        bool? Success = null
);
