using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineStringFormatter
{
    class BulkLinePurge
    {
        public readonly string LineResults;
        public readonly int LinesProcessed;
        public readonly int ExcludedEmptyLineCount;
        public readonly int ExcludedMissingValueLineCount;
        public readonly int TotalLinesSubmitted;
        public BulkLinePurge(string lineResults, int linesProcessed, int excludedEmptyLineCount, int excludedMissingValueLineCount, int totalLinesSubmitted)
        {
            this.LinesProcessed = linesProcessed;
            this.LineResults = lineResults;
            this.ExcludedEmptyLineCount = excludedEmptyLineCount;
            this.ExcludedMissingValueLineCount = excludedMissingValueLineCount;
            this.TotalLinesSubmitted = totalLinesSubmitted;
        }
    }
}
