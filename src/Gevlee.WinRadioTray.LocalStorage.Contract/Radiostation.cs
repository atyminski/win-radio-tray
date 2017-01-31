using System.Linq;
using System.Xml.Serialization;

namespace Gevlee.WinRadioTray.LocalStorage.Contract
{
	[XmlType(TypeName = nameof(Radiostation))]
	public class Radiostation
	{
		[XmlAttribute]
		public string Name { get; set; }

		public string Url { get; set; }

		public override int GetHashCode()
		{
			return (Name?.GetHashCode() ?? 0) + (Url?.GetHashCode() ?? 0);
		}
	}
}