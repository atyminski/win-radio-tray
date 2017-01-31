using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Gevlee.WinRadioTray.LocalStorage.Contract
{
	[XmlRoot(ElementName = nameof(SavedRadiostations))]
	public class SavedRadiostations
	{
		[XmlArray(ElementName = "Radiostations")]
		public List<Radiostation> StandaloneRadiostations { get; set; }

		[XmlArray(ElementName = nameof(RadiostationsGroups)), DefaultValue(null)]
		public List<RadiostationsGroup> RadiostationsGroups { get; set; }

		public override int GetHashCode()
		{
			return (StandaloneRadiostations?.GetHashCode() ?? 0) + (RadiostationsGroups?.GetHashCode() ?? 0);
		}
	}
}