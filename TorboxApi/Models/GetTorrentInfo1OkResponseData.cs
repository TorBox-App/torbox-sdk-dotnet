using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record GetTorrentInfo1OkResponseData(
    [property:
        JsonPropertyName("files"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        List<DataFiles3>? Files = null,
    [property:
        JsonPropertyName("hash"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Hash = null,
    [property:
        JsonPropertyName("name"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Name = null,
    [property:
        JsonPropertyName("peers"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Peers = null,
    [property:
        JsonPropertyName("seeds"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Seeds = null,
    [property:
        JsonPropertyName("size"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Size = null,
    [property:
        JsonPropertyName("trackers"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        List<object>? Trackers = null
);
