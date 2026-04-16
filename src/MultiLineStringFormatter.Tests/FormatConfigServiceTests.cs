using MultiLineStringFormatter.Core.Models;
using MultiLineStringFormatter.Core.Services;

namespace MultiLineStringFormatter.Tests;

[TestClass]
public class FormatConfigServiceTests
{
    private readonly FormatConfigService _service = new();

    [TestMethod]
    public void SaveAndLoad_RoundTrips()
    {
        var tempFile = Path.Combine(Path.GetTempPath(), $"test_config_{Guid.NewGuid()}.cfg");
        try
        {
            var cfg = new StringManipulatorCfg();
            cfg.Items.Add(new Format { Name = "Test", Value = "INSERT {0}", Delimiter = "Comma" });
            cfg.Items.Add(new Format { Name = "Test2", Value = "{0}|{1}", Delimiter = "Tab" });

            _service.SaveFormats(tempFile, cfg);

            var loaded = _service.LoadFormats(tempFile);

            Assert.IsNotNull(loaded);
            Assert.AreEqual(2, loaded!.Items.Count);
            Assert.AreEqual("Test", loaded.Items[0].Name);
            Assert.AreEqual("INSERT {0}", loaded.Items[0].Value);
            Assert.AreEqual("Comma", loaded.Items[0].Delimiter);
            Assert.AreEqual("Test2", loaded.Items[1].Name);
        }
        finally
        {
            if (File.Exists(tempFile)) File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void LoadFormats_NonexistentFile_ReturnsNull()
    {
        var result = _service.LoadFormats(@"C:\nonexistent\path\config.cfg");
        Assert.IsNull(result);
    }
}
