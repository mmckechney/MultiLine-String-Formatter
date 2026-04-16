namespace MultiLineStringFormatter.Core.Models;

public class AnalysisData
{
    public Dictionary<int, int> IndexTally { get; set; } = new();
    public int MaxIndexes { get; set; }
    public int TotalLines { get; set; }
    public int CompliantLines { get; set; }
    public int NonCompliantLines { get; set; }
    public string Delimiter { get; set; } = string.Empty;
    public List<LineInfo> LineData { get; set; } = new();
    public string[] SourceLines { get; set; } = Array.Empty<string>();
}

public class LineInfo
{
    public int LineNumber { get; set; }
    public string LineText { get; set; }
    public int ActualIndexCount { get; set; }

    public LineInfo(int lineNumber, string lineText, int actualIndexCount)
    {
        LineNumber = lineNumber;
        LineText = lineText;
        ActualIndexCount = actualIndexCount;
    }
}
