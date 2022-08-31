using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineStringFormatter
{
    /// <summary>
    /// Authored by Michael McKechney (www.mckechney.com)
    /// This code and program are fully and freely distrubutable.
    /// If you re-use code in your own applications, please reference this original work.
    /// Thanks and your feedback is welcomed and encouraged.
    /// </summary>
    class StringData
    {
        public readonly string Format;
        public readonly string[] Lines;
        public readonly string Delimiter;
        public readonly bool RemoveCarrigeReturns;
        public readonly bool ExcludeEmptyLines;
        public readonly bool ExcludeMissingValues;
        public readonly bool TrimInputValues;
        public readonly string DefaultFillText;
        public StringData(string format, string[] lines, string delimiter, bool removeCarriageReturns, bool excludeEmptyLines, bool excludeMissingValues, bool trimInputValues, string defaultFillText)
        {
            this.Format = format;
            this.Lines = lines;
            this.Delimiter = delimiter;
            this.RemoveCarrigeReturns = removeCarriageReturns;
            this.ExcludeEmptyLines = excludeEmptyLines;
            this.ExcludeMissingValues = excludeMissingValues;
            this.TrimInputValues = trimInputValues;
            this.DefaultFillText = defaultFillText;
        }
    }
}
