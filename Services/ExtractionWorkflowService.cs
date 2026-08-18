using PowerBiModelExtractor.Configuration;

namespace PowerBiModelExtractor.Services;

public sealed class ExtractionWorkflowService
{
    private readonly AppSettings _settings;
    private readonly PowerBiDiscoveryService _discoveryService;
    private readonly PowerBiExtractionService _extractionService;
    private readonly ZipService _zipService;
    private readonly ExplorerService _explorerService;

    public ExtractionWorkflowService(AppSettings settings)
    {
        _settings = settings;
        var processRunner = new ProcessRunner();
        _discoveryService = new PowerBiDiscoveryService(processRunner, settings);
        _extractionService = new PowerBiExtractionService(processRunner, settings);
        _zipService = new ZipService();
        _explorerService = new ExplorerService();
    }

    public async Task<ExtractionResult> ExtractAsync(IProgress<string> progress)
    {
        ValidatePbiTools();
        progress.Report("Procurando instâncias abertas do Power BI Desktop...");

        var sessions = await _discoveryService.GetSessionsAsync();
        if (sessions.Count == 0)
        {
            throw new InvalidOperationException("Nenhuma instância aberta do Power BI Desktop foi encontrada.");
        }

        var selectedSession = sessions[0];
        ValidatePbix(selectedSession.PbixPath);

        if (sessions.Count > 1)
        {
            progress.Report($"Foram encontradas {sessions.Count} instâncias. Usando: {Path.GetFileName(selectedSession.PbixPath)}.");
        }

        var reportName = Path.GetFileNameWithoutExtension(selectedSession.PbixPath);
        var extractionDirectory = Path.Combine(_settings.ExtractionBaseDirectory, reportName);
        var zipPath = Path.Combine(_settings.ExtractionBaseDirectory, $"{reportName}.zip");

        Directory.CreateDirectory(_settings.ExtractionBaseDirectory);
        _zipService.DeleteIfExists(zipPath);

        progress.Report("Extraindo o modelo do Power BI em formato TMDL...");
        var extractionResult = await _extractionService.ExtractAsync(
            selectedSession.PbixPath,
            selectedSession.Port,
            extractionDirectory);

        if (extractionResult.ExitCode != 0)
        {
            throw new InvalidOperationException(
                $"A extração falhou (ExitCode {extractionResult.ExitCode}).\n" +
                ProcessOutputFormatter.GetErrorDetails(extractionResult));
        }

        progress.Report("Compactando os arquivos extraídos...");
        _zipService.CreateFromDirectory(extractionDirectory, zipPath);
        Directory.Delete(extractionDirectory, recursive: true);

        if (!_explorerService.TryOpenFolder(_settings.ExtractionBaseDirectory, out var explorerError))
        {
            progress.Report($"Extração concluída. Não foi possível abrir a pasta: {explorerError}");
        }

        return new ExtractionResult(Path.GetFileName(selectedSession.PbixPath), zipPath);
    }

    private void ValidatePbiTools()
    {
        if (!File.Exists(_settings.PbiToolsPath))
        {
            throw new FileNotFoundException(
                "O executável do pbi-tools não foi encontrado. Mantenha a pasta 'tools\\pbi-tools' ao lado do aplicativo.",
                _settings.PbiToolsPath);
        }
    }

    private static void ValidatePbix(string pbixPath)
    {
        if (string.IsNullOrWhiteSpace(pbixPath) || !File.Exists(pbixPath))
        {
            throw new FileNotFoundException($"O arquivo PBIX não foi encontrado: '{pbixPath}'.", pbixPath);
        }
    }
}

public sealed record ExtractionResult(string PbixName, string ZipPath);
