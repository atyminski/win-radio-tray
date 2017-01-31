using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Gevlee.WinRadioTray.LocalStorage.Contract.Serialization;

namespace Gevlee.WinRadioTray.LocalStorage.Serialization
{
	public class XmlSerializer<TItem> : ISerializer<TItem>
	{
		public string SerializeToString(TItem item)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(TItem));
			using (var stream = new MemoryStream())
			using (var reader = new StreamReader(stream))
			using (var writer = XmlWriter.Create(stream, new XmlWriterSettings() { Encoding = Encoding.UTF8, Indent = true}))
			{
				serializer.Serialize(writer, item, GetNullNamespaces());
				stream.Seek(0, SeekOrigin.Begin);
				return reader.ReadToEnd();
			}
		}

		public byte[] SerializeToByteArray(TItem item)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(TItem));
			using (var stream = new MemoryStream())
			using (var writer = XmlWriter.Create(stream, new XmlWriterSettings() { Encoding = Encoding.UTF8, Indent = true }))
			{
				serializer.Serialize(writer, item, GetNullNamespaces());
				stream.Seek(0, SeekOrigin.Begin);
				return stream.ToArray();
			}
		}

		public TItem DeserializeFromString(string str)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(TItem));
			using (var reader = new StringReader(str))
			{
				return (TItem)serializer.Deserialize(reader);
			}
		}

		public TItem DeserializeFromByteArray(byte[] bytes)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(TItem));
			using (var stream = new MemoryStream(bytes))
			{
				return (TItem)serializer.Deserialize(stream);
			}
		}

		private XmlSerializerNamespaces GetNullNamespaces()
		{
			return new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty});
		}
	}
}