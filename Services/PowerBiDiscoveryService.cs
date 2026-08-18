using System.Text.Json;
using PowerBiModelExtractor.Configuration;
using PowerBiModelExtractor.Models;

namespace PowerBiModelExtractor.Services;

public sealed class PowerBiDiscoveryService
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip
    };

    private readonly ProcessRunner _processRunner;
    private readonly AppSettings _settings;

    public PowerBiDiscoveryService(ProcessRunner processRunner, AppSettings settings)
    {
        _processRunner = processRunner;
        _settings = settings;
    }

    public async Task<List<PbiSession>> GetSessionsAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _processRunner.RunAsync(
            _settings.PbiToolsPath,
            ["info"],
            cancellationToken);

        if (result.ExitCode != 0)
        {
            throw new InvalidOperationException(
                $"O comando 'pbi-tools info' falhou (ExitCode {result.ExitCode}).\n" +
                ProcessOutputFormatter.GetErrorDetails(result));
        }

        var json = ExtractJson(result.StandardOutput);

        try
        {
            var info = JsonSerializer.Deserialize<PbiToolsInfo>(json, JsonOptions)
                ?? throw new InvalidDataException(
                    "O pbi-tools retornou um JSON vazio ou incompatível.");

            return info.PbiSessions ?? [];
        }
        catch (JsonException exception)
        {
            throw new InvalidDataException(
                "Não foi possível interpretar o JSON retornado por 'pbi-tools info'.",
                exception);
        }
    }

    private static string ExtractJson(string output)
    {
        var jsonStart = output.IndexOf('{');

        if (jsonStart < 0)
        {
            throw new InvalidDataException(
                "O comando 'pbi-tools info' não retornou um objeto JSON.");
        }

        var jsonEnd = output.LastIndexOf('}');

        if (jsonEnd < jsonStart)
        {
            throw new InvalidDataException(
                "O JSON retornado por 'pbi-tools info' está incompleto.");
        }

        return output[jsonStart..(jsonEnd + 1)];
    }
}
