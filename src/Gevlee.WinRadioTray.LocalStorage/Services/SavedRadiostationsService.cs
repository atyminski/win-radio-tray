using System.IO;
using System.Xml.Linq;
using Gevlee.WinRadioTray.LocalStorage.Contract;
using Gevlee.WinRadioTray.LocalStorage.Contract.Serialization;
using Gevlee.WinRadioTray.LocalStorage.Contract.Services;

namespace Gevlee.WinRadioTray.LocalStorage.Services
{
	public class SavedRadiostationsService : ISavedRadiostationsService
	{
		private readonly ISerializer<SavedRadiostations> serializer;
		private readonly string filename;

		public SavedRadiostationsService(string filename, ISerializer<SavedRadiostations> serializer)
		{
			this.filename = filename;
			this.serializer = serializer;
		}

		public SavedRadiostations Get()
		{
			PrepareFileIfEmpty();
			using (var stream = File.Open(filename, FileMode.OpenOrCreate))
			using (var reader = new StreamReader(stream))
			{
				return serializer.DeserializeFromString(reader.ReadToEnd());
			}
		}

		private void PrepareFileIfEmpty()
		{
			if (!File.Exists(filename) || new FileInfo(filename).Length == 0)
			{
				Save(new SavedRadiostations());
			}
		}

		public void Save(SavedRadiostations savedRadiostations)
		{
			using (var stream = File.Open(filename, FileMode.OpenOrCreate))
			{
				var serialized = serializer.SerializeToByteArray(savedRadiostations);
				stream.Write(serialized, 0, serialized.Length);
				stream.Flush();
			}
		}
	}
}