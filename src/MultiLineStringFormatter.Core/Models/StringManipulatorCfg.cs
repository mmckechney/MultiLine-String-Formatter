using System.Xml.Serialization;

namespace MultiLineStringFormatter.Core.Models;

public class StringManipulatorCfg
{
    public List<Format> Items { get; set; } = new();
}

public class Format
{
    [XmlAttribute]
    public string Name { get; set; } = string.Empty;

    [XmlText]
    public string Value { get; set; } = string.Empty;

    [XmlAttribute]
    public string Delimiter { get; set; } = string.Empty;
}
