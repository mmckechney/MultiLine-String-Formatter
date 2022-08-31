using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineStringFormatter
{
    public class AnalysisData
    {
        System.Collections.Generic.Dictionary<int, int> indexTally = new Dictionary<int, int>();

        public System.Collections.Generic.Dictionary<int, int> IndexTally
        {
            get { return indexTally; }
            set { indexTally = value; }
        }
        private int maxIndexes;

        public int MaxIndexes
        {
            get { return maxIndexes; }
            set { maxIndexes = value; }
        }
        private int totalLines;


        public int TotalLines
        {
            get { return totalLines; }
            set { totalLines = value; }
        }
        private int compliantLines;

        public int CompliantLines
        {
            get { return compliantLines; }
            set { compliantLines = value; }
        }
        private int nonCompliantLines;

        public int NonCompliantLines
        {
            get { return nonCompliantLines; }
            set { nonCompliantLines = value; }
        }
        private string delimiter;

        public string Delimiter
        {
            get { return delimiter; }
            set { delimiter = value; }
        }
        private List<LineInfo> lineData = new List<LineInfo>();

        internal List<LineInfo> LineData
        {
            get { return lineData; }
            set { lineData = value; }
        }
        private string[] sourceLines;

        public string[] SourceLines
        {
            get { return sourceLines; }
            set { sourceLines = value; }
        }
       
       
        
    }
    public class LineInfo
    {
        public LineInfo(int lineNumber, string lineText, int actualIndexCount)
        {
            this.lineNumber = lineNumber;
            this.lineText = lineText;
            this.actualIndexCount = actualIndexCount;
        }
        private int lineNumber;

        public int LineNumber
        {
            get { return lineNumber; }
            set { lineNumber = value; }
        }
        private string lineText;

        public string LineText
        {
            get { return lineText; }
            set { lineText = value; }
        }
        private int actualIndexCount;

        public int ActualIndexCount
        {
            get { return actualIndexCount; }
            set { actualIndexCount = value; }
        }
    }
}
