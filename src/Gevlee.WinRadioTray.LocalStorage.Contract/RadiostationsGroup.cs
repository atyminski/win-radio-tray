using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Gevlee.WinRadioTray.LocalStorage.Contract
{
	[Serializable]
	[XmlRoot(ElementName = "RadiostationsGroup")]
	[XmlType("RadiostationsGroup")]
	public class RadiostationsGroup
	{
		public RadiostationsGroup():this(null)
		{
			
		}

		public RadiostationsGroup(string name)
		{
			Name = name;
		}

		[XmlElement("Radiostation")]
		public List<Radiostation> Radiostations { get; set; }

		[XmlAttribute]
		public string Name { get; set; }

		public override int GetHashCode()
		{
			return (Name?.GetHashCode() ?? 0) + (Radiostations?.GetHashCode() ?? 0);
		}
	}
}