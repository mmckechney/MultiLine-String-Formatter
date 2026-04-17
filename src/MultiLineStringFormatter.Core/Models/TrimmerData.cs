namespace MultiLineStringFormatter.Core.Models;

public class TrimmerData
{
    public readonly bool KeepBlank;
    public readonly string SourceFile;
    public readonly string DestinationFile;
    public readonly char[] Delimiter;
    public readonly int[] Indexes;

    public TrimmerData(string sourceFile, string destinationFile, int[] indexes, char[] delimiter, bool keepBlank)
    {
        SourceFile = sourceFile;
        DestinationFile = destinationFile;
        Indexes = indexes;
        Delimiter = delimiter;
        KeepBlank = keepBlank;
    }
}
