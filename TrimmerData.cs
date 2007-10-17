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
    class TrimmerData
    {
        public readonly bool KeepBlank;
        public readonly string SourceFile;
        public readonly string DestinationFile;
        public readonly char[] Delimiter;
        public readonly int[] Indexes;
        public TrimmerData(string sourceFile, string destinationFile, int[] indexes, char[] delimiter, bool keepBlank)
        {
            this.SourceFile = sourceFile;
            this.DestinationFile = destinationFile;
            this.Indexes = indexes;
            this.Delimiter = delimiter;
            this.KeepBlank = keepBlank;
        }
    }
}
