namespace MultiLineStringFormatter.Core.Models;

public class BulkLinePurge
{
    public readonly string LineResults;
    public readonly int LinesProcessed;
    public readonly int ExcludedEmptyLineCount;
    public readonly int ExcludedMissingValueLineCount;
    public readonly int TotalLinesSubmitted;

    public BulkLinePurge(string lineResults, int linesProcessed,
        int excludedEmptyLineCount, int excludedMissingValueLineCount, int totalLinesSubmitted)
    {
        LinesProcessed = linesProcessed;
        LineResults = lineResults;
        ExcludedEmptyLineCount = excludedEmptyLineCount;
        ExcludedMissingValueLineCount = excludedMissingValueLineCount;
        TotalLinesSubmitted = totalLinesSubmitted;
    }
}
