using MultiLineStringFormatter.Core.Models;
using MultiLineStringFormatter.Core.Services;

namespace MultiLineStringFormatter.Tests;

[TestClass]
public class AnalysisServiceTests
{
    private readonly AnalysisService _service = new();

    [TestMethod]
    public void Analyze_BasicInput_CorrectIndexTally()
    {
        var data = new AnalysisData
        {
            SourceLines = new[] { "a,b,c", "d,e,f", "g,h" },
            Delimiter = "Comma",
            TotalLines = 3
        };

        var result = _service.Analyze(data);

        Assert.AreEqual(3, result.MaxIndexes);
        Assert.AreEqual(3, result.LineData.Count);
        Assert.AreEqual(2, result.IndexTally[3]); // two lines with 3 columns
        Assert.AreEqual(1, result.IndexTally[2]); // one line with 2 columns
    }

    [TestMethod]
    public void Analyze_PopulatesLineInfo()
    {
        var data = new AnalysisData
        {
            SourceLines = new[] { "hello,world" },
            Delimiter = "Comma",
            TotalLines = 1
        };

        var result = _service.Analyze(data);

        Assert.AreEqual(1, result.LineData.Count);
        Assert.AreEqual(1, result.LineData[0].LineNumber);
        Assert.AreEqual("hello,world", result.LineData[0].LineText);
        Assert.AreEqual(2, result.LineData[0].ActualIndexCount);
    }
}
