using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record GetHosterListOkResponseData(
    [property:
        JsonPropertyName("daily_bandwidth_limit"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? DailyBandwidthLimit = null,
    [property:
        JsonPropertyName("daily_bandwidth_used"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? DailyBandwidthUsed = null,
    [property:
        JsonPropertyName("daily_link_limit"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? DailyLinkLimit = null,
    [property:
        JsonPropertyName("daily_link_used"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? DailyLinkUsed = null,
    [property:
        JsonPropertyName("domains"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        List<string>? Domains = null,
    [property:
        JsonPropertyName("domais"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        List<string>? Domais = null,
    [property:
        JsonPropertyName("domaisn"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        List<string>? Domaisn = null,
    [property:
        JsonPropertyName("icon"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Icon = null,
    [property:
        JsonPropertyName("limit"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Limit = null,
    [property:
        JsonPropertyName("name"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Name = null,
    [property: JsonPropertyName("note")] string? Note = null,
    [property:
        JsonPropertyName("status"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        bool? Status = null,
    [property:
        JsonPropertyName("type"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Type_ = null,
    [property: JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Url = null
);
