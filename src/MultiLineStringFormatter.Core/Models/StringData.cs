namespace MultiLineStringFormatter.Core.Models;

public class StringData
{
    public readonly string Format;
    public readonly string[] Lines;
    public readonly string Delimiter;
    public readonly bool RemoveCarriageReturns;
    public readonly bool ExcludeEmptyLines;
    public readonly bool ExcludeMissingValues;
    public readonly bool TrimInputValues;
    public readonly string DefaultFillText;

    public StringData(string format, string[] lines, string delimiter,
        bool removeCarriageReturns, bool excludeEmptyLines,
        bool excludeMissingValues, bool trimInputValues, string defaultFillText)
    {
        Format = format;
        Lines = lines;
        Delimiter = delimiter;
        RemoveCarriageReturns = removeCarriageReturns;
        ExcludeEmptyLines = excludeEmptyLines;
        ExcludeMissingValues = excludeMissingValues;
        TrimInputValues = trimInputValues;
        DefaultFillText = defaultFillText;
    }
}
