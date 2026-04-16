using MultiLineStringFormatter.Core.Models;
using MultiLineStringFormatter.Core.Services;

namespace MultiLineStringFormatter.Tests;

[TestClass]
public class StringExpandServiceTests
{
    private readonly StringExpandService _service = new();

    [TestMethod]
    public void ProcessStringExpand_BasicExpand_SplitsIntoLines()
    {
        var data = new ExpandData("", new[] { "a,b,c" }, "Comma");

        var result = _service.ProcessStringExpand(data);

        Assert.IsTrue(result.Contains("a\r\n"));
        Assert.IsTrue(result.Contains("b\r\n"));
        Assert.IsTrue(result.Contains("c\r\n"));
    }

    [TestMethod]
    public void ProcessStringExpand_EmptyLines_AreSkipped()
    {
        var data = new ExpandData("", new[] { "a,b", "", "c,d" }, "Comma");

        var result = _service.ProcessStringExpand(data);

        var lines = result.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        Assert.AreEqual(4, lines.Length);
    }

    [TestMethod]
    public void ProcessStringExpand_TrimValues()
    {
        var data = new ExpandData("", new[] { " x , y " }, "Comma");

        var result = _service.ProcessStringExpand(data);

        Assert.IsTrue(result.Contains("x\r\n"));
        Assert.IsTrue(result.Contains("y\r\n"));
    }
}
