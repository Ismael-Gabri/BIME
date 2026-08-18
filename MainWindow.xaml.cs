using System.IO;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using PowerBiModelExtractor.Configuration;
using PowerBiModelExtractor.Services;

namespace BIME;

public partial class MainWindow : Window
{
    private readonly AppSettings _settings;
    private readonly ExtractionWorkflowService _workflowService;

    public MainWindow()
    {
        InitializeComponent();

        _settings = AppSettings.Load();
        _workflowService = new ExtractionWorkflowService(_settings);
        OutputDirectoryTextBox.Text = _settings.ExtractionBaseDirectory;
    }

    private async void ExtractButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            ExtractButton.IsEnabled = false;
            SetStatus("Iniciando extração...", "#F0C83A");

            var progress = new Progress<string>(message => SetStatus(message, "#F0C83A"));
            var result = await _workflowService.ExtractAsync(progress);

            SetStatus($"Extração concluída: {result.PbixName}\nZIP gerado em: {result.ZipPath}", "#6EDB93");
        }
        catch (Exception exception)
        {
            SetStatus("Não foi possível concluir a extração.", "#FF8D8D");
            MessageBox.Show(
                exception.Message,
                "BIME — Erro na extração",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        finally
        {
            ExtractButton.IsEnabled = true;
        }
    }

    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFolderDialog
        {
            Title = "Selecione a pasta de saída",
            InitialDirectory = Directory.Exists(OutputDirectoryTextBox.Text)
                ? OutputDirectoryTextBox.Text
                : Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        };

        if (dialog.ShowDialog(this) == true)
        {
            OutputDirectoryTextBox.Text = dialog.FolderName;
        }
    }

    private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
    {
        var outputDirectory = OutputDirectoryTextBox.Text.Trim();
        if (string.IsNullOrWhiteSpace(outputDirectory))
        {
            MessageBox.Show("Informe uma pasta de saída.", "BIME", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        try
        {
            Directory.CreateDirectory(outputDirectory);
            _settings.ExtractionBaseDirectory = outputDirectory;
            _settings.Save();
            SetStatus("Pasta de saída salva com sucesso.", "#6EDB93");
            MessageBox.Show("Caminho salvo !", "BIME", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception exception) when (exception is IOException or UnauthorizedAccessException or ArgumentException)
        {
            MessageBox.Show(
                $"Não foi possível salvar a pasta de saída.\n\n{exception.Message}",
                "BIME",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }

    private void SetStatus(string message, string color)
    {
        StatusTextBlock.Text = message;
        StatusTextBlock.Foreground = (Brush)new BrushConverter().ConvertFromString(color)!;
    }
}
