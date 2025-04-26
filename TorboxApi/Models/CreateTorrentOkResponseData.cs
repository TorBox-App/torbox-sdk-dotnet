using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record CreateTorrentOkResponseData(
    [property:
        JsonPropertyName("active_limit"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? ActiveLimit = null,
    [property:
        JsonPropertyName("auth_id"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? AuthId = null,
    [property:
        JsonPropertyName("current_active_downloads"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? CurrentActiveDownloads = null,
    [property:
        JsonPropertyName("hash"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Hash = null,
    [property:
        JsonPropertyName("queued_id"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? QueuedId = null,
    [property:
        JsonPropertyName("torrent_id"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? TorrentId = null
);
