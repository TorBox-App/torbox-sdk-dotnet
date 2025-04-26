using System.Text.Json.Serialization;

namespace TorboxApi.Models;

public record GetUserDataOkResponseData(
    [property:
        JsonPropertyName("auth_id"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? AuthId = null,
    [property:
        JsonPropertyName("base_email"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? BaseEmail = null,
    [property:
        JsonPropertyName("cooldown_until"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? CooldownUntil = null,
    [property:
        JsonPropertyName("created_at"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? CreatedAt = null,
    [property:
        JsonPropertyName("customer"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Customer = null,
    [property:
        JsonPropertyName("email"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Email = null,
    [property: JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        double? Id = null,
    [property:
        JsonPropertyName("is_subscribed"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        bool? IsSubscribed = null,
    [property:
        JsonPropertyName("plan"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Plan = null,
    [property:
        JsonPropertyName("premium_expires_at"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? PremiumExpiresAt = null,
    [property:
        JsonPropertyName("server"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? Server = null,
    [property:
        JsonPropertyName("settings"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        Settings? Settings1 = null,
    [property:
        JsonPropertyName("total_downloaded"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? TotalDownloaded = null,
    [property:
        JsonPropertyName("updated_at"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? UpdatedAt = null,
    [property:
        JsonPropertyName("user_referral"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? UserReferral = null
);
