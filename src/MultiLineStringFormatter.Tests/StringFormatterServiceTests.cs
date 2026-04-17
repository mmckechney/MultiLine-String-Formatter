using MultiLineStringFormatter.Core.Models;
using MultiLineStringFormatter.Core.Services;

namespace MultiLineStringFormatter.Tests;

[TestClass]
public class StringFormatterServiceTests
{
    private readonly StringFormatterService _service = new();

    [TestMethod]
    public void ProcessStringFormatting_BasicFormat_ProducesCorrectOutput()
    {
        var data = new StringData(
            format: "INSERT INTO t VALUES('{0}', '{1}');",
            lines: new[] { "John,Doe", "Jane,Smith" },
            delimiter: "Comma",
            removeCarriageReturns: false,
            excludeEmptyLines: false,
            excludeMissingValues: false,
            trimInputValues: true,
            defaultFillText: "");

        var result = _service.ProcessStringFormatting(data);

        Assert.AreEqual(2, result.LinesProcessed);
        Assert.IsTrue(result.Output.Contains("INSERT INTO t VALUES('John', 'Doe');"));
        Assert.IsTrue(result.Output.Contains("INSERT INTO t VALUES('Jane', 'Smith');"));
    }

    [TestMethod]
    public void ProcessStringFormatting_ExcludeEmptyLines_SkipsBlankLines()
    {
        var data = new StringData(
            format: "{0}-{1}",
            lines: new[] { "a,b", "", "c,d" },
            delimiter: "Comma",
            removeCarriageReturns: false,
            excludeEmptyLines: true,
            excludeMissingValues: false,
            trimInputValues: false,
            defaultFillText: "");

        var result = _service.ProcessStringFormatting(data);

        Assert.AreEqual(2, result.LinesProcessed);
        Assert.AreEqual(1, result.EmptyLinesExcluded);
    }

    [TestMethod]
    public void ProcessStringFormatting_ExcludeMissingValues_SkipsIncompleteLines()
    {
        var data = new StringData(
            format: "{0}-{1}-{2}",
            lines: new[] { "a,b,c", "x,y" },
            delimiter: "Comma",
            removeCarriageReturns: false,
            excludeEmptyLines: false,
            excludeMissingValues: true,
            trimInputValues: false,
            defaultFillText: "");

        var result = _service.ProcessStringFormatting(data);

        Assert.AreEqual(1, result.LinesProcessed);
        Assert.AreEqual(1, result.MissingValueLinesExcluded);
    }

    [TestMethod]
    public void ProcessStringFormatting_FillDefaultText_FillsMissingValues()
    {
        var data = new StringData(
            format: "{0}-{1}-{2}",
            lines: new[] { "a,b" },
            delimiter: "Comma",
            removeCarriageReturns: false,
            excludeEmptyLines: false,
            excludeMissingValues: false,
            trimInputValues: false,
            defaultFillText: "NULL");

        var result = _service.ProcessStringFormatting(data);

        Assert.AreEqual(1, result.LinesProcessed);
        Assert.IsTrue(result.Output.Contains("a-b-NULL"));
    }

    [TestMethod]
    public void ProcessStringFormatting_RemoveCarriageReturns_SingleLine()
    {
        var data = new StringData(
            format: "{0}",
            lines: new[] { "a", "b", "c" },
            delimiter: "Comma",
            removeCarriageReturns: true,
            excludeEmptyLines: false,
            excludeMissingValues: false,
            trimInputValues: false,
            defaultFillText: "");

        var result = _service.ProcessStringFormatting(data);

        Assert.IsFalse(result.Output.Contains("\r\n"));
        Assert.AreEqual("abc", result.Output);
    }

    [TestMethod]
    public void ProcessStringFormatting_TrimInputValues_TrimsWhitespace()
    {
        var data = new StringData(
            format: "[{0}][{1}]",
            lines: new[] { " hello , world " },
            delimiter: "Comma",
            removeCarriageReturns: true,
            excludeEmptyLines: false,
            excludeMissingValues: false,
            trimInputValues: true,
            defaultFillText: "");

        var result = _service.ProcessStringFormatting(data);

        Assert.AreEqual("[hello][world]", result.Output);
    }

    [TestMethod]
    public void ProcessStringFormatting_TabDelimiter_Works()
    {
        var data = new StringData(
            format: "{0}|{1}",
            lines: new[] { "col1\tcol2" },
            delimiter: "Tab",
            removeCarriageReturns: true,
            excludeEmptyLines: false,
            excludeMissingValues: false,
            trimInputValues: true,
            defaultFillText: "");

        var result = _service.ProcessStringFormatting(data);

        Assert.AreEqual("col1|col2", result.Output);
    }

    [TestMethod]
    public void ProcessStringFormatting_Cancellation_StopsProcessing()
    {
        var lines = Enumerable.Range(0, 1000).Select(i => $"val{i}").ToArray();
        var data = new StringData("{0}", lines, "Comma", false, false, false, false, "");

        var cts = new CancellationTokenSource();
        cts.Cancel();

        var result = _service.ProcessStringFormatting(data, cancellationToken: cts.Token);

        Assert.IsTrue(result.WasCancelled);
        Assert.IsTrue(result.LinesProcessed < 1000);
    }
}
