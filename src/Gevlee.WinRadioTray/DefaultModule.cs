using Autofac;
using Gevlee.WinRadioTray.Core;
using Gevlee.WinRadioTray.Core.ViewModel;
using Gevlee.WinRadioTray.MenuItems;
using Gevlee.WinRadioTray.ViewModel;

namespace Gevlee.WinRadioTray
{
	public class DefaultModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<TrayIconViewModel>().As<ITrayIconViewModel>().SingleInstance();

			builder.RegisterType<ExitTrayContextMenuItem>().As<ITrayContextMenuItem>().SingleInstance();
			builder.RegisterType<FavouritesTrayContextMenuItem>().As<ITrayContextMenuItem>().SingleInstance();
		}
	}
}