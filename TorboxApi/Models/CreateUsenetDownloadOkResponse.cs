using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record CreateUsenetDownloadOkResponse(
    [property:
        JsonPropertyName("data"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        CreateUsenetDownloadOkResponseData? Data = null,
    [property:
        JsonPropertyName("detail"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Detail = null,
    [property: JsonPropertyName("error")] object? Error = null,
    [property:
        JsonPropertyName("success"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        bool? Success = null
);
