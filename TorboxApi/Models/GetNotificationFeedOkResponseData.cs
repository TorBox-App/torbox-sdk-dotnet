using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record GetNotificationFeedOkResponseData(
    [property:
        JsonPropertyName("auth_id"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? AuthId = null,
    [property:
        JsonPropertyName("created_at"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? CreatedAt = null,
    [property: JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        double? Id = null,
    [property:
        JsonPropertyName("message"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Message = null,
    [property:
        JsonPropertyName("title"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Title = null
);
