using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record GetTorrentInfo1Request(
    /// <value>Hash of the torrent you want to get info for. This is required.</value>
    [property:
        JsonPropertyName("hash"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Hash = null
);
