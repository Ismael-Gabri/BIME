namespace PowerBiModelExtractor.Services;

internal static class ProcessOutputFormatter
{
    public static string GetErrorDetails(ProcessResult result)
    {
        var details = string.IsNullOrWhiteSpace(result.StandardError)
            ? result.StandardOutput
            : result.StandardError;

        return string.IsNullOrWhiteSpace(details)
            ? "O pbi-tools não forneceu detalhes adicionais."
            : details.Trim();
    }
}
