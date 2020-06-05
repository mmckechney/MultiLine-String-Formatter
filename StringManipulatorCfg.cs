using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MultiLineStringFormatter
{
	
	public class StringManipulatorCfg
	{
		public List<Format> Items { get; set; } = new List<Format>();

		public StringManipulatorCfg()
		{
		}
	}

	public class Format
	{
		[XmlAttribute]
		public string Name { get; set; } = String.Empty;
		[XmlText]
		public string Value { get; set; } = String.Empty;
		[XmlAttribute]
		public string Delimiter { get; set; } = String.Empty;

	}
}