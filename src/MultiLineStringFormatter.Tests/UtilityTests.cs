using MultiLineStringFormatter.Core;

namespace MultiLineStringFormatter.Tests;

[TestClass]
public class UtilityTests
{
    [TestMethod]
    [DataRow("Tab", '\t')]
    [DataRow("tab", '\t')]
    [DataRow("Space", ' ')]
    [DataRow("Comma", ',')]
    [DataRow("Tilde", '~')]
    [DataRow("Pipe", '|')]
    public void GetDelimiter_NamedDelimiters_ReturnsCorrectChar(string input, char expected)
    {
        var result = Utility.GetDelimiter(input);
        Assert.AreEqual(1, result.Length);
        Assert.AreEqual(expected, result[0]);
    }

    [TestMethod]
    public void GetDelimiter_CustomString_ReturnsCharArray()
    {
        var result = Utility.GetDelimiter(";");
        Assert.AreEqual(1, result.Length);
        Assert.AreEqual(';', result[0]);
    }

    [TestMethod]
    public void GetDelimiter_Null_DefaultsToComma()
    {
        var result = Utility.GetDelimiter(null);
        Assert.AreEqual(1, result.Length);
        Assert.AreEqual(',', result[0]);
    }
}
