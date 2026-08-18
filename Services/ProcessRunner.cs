using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace PowerBiModelExtractor.Services;

public sealed record ProcessResult(int ExitCode, string StandardOutput, string StandardError);

public sealed class ProcessRunner
{
    private static readonly Encoding StrictUtf8 = new UTF8Encoding(
        encoderShouldEmitUTF8Identifier: false,
        throwOnInvalidBytes: true);

    static ProcessRunner()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    public async Task<ProcessResult> RunAsync(
        string executablePath,
        IEnumerable<string> arguments,
        CancellationToken cancellationToken = default)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = executablePath,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        foreach (var argument in arguments)
        {
            startInfo.ArgumentList.Add(argument);
        }

        using var process = new Process { StartInfo = startInfo };

        if (!process.Start())
        {
            throw new InvalidOperationException($"Não foi possível iniciar '{executablePath}'.");
        }

        // As streams são lidas simultaneamente como bytes para evitar deadlock e
        // preservar a codificação original produzida pelo pbi-tools no Windows.
        var standardOutputTask = ReadAllBytesAsync(
            process.StandardOutput.BaseStream,
            cancellationToken);
        var standardErrorTask = ReadAllBytesAsync(
            process.StandardError.BaseStream,
            cancellationToken);

        await process.WaitForExitAsync(cancellationToken);
        await Task.WhenAll(standardOutputTask, standardErrorTask);

        return new ProcessResult(
            process.ExitCode,
            DecodeOutput(await standardOutputTask),
            DecodeOutput(await standardErrorTask));
    }

    private static async Task<byte[]> ReadAllBytesAsync(
        Stream stream,
        CancellationToken cancellationToken)
    {
        using var buffer = new MemoryStream();
        await stream.CopyToAsync(buffer, cancellationToken);
        return buffer.ToArray();
    }

    private static string DecodeOutput(byte[] bytes)
    {
        try
        {
            return StrictUtf8.GetString(bytes);
        }
        catch (DecoderFallbackException)
        {
            var oemCodePage = CultureInfo.CurrentCulture.TextInfo.OEMCodePage;
            return Encoding.GetEncoding(oemCodePage).GetString(bytes);
        }
    }
}
