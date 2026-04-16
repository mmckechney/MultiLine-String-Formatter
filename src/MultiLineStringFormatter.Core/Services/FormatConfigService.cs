using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MultiLineStringFormatter.Core.Models;

namespace MultiLineStringFormatter.Core.Services;

public class FormatConfigService
{
    public StringManipulatorCfg? LoadFormats(string configFilePath)
    {
        if (!File.Exists(configFilePath))
            return null;

        using var sr = new StreamReader(configFilePath);
        var serializer = new XmlSerializer(typeof(StringManipulatorCfg));
        return (StringManipulatorCfg?)serializer.Deserialize(sr);
    }

    public void SaveFormats(string configFilePath, StringManipulatorCfg formats)
    {
        var dir = Path.GetDirectoryName(configFilePath);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        using var tw = new XmlTextWriter(configFilePath, Encoding.UTF8)
        {
            Indentation = 4,
            Formatting = System.Xml.Formatting.Indented
        };
        var xmlS = new XmlSerializer(typeof(StringManipulatorCfg));
        xmlS.Serialize(tw, formats);
    }
}
