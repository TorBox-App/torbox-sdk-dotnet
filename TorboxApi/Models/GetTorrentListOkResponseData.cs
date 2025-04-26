using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record GetTorrentListOkResponseData(
    [property:
        JsonPropertyName("active"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        bool? Active = null,
    [property:
        JsonPropertyName("auth_id"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? AuthId = null,
    [property:
        JsonPropertyName("availability"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Availability = null,
    [property:
        JsonPropertyName("created_at"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? CreatedAt = null,
    [property:
        JsonPropertyName("download_finished"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        bool? DownloadFinished = null,
    [property:
        JsonPropertyName("download_present"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        bool? DownloadPresent = null,
    [property:
        JsonPropertyName("download_speed"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? DownloadSpeed = null,
    [property:
        JsonPropertyName("download_state"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? DownloadState = null,
    [property: JsonPropertyName("eta"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        double? Eta = null,
    [property:
        JsonPropertyName("expires_at"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? ExpiresAt = null,
    [property:
        JsonPropertyName("files"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        List<DataFiles1>? Files = null,
    [property:
        JsonPropertyName("hash"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Hash = null,
    [property: JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        double? Id = null,
    [property:
        JsonPropertyName("inactive_check"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? InactiveCheck = null,
    [property:
        JsonPropertyName("magnet"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Magnet = null,
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
        JsonPropertyName("progress"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Progress = null,
    [property:
        JsonPropertyName("ratio"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Ratio = null,
    [property:
        JsonPropertyName("seeds"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Seeds = null,
    [property:
        JsonPropertyName("server"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Server = null,
    [property:
        JsonPropertyName("size"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Size = null,
    [property:
        JsonPropertyName("torrent_file"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        bool? TorrentFile = null,
    [property:
        JsonPropertyName("updated_at"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? UpdatedAt = null,
    [property:
        JsonPropertyName("upload_speed"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? UploadSpeed = null
);
