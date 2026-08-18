using System.Text.Json.Serialization;

namespace PowerBiModelExtractor.Models;

public sealed class PbiSession
{
    [JsonPropertyName("ProcessId")]
    public int ProcessId { get; init; }

    [JsonPropertyName("Port")]
    public int Port { get; init; }

    [JsonPropertyName("PbixPath")]
    public string PbixPath { get; init; } = string.Empty;

    [JsonPropertyName("WorkspaceName")]
    public string? WorkspaceName { get; init; }

    [JsonPropertyName("ProductVersion")]
    public string? ProductVersion { get; init; }
}
