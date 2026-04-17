namespace MultiLineStringFormatter.Core.Models;

public class ExpandData
{
    public readonly string Format;
    public readonly string[] Lines;
    public readonly string Delimiter;

    public ExpandData(string format, string[] lines, string delimiter)
    {
        Format = format;
        Lines = lines;
        Delimiter = delimiter;
    }
}
