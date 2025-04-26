using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record CreateTorrentRequest(
    /// <value>Tells TorBox if you want to allow this torrent to be zipped or not. TorBox only zips if the torrent is 100 files or larger.</value>
    [property:
        JsonPropertyName("allow_zip"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? AllowZip = null,
    /// <value>Tells TorBox you want this torrent instantly queued. This is bypassed if user is on free plan, and will process the request as normal in this case. Optional.</value>
    [property:
        JsonPropertyName("as_queued"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? AsQueued = null,
    /// <value>The torrent's torrent file. Optional.</value>
    [property:
        JsonPropertyName("file"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        byte[]? File = null,
    /// <value>The torrent's magnet link. Optional.</value>
    [property:
        JsonPropertyName("magnet"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Magnet = null,
    /// <value>The name you want the torrent to be. Optional.</value>
    [property:
        JsonPropertyName("name"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Name = null,
    /// <value>Tells TorBox your preference for seeding this torrent. 1 is auto. 2 is seed. 3 is don't seed. Optional. Default is 1, or whatever the user has in their settings. Overwrites option in settings.</value>
    [property:
        JsonPropertyName("seed"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Seed = null
);
