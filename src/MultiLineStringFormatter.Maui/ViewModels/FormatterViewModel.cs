using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MultiLineStringFormatter.Core;
using MultiLineStringFormatter.Core.Models;
using MultiLineStringFormatter.Core.Services;

namespace MultiLineStringFormatter.Maui.ViewModels;

public partial class FormatterViewModel : ObservableObject
{
    private readonly StringFormatterService _formatterService = new();
    private readonly StringExpandService _expandService = new();
    private readonly FormatConfigService _configService = new();

    private CancellationTokenSource? _cts;
    private string _savedFormatConfigFile = string.Empty;
    private StringManipulatorCfg? _formats;

    [ObservableProperty]
    private string _sourceText = string.Empty;

    [ObservableProperty]
    private string _formatText = string.Empty;

    [ObservableProperty]
    private string _resultsText = string.Empty;

    [ObservableProperty]
    private string _selectedDelimiter = "Tab";

    [ObservableProperty]
    private string _delimiterText = "Tab";

    [ObservableProperty]
    private string _statusText = "Ready";

    [ObservableProperty]
    private double _progressValue;

    [ObservableProperty]
    private bool _isProcessing;

    [ObservableProperty]
    private int _linesProcessed;

    [ObservableProperty]
    private int _linesSubmitted;

    [ObservableProperty]
    private int _emptyLinesExcluded;

    [ObservableProperty]
    private int _missingValuesExcluded;

    [ObservableProperty]
    private bool _trimInputValues = true;

    [ObservableProperty]
    private bool _excludeEmptyLines;

    [ObservableProperty]
    private bool _removeCarriageReturns;

    [ObservableProperty]
    private bool _excludeMissingValues = true;

    [ObservableProperty]
    private bool _fillWithDefaultText;

    [ObservableProperty]
    private string _defaultFillText = "NULL";

    [ObservableProperty]
    private List<SavedFormatItem> _savedFormats = new();

    [ObservableProperty]
    private int _sourceCursorPosition;

    [ObservableProperty]
    private string _indexInfoText = string.Empty;

    public List<string> Delimiters { get; } = new()
    {
        "Tab", "Comma", "Pipe", "Tilde", "Space"
    };

