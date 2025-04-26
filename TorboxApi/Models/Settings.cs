using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record Settings(
    [property:
        JsonPropertyName("anothersetting"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Anothersetting = null,
    [property:
        JsonPropertyName("setting"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Setting = null
);
