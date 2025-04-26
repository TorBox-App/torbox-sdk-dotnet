using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record DataFiles1(
    [property: JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        double? Id = null,
    [property: JsonPropertyName("md5"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Md5 = null,
    [property:
        JsonPropertyName("mimetype"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Mimetype = null,
    [property:
        JsonPropertyName("name"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Name = null,
    [property:
        JsonPropertyName("s3_path"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? S3Path = null,
    [property:
        JsonPropertyName("short_name"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? ShortName = null,
    [property:
        JsonPropertyName("size"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Size = null
);
