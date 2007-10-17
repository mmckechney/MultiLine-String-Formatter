using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineStringFormatter
{
    class ExpandData
    {  
        public readonly string Format;
        public readonly string[] Lines;
        public readonly string Delimiter;
        public ExpandData(string format, string[] lines, string delimiter)
        {
            this.Format = format;
            this.Lines = lines;
            this.Delimiter = delimiter;
        }
    }
}
