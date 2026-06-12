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
            "pipe" => new[] { '|', '\u2502' }, // also match box-drawing vertical bar │
            _ => delimiterString.ToCharArray(),
        };
    }
}
