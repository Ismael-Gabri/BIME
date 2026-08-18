using System.Text.Json.Serialization;

namespace PowerBiModelExtractor.Models;

public sealed class PbiToolsInfo
{
    [JsonPropertyName("pbiSessions")]
    public List<PbiSession> PbiSessions { get; init; } = [];
}
