using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record GetAllJobsByHashOkResponseData(
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
    [property:
        JsonPropertyName("detail"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Detail = null,
    [property: JsonPropertyName("download_url")] string? DownloadUrl = null,
    [property:
        JsonPropertyName("file_id"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? FileId = null,
    [property:
        JsonPropertyName("hash"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Hash = null,
    [property: JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        double? Id = null,
    [property:
        JsonPropertyName("integration"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Integration = null,
    [property:
        JsonPropertyName("progress"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Progress = null,
    [property:
        JsonPropertyName("status"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Status = null,
    [property:
        JsonPropertyName("type"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Type_ = null,
    [property:
        JsonPropertyName("updated_at"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? UpdatedAt = null,
    [property: JsonPropertyName("zip"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        bool? Zip = null
);
