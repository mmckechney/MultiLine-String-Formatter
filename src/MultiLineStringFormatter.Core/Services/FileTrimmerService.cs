using System.Text;
using MultiLineStringFormatter.Core.Models;

namespace MultiLineStringFormatter.Core.Services;

public class FileTrimmerService
{
    public int ProcessSourceFile(TrimmerData tData, IProgress<int>? progress = null)
    {
        var sb = new StringBuilder();
        string? line;
        string[] delimited;
        int currentLine = 0;
        int lastLineEnd;

        int lineCount = 0;
        using (var sr = File.OpenText(tData.SourceFile))
        {
            while (sr.ReadLine() != null)
                lineCount++;
        }

        int tenPercent = Convert.ToInt32(lineCount * 0.1);

        using (var sr = File.OpenText(tData.SourceFile))
        {
            while ((line = sr.ReadLine()) != null)
            {
                currentLine++;
                bool keepLine = false;
                delimited = line.Split(tData.Delimiter);
                lastLineEnd = sb.Length;

                for (short i = 0; i < tData.Indexes.Length; i++)
                {
                    if (!keepLine && delimited[tData.Indexes[i]].Trim().Length > 0)
                        keepLine = true;

                    sb.Append(delimited[tData.Indexes[i]] + tData.Delimiter[0].ToString());
                }

                if (keepLine)
                {
                    sb.Length -= 1;
                    sb.Append("\r\n");
                }
                else
                {
                    sb.Length = lastLineEnd;
                }

                if (tenPercent > 0 && currentLine % tenPercent == 0)
                {
                    progress?.Report(currentLine);
                    File.AppendAllText(tData.DestinationFile, sb.ToString());
                    sb.Clear();
                }
            }

            File.AppendAllText(tData.DestinationFile, sb.ToString());
        }

        return currentLine;
    }
}
