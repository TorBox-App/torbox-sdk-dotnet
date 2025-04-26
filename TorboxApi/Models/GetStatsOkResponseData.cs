using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record GetStatsOkResponseData(
    [property:
        JsonPropertyName("active_torrents"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? ActiveTorrents = null,
    [property:
        JsonPropertyName("active_usenet_downloads"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? ActiveUsenetDownloads = null,
    [property:
        JsonPropertyName("active_web_downloads"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? ActiveWebDownloads = null,
    [property:
        JsonPropertyName("total_bytes_downloaded"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? TotalBytesDownloaded = null,
    [property:
        JsonPropertyName("total_bytes_uploaded"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? TotalBytesUploaded = null,
    [property:
        JsonPropertyName("total_downloads"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? TotalDownloads = null,
    [property:
        JsonPropertyName("total_servers"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? TotalServers = null,
    [property:
        JsonPropertyName("total_torrent_downloads"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? TotalTorrentDownloads = null,
    [property:
        JsonPropertyName("total_usenet_downloads"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? TotalUsenetDownloads = null,
    [property:
        JsonPropertyName("total_users"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? TotalUsers = null,
    [property:
        JsonPropertyName("total_web_downloads"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? TotalWebDownloads = null
);
