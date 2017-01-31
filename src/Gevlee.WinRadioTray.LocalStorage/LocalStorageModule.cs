using System.IO;
using Autofac;
using Gevlee.WinRadioTray.LocalStorage.Contract;
using Gevlee.WinRadioTray.LocalStorage.Contract.Serialization;
using Gevlee.WinRadioTray.LocalStorage.Contract.Services;
using Gevlee.WinRadioTray.LocalStorage.Serialization;
using Gevlee.WinRadioTray.LocalStorage.Services;

namespace Gevlee.WinRadioTray.LocalStorage
{
	public class LocalStorageModule : Module
	{
		public LocalStorageModule() : this(string.Empty)
		{
		}

		public LocalStorageModule(string rootStorageDir)
		{
			RootStorageDir = rootStorageDir;
		}

		public string RootStorageDir { get; set; }

		private string CombineWithRoot(string path)
		{
			return Path.Combine(RootStorageDir, path);
		}

		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<XmlSerializer<SavedRadiostations>>().As<ISerializer<SavedRadiostations>>();
			builder.RegisterType<SavedRadiostationsService>()
				.As<ISavedRadiostationsService>()
				.WithParameter("filename", CombineWithRoot("radiostations.xml"));
		}
	}
}