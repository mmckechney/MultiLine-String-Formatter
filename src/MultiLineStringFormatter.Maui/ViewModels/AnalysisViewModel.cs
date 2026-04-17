using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MultiLineStringFormatter.Core;
using MultiLineStringFormatter.Core.Models;
using MultiLineStringFormatter.Core.Services;

namespace MultiLineStringFormatter.Maui.ViewModels;

[QueryProperty(nameof(Data), "AnalysisData")]
public partial class AnalysisViewModel : ObservableObject
{
    private readonly AnalysisService _analysisService = new();

    [ObservableProperty]
    private AnalysisData? _data;

    [ObservableProperty]
    private string _delimiter = string.Empty;

    [ObservableProperty]
    private int _totalLines;

    [ObservableProperty]
    private List<int> _indexOptions = new();

    [ObservableProperty]
    private int _selectedIndex;

    [ObservableProperty]
    private int _matchingLines;

    [ObservableProperty]
    private int _lessIndexes;

    [ObservableProperty]
    private int _moreIndexes;

    [ObservableProperty]
    private List<LineInfo> _filteredLines = new();

    [ObservableProperty]
    private string _statusText = "Analyzing...";

    partial void OnDataChanged(AnalysisData? value)
    {
        if (value != null) RunAnalysis(value);
    }

    private async void RunAnalysis(AnalysisData data)
    {
        StatusText = "Analyzing input data...";

        var result = await Task.Run(() => _analysisService.Analyze(data));

        Delimiter = result.Delimiter;
        TotalLines = result.TotalLines;

        var options = new List<int>();
        for (int i = 0; i < result.MaxIndexes; i++)
        {
            if (result.IndexTally.ContainsKey(i + 1))
                options.Add(i + 1);
        }
        IndexOptions = options;

        if (options.Count > 0)
        {
            SelectedIndex = options[^1];
            FilterByIndex(SelectedIndex);
        }

        StatusText = "Ready";
    }

    partial void OnSelectedIndexChanged(int value)
    {
        if (Data != null && value > 0) FilterByIndex(value);
    }

    private void FilterByIndex(int indexValue)
    {
        if (Data == null) return;

        int compliant = 0, more = 0, less = 0;
        var filtered = new List<LineInfo>();

        foreach (var line in Data.LineData)
        {
            if (line.ActualIndexCount == indexValue)
            {
                filtered.Add(line);
                compliant++;
            }
            else if (line.ActualIndexCount >= indexValue)
                more++;
            else
                less++;
        }

        MatchingLines = filtered.Count;
        LessIndexes = less;
        MoreIndexes = more;
        FilteredLines = filtered;
    }

    [RelayCommand]
    private async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}
