using System;
using System.IO;
using Autofac;
using Common.Logging;
using GevbenTeam.ResxSupport.Autofac;
using Gevlee.WinRadioTray.Core;
using Gevlee.WinRadioTray.Core.ViewModel;
using Gevlee.WinRadioTray.LocalStorage;
using Gevlee.WinRadioTray.MenuItems;
using Gevlee.WinRadioTray.Properties;
using Gevlee.WinRadioTray.ViewModel;

namespace Gevlee.WinRadioTray
{
	public class DefaultModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
#if PORTABLE
			var dataDir = Directory.CreateDirectory(Path.Combine("Data")).FullName;
#else
			var dataDir = Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WinTrayRadio")).FullName;
#endif
			builder.UseResx<Resources>();
			builder.RegisterModule(new LoggingModule<ILog>(LogManager.GetLogger));
			builder.RegisterModule(new LocalStorageModule(dataDir));
			builder.RegisterModule<CoreModule>();

			builder.RegisterType<TrayIconViewModel>().As<ITrayIconViewModel>().SingleInstance();
			builder.RegisterType<TrayIconContextMenuViewModel>().As<ITrayIconContextMenuViewModel>();

			builder.RegisterType<ExitTrayContextMenuItem>().As<ITrayContextMenuItem>().SingleInstance();
			builder.RegisterType<FavouritesTrayContextMenuItem>().As<ITrayContextMenuItem>().SingleInstance();
		}
	}
}