using System.Diagnostics;

namespace PowerBiModelExtractor.Services;

public sealed class ExplorerService
{
    public bool TryOpenFolder(string folderPath, out string? errorMessage)
    {
        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "explorer.exe",
                UseShellExecute = true
            };
            startInfo.ArgumentList.Add(folderPath);

            Process.Start(startInfo);
            errorMessage = null;
            return true;
        }
        catch (Exception exception)
        {
            errorMessage = exception.Message;
            return false;
        }
    }
}
