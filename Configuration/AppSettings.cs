using System.Text.Json;

namespace PowerBiModelExtractor.Configuration;

public sealed class AppSettings
{
    private static readonly string SettingsFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "BIME",
        "settings.json");

    public string PbiToolsPath { get; init; } = Path.Combine(
        AppContext.BaseDirectory,
        "tools",
        "pbi-tools",
        "pbi-tools.exe");

    public string ExtractionBaseDirectory { get; set; } = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
        "PowerBI-Extracts");

    public static AppSettings Load()
    {
        var settings = new AppSettings();

        try
        {
            if (!File.Exists(SettingsFilePath))
            {
                return settings;
            }

            var savedSettings = JsonSerializer.Deserialize<SavedSettings>(File.ReadAllText(SettingsFilePath));
            if (!string.IsNullOrWhiteSpace(savedSettings?.ExtractionBaseDirectory))
            {
                settings.ExtractionBaseDirectory = savedSettings.ExtractionBaseDirectory;
            }
        }
        catch (IOException)
        {
            // Mantém o caminho padrão se não for possível ler a configuração salva.
        }
        catch (JsonException)
        {
            // Mantém o caminho padrão se o arquivo estiver inválido.
        }

        return settings;
    }

    public void Save()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(SettingsFilePath)!);
        var content = JsonSerializer.Serialize(new SavedSettings
        {
            ExtractionBaseDirectory = ExtractionBaseDirectory
        });
        File.WriteAllText(SettingsFilePath, content);
    }

    private sealed class SavedSettings
    {
        public string? ExtractionBaseDirectory { get; init; }
    }
}
