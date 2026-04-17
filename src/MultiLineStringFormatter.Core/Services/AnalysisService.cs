using MultiLineStringFormatter.Core.Models;

namespace MultiLineStringFormatter.Core.Services;

public class AnalysisService
{
    public AnalysisData Analyze(AnalysisData data)
    {
        int maxIndexes = 0;
        char[] delimiter = Utility.GetDelimiter(data.Delimiter);

        for (int i = 0; i < data.SourceLines.Length; i++)
        {
            string[] tmp = data.SourceLines[i].Split(delimiter, StringSplitOptions.None);
            if (tmp.Length > maxIndexes)
                maxIndexes = tmp.Length;

            if (data.IndexTally.ContainsKey(tmp.Length))
                data.IndexTally[tmp.Length]++;
            else
                data.IndexTally.Add(tmp.Length, 1);

            var info = new LineInfo(i + 1, data.SourceLines[i], tmp.Length);
            data.LineData.Add(info);
        }

        data.MaxIndexes = maxIndexes;
        return data;
    }
}
