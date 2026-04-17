using System.Text;
using MultiLineStringFormatter.Core.Models;

namespace MultiLineStringFormatter.Core.Services;

public class StringExpandService
{
    public string ProcessStringExpand(ExpandData data)
    {
        char[] delimiter = Utility.GetDelimiter(data.Delimiter);
        var sb = new StringBuilder();

        for (int i = 0; i < data.Lines.Length; i++)
        {
            if (data.Lines[i].Trim().Length == 0)
                continue;

            string[] split = data.Lines[i].Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < split.Length; j++)
            {
                sb.Append(split[j].Trim() + "\r\n");
            }
        }

        return sb.ToString();
    }
}
