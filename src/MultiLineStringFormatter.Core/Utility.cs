namespace MultiLineStringFormatter.Core;

public static class Utility
{
    public static char[] GetDelimiter(string? delimiterString)
    {
        if (delimiterString == null)
            delimiterString = ",";

        return delimiterString.ToLower() switch
        {
            "tab" => new[] { '\t' },
            "space" => new[] { ' ' },
            "comma" => new[] { ',' },
            "tilde" => new[] { '~' },
            "pipe" => new[] { '|' },
            _ => delimiterString.ToCharArray(),
        };
    }
}
