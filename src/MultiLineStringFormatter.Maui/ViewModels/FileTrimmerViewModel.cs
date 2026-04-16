using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MultiLineStringFormatter.Core;
using MultiLineStringFormatter.Core.Models;
using MultiLineStringFormatter.Core.Services;

namespace MultiLineStringFormatter.Maui.ViewModels;

public partial class FileTrimmerViewModel : ObservableObject
{
    private readonly FileTrimmerService _trimmerService = new();

    [ObservableProperty]
    private string _inputFilePath = string.Empty;

    [ObservableProperty]
    private string _outputFilePath = string.Empty;

    [ObservableProperty]
    private string _indexes = string.Empty;

    [ObservableProperty]
    private string _selectedDelimiter = "Tab";

    [ObservableProperty]
    private bool _keepBlankLines;

    [ObservableProperty]
    private double _progressValue;

    [ObservableProperty]
    private string _statusText = "Ready";

    [ObservableProperty]
    private bool _isProcessing;

    [ObservableProperty]
    private bool _canOpenOutput;

    public List<string> Delimiters { get; } = new()
    {
        "Tab", "Comma", "Pipe", "Tilde", "Space"
    };

    [RelayCommand]
    private async Task SelectInputFileAsync()
    {
        var result = await FilePicker.Default.PickAsync();
        if (result != null)
            InputFilePath = result.FullPath;
    }

    [RelayCommand]
    private async Task SelectOutputFileAsync()
    {
        string? filePath = await Shell.Current.DisplayPromptAsync(
            "Output File", "Enter output file path:", "OK", "Cancel",
            placeholder: "C:\\output.txt");

        if (!string.IsNullOrWhiteSpace(filePath))
            OutputFilePath = filePath;
    }

    [RelayCommand]
    private async Task ProcessAsync()
    {
        if (string.IsNullOrWhiteSpace(InputFilePath) || string.IsNullOrWhiteSpace(OutputFilePath))
        {
            await Shell.Current.DisplayAlertAsync("Missing Info", "Please select input and output files.", "OK");
            return;
        }

        string[] strIndexes = Indexes.Split(',');
        int[] indexes = new int[strIndexes.Length];
        for (int i = 0; i < strIndexes.Length; i++)
        {
            if (!int.TryParse(strIndexes[i].Trim(), out indexes[i]))
            {
                await Shell.Current.DisplayAlertAsync("Invalid Indexes",
                    "Please ensure all indexes are integers.", "OK");
                return;
            }
        }

        IsProcessing = true;
        CanOpenOutput = false;
        ProgressValue = 0;
        StatusText = "Processing...";

        char[] delimiter = Utility.GetDelimiter(SelectedDelimiter);
        var tData = new TrimmerData(InputFilePath, OutputFilePath, indexes, delimiter, KeepBlankLines);

        var progress = new Progress<int>(_ =>
        {
            ProgressValue += 10;
        });

        try
        {
            int linesProcessed = await Task.Run(() => _trimmerService.ProcessSourceFile(tData, progress));
            StatusText = $"Complete. Lines processed: {linesProcessed}";
            CanOpenOutput = true;
        }
        catch (Exception ex)
        {
            StatusText = $"Error: {ex.Message}";
        }
        finally
        {
            IsProcessing = false;
        }
    }

    [RelayCommand]
    private async Task OpenOutputFileAsync()
    {
        if (!string.IsNullOrEmpty(OutputFilePath))
            await Launcher.Default.OpenAsync(new OpenFileRequest("Output File",
                new ReadOnlyFile(OutputFilePath)));
    }

    [RelayCommand]
    private async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}
