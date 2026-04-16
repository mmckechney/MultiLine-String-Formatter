using System.Text;
using System.Text.RegularExpressions;
using MultiLineStringFormatter.Core.Models;

namespace MultiLineStringFormatter.Core.Services;

public class FormattingResult
{
    public string Output { get; set; } = string.Empty;
    public int LinesProcessed { get; set; }
    public int EmptyLinesExcluded { get; set; }
    public int MissingValueLinesExcluded { get; set; }
    public int TotalLinesSubmitted { get; set; }
    public bool WasCancelled { get; set; }
}

public class StringFormatterService
{
    public FormattingResult ProcessStringFormatting(StringData data, IProgress<BulkLinePurge>? progress = null,
        CancellationToken cancellationToken = default)
    {
        int emptyLinesExcluded = 0;
        int missingValueLinesExcluded = 0;
        char[] delimiter = Utility.GetDelimiter(data.Delimiter);

        var sb = new StringBuilder();
        int linesProcessed = 0;
        int totalLines = data.Lines.Length;

        Regex formatCounter = new(@"\{[0-9]+\}");
        MatchCollection matches = formatCounter.Matches(data.Format);
        int maxMatchFormatNumber = 0;
        int minMatchFormatNumber = int.MaxValue;

        for (int i = 0; i < matches.Count; i++)
        {
            if (int.TryParse(matches[i].Value.Replace("{", "").Replace("}", ""), out int tmp))
            {
                if (tmp + 1 > maxMatchFormatNumber) maxMatchFormatNumber = tmp + 1;
                if (tmp < minMatchFormatNumber) minMatchFormatNumber = tmp;
            }
        }

        int tenPercent = Convert.ToInt32(totalLines * 0.1);

        for (int i = 0; i < totalLines; i++)
        {
            if (data.ExcludeEmptyLines && data.Lines[i].Replace(delimiter[0].ToString(), "").Trim().Length == 0)
            {
                emptyLinesExcluded++;
                continue;
            }

            string[] vals = data.Lines[i].Trim().Split(delimiter);

            if (data.ExcludeEmptyLines && vals.Length - 1 < minMatchFormatNumber)
            {
                emptyLinesExcluded++;
                continue;
            }

            bool skip = false;

            if (data.ExcludeMissingValues)
            {
                if (vals.Length < maxMatchFormatNumber)
                {
                    missingValueLinesExcluded++;
                    skip = true;
                }
                else
                {
                    for (int j = 0; j < maxMatchFormatNumber; j++)
                    {
                        if (vals[j].Trim().Length == 0)
                        {
                            missingValueLinesExcluded++;
                            skip = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                if (vals.Length - 1 < maxMatchFormatNumber)
                {
                    string[] tmpArr = new string[maxMatchFormatNumber];
                    tmpArr.Initialize();
                    vals.CopyTo(tmpArr, 0);
                    vals = tmpArr;
                }

                for (int j = 0; j < vals.Length; j++)
                    if (vals[j] == null || vals[j].Trim().Length == 0)
                        vals[j] = data.DefaultFillText;
            }

            if (skip)
                continue;

            if (data.TrimInputValues)
            {
                for (int j = 0; j < vals.Length; j++)
                    vals[j] = vals[j].Trim();
            }

            try
            {
                var tmpLine = data.Format;
                for (int z = 0; z < matches.Count; z++)
                {
                    if (int.TryParse(matches[z].Value.Replace("{", "").Replace("}", ""), out int tmpIndex))
                        tmpLine = tmpLine.Replace(matches[z].Value, vals[tmpIndex]);
                }
                sb.Append(tmpLine);
                if (!data.RemoveCarriageReturns)
                    sb.Append("\r\n");

                linesProcessed++;

                if (cancellationToken.IsCancellationRequested)
                {
                    var purge = new BulkLinePurge(sb.ToString(), linesProcessed, emptyLinesExcluded, missingValueLinesExcluded, totalLines);
                    progress?.Report(purge);
                    return new FormattingResult
                    {
                        Output = sb.ToString(),
                        LinesProcessed = linesProcessed,
                        EmptyLinesExcluded = emptyLinesExcluded,
                        MissingValueLinesExcluded = missingValueLinesExcluded,
                        TotalLinesSubmitted = totalLines,
                        WasCancelled = true
                    };
                }

                if (tenPercent > 0 && linesProcessed % tenPercent == 0)
                {
                    var purge = new BulkLinePurge(sb.ToString(), linesProcessed, emptyLinesExcluded, missingValueLinesExcluded, totalLines);
                    progress?.Report(purge);
                    sb.Clear();
                }
            }
            catch (FormatException)
            {
                if (!data.ExcludeMissingValues)
                {
                    var purge = new BulkLinePurge(sb.ToString(), i, emptyLinesExcluded, missingValueLinesExcluded, totalLines);
                    progress?.Report(purge);
                    sb.Clear();
                    // In the service layer, we skip the line instead of showing a dialog
                }
                else
                {
                    missingValueLinesExcluded++;
                }
            }
        }

        var finalPurge = new BulkLinePurge(sb.ToString(), linesProcessed, emptyLinesExcluded, missingValueLinesExcluded, totalLines);
        progress?.Report(finalPurge);

        return new FormattingResult
        {
            Output = sb.ToString(),
            LinesProcessed = linesProcessed,
            EmptyLinesExcluded = emptyLinesExcluded,
            MissingValueLinesExcluded = missingValueLinesExcluded,
            TotalLinesSubmitted = totalLines
        };
    }
}
