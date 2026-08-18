using System.IO.Compression;

namespace PowerBiModelExtractor.Services;

public sealed class ZipService
{
    public void DeleteIfExists(string zipPath)
    {
        if (File.Exists(zipPath))
        {
            File.Delete(zipPath);
        }
    }

    public void CreateFromDirectory(string sourceDirectory, string zipPath)
    {
        if (!Directory.Exists(sourceDirectory))
        {
            throw new DirectoryNotFoundException(
                $"A pasta gerada pela extração não foi encontrada: '{sourceDirectory}'.");
        }

        DeleteIfExists(zipPath);
        ZipFile.CreateFromDirectory(
            sourceDirectory,
            zipPath,
            CompressionLevel.Optimal,
            includeBaseDirectory: false);
    }
}