    public FormatterViewModel()
    {
        _savedFormatConfigFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            @"MultiLineStringFormatter\StringManipulatorFormats1.cfg");
        LoadSavedFormats();
    }

    partial void OnSelectedDelimiterChanged(string value)
    {
        if (!string.IsNullOrEmpty(value))
            DelimiterText = value;
    }

    partial void OnSourceCursorPositionChanged(int value)
    {
        UpdateIndexInfo(value);
    }

    private void UpdateIndexInfo(int cursorPosition)
    {
        try
        {
            if (string.IsNullOrEmpty(SourceText) || cursorPosition < 0 || cursorPosition > SourceText.Length)
            {
                IndexInfoText = string.Empty;
                return;
            }

            // Find which line the cursor is on
            int lineStart = SourceText.LastIndexOf('\n', Math.Max(0, cursorPosition - 1)) + 1;
            int lineEnd = SourceText.IndexOf('\n', cursorPosition);
            if (lineEnd < 0) lineEnd = SourceText.Length;

            string line = SourceText[lineStart..lineEnd].TrimEnd('\r');
            int positionInLine = cursorPosition - lineStart;

            char[] delimiter = Utility.GetDelimiter(DelimiterText);
            string[] parts = line.Split(delimiter);

            int cumulative = 0;
            for (int i = 0; i < parts.Length; i++)
            {
                cumulative += parts[i].Length;
                if (cumulative >= positionInLine)
                {
                    IndexInfoText = $"Index: {i}  [{parts[i].Trim()}]";
                    return;
                }
                cumulative += 1; // delimiter character
            }

            IndexInfoText = string.Empty;
        }
        catch
        {
            IndexInfoText = string.Empty;
        }
    }

    [RelayCommand]
    private async Task ProcessAsync()
    {
        if (string.IsNullOrWhiteSpace(SourceText) || string.IsNullOrWhiteSpace(FormatText))
            return;

        IsProcessing = true;
        StatusText = "Processing...";
        ResultsText = string.Empty;
        ProgressValue = 0;
        LinesProcessed = 0;
        EmptyLinesExcluded = 0;
        MissingValuesExcluded = 0;

        _cts = new CancellationTokenSource();

        var lines = SourceText.Split('\n').Select(l => l.TrimEnd('\r')).ToArray();
        LinesSubmitted = lines.Length;

        var data = new StringData(
            FormatText, lines, DelimiterText,
            RemoveCarriageReturns, ExcludeEmptyLines,
            ExcludeMissingValues, TrimInputValues,
            FillWithDefaultText ? DefaultFillText : "");

        var progress = new Progress<BulkLinePurge>(purge =>
        {
            ResultsText += purge.LineResults;
            LinesProcessed = purge.LinesProcessed;
            EmptyLinesExcluded = purge.ExcludedEmptyLineCount;
            MissingValuesExcluded = purge.ExcludedMissingValueLineCount;
        });

        try
        {
            var result = await Task.Run(() =>
                _formatterService.ProcessStringFormatting(data, progress, _cts.Token));

            if (!result.WasCancelled)
            {
                LinesProcessed = result.LinesProcessed;
                EmptyLinesExcluded = result.EmptyLinesExcluded;
                MissingValuesExcluded = result.MissingValueLinesExcluded;
            }

            StatusText = result.WasCancelled ? "Cancelled" : "Ready";
        }
        catch (Exception ex)
        {
            StatusText = $"Error: {ex.Message}";
        }
        finally
        {
            IsProcessing = false;
            ProgressValue = 0;
            _cts?.Dispose();
            _cts = null;
        }
    }

    [RelayCommand]
    private async Task ExpandAsync()
    {
        if (string.IsNullOrWhiteSpace(SourceText))
            return;

        IsProcessing = true;
        StatusText = "Expanding...";

        var lines = SourceText.Split('\n').Select(l => l.TrimEnd('\r')).ToArray();
        var data = new ExpandData(FormatText, lines, DelimiterText);

        try
        {
            ResultsText = await Task.Run(() => _expandService.ProcessStringExpand(data));
            StatusText = "Ready";
        }
        finally
        {
            IsProcessing = false;
        }
    }

    [RelayCommand]
    private void CancelProcessing()
    {
        _cts?.Cancel();
    }

    [RelayCommand]
    private async Task CopyResultsAsync()
    {
        if (!string.IsNullOrEmpty(ResultsText))
            await Clipboard.Default.SetTextAsync(ResultsText);
    }

    [RelayCommand]
    private async Task SaveResultsToFileAsync()
    {
        if (string.IsNullOrEmpty(ResultsText))
            return;

        string? filePath = await Shell.Current.DisplayPromptAsync(
            "Save File", "Enter file path:", "Save", "Cancel",
            placeholder: "C:\\output.txt");

        if (!string.IsNullOrWhiteSpace(filePath))
        {
            await File.WriteAllTextAsync(filePath, ResultsText);
            StatusText = "File saved successfully";
        }
    }

    [RelayCommand]
    private async Task OpenSourceFileAsync()
    {
        var result = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Select Source Text File"
        });

        if (result != null)
        {
            StatusText = "Loading file...";
            SourceText = await File.ReadAllTextAsync(result.FullPath);
            StatusText = "File loaded";
        }
    }

    [RelayCommand]
    private async Task SaveFormatAsync()
    {
        if (string.IsNullOrWhiteSpace(FormatText))
            return;

        string? name = await Shell.Current.DisplayPromptAsync(
            "Save Format", "Enter a name for this format:", "Save", "Cancel");

        if (string.IsNullOrWhiteSpace(name))
            return;

        var format = new Format
        {
            Name = name,
            Value = FormatText,
            Delimiter = DelimiterText
        };

        _formats ??= new StringManipulatorCfg();
        _formats.Items.Add(format);
        _configService.SaveFormats(_savedFormatConfigFile, _formats);
        LoadSavedFormats();
    }

    [RelayCommand]
    private void InsertFormat(SavedFormatItem item)
    {
        FormatText = item.Value;
        DelimiterText = item.Delimiter;
        // Also update the picker if it matches a preset
        if (Delimiters.Contains(item.Delimiter))
            SelectedDelimiter = item.Delimiter;
    }

    [RelayCommand]
    private async Task DeleteFormatAsync(SavedFormatItem item)
    {
        if (_formats == null) return;

        bool confirm = await Shell.Current.DisplayAlertAsync(
            "Delete Format", $"Delete saved format \"{item.Name}\"?", "Delete", "Cancel");

        if (!confirm) return;

        _formats.Items.RemoveAll(f => f.Name == item.Name);
        _configService.SaveFormats(_savedFormatConfigFile, _formats);
        LoadSavedFormats();
    }

    [RelayCommand]
    private async Task OpenAnalysisAsync()
    {
        var lines = SourceText.Split('\n').Select(l => l.TrimEnd('\r')).ToArray();
        var data = new AnalysisData
        {
            SourceLines = lines,
            TotalLines = lines.Length,
            Delimiter = DelimiterText
        };

        await Shell.Current.GoToAsync(nameof(Views.AnalysisPage),
            new Dictionary<string, object> { { "AnalysisData", data } });
    }

    [RelayCommand]
    private async Task OpenFileTrimmerAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.FileTrimmerPage));
    }

    private void LoadSavedFormats()
    {
        _formats = _configService.LoadFormats(_savedFormatConfigFile);
        if (_formats?.Items != null)
        {
            SavedFormats = _formats.Items.Select(f => new SavedFormatItem
            {
                Name = f.Name,
                Value = f.Value,
                Delimiter = f.Delimiter
            }).ToList();
        }
        else
        {
            SavedFormats = new List<SavedFormatItem>();
        }
    }

    partial void OnExcludeMissingValuesChanged(bool value)
    {
        if (value) FillWithDefaultText = false;
    }

    partial void OnFillWithDefaultTextChanged(bool value)
    {
        if (value) ExcludeMissingValues = false;
    }
}

public class SavedFormatItem
{
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string Delimiter { get; set; } = string.Empty;
    public string DisplayText => $"{Name} :: {(Value.Length > 30 ? Value[..30] + " ..." : Value)}";
}
