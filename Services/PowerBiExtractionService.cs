using System.Globalization;
using PowerBiModelExtractor.Configuration;

namespace PowerBiModelExtractor.Services;

public sealed class PowerBiExtractionService
{
    private readonly ProcessRunner _processRunner;
    private readonly AppSettings _settings;

    public PowerBiExtractionService(ProcessRunner processRunner, AppSettings settings)
    {
        _processRunner = processRunner;
        _settings = settings;
    }

    public Task<ProcessResult> ExtractAsync(
        string pbixPath,
        int port,
        string destinationDirectory,
        CancellationToken cancellationToken = default)
    {
        if (Directory.Exists(destinationDirectory))
        {
            Directory.Delete(destinationDirectory, recursive: true);
        }

        var arguments = new[]
        {
            "extract",
            pbixPath,
            "-pbiPort",
            port.ToString(CultureInfo.InvariantCulture),
            "-extractFolder",
            destinationDirectory,
            "-modelSerialization",
            "Tmdl"
        };

        return _processRunner.RunAsync(
            _settings.PbiToolsPath,
            arguments,
            cancellationToken);
    }
}
