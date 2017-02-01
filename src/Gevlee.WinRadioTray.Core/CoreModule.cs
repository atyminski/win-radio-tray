using Autofac;
using Gevlee.WinRadioTray.LocalStorage.Contract;

namespace Gevlee.WinRadioTray.Core
{
	public class CoreModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<RadiostationTrayContextMenuItemFactory>().As<ITrayContextMenuItemFactory<Radiostation>>();
			builder.RegisterType<RadiostationsGroupTrayContextMenuItemFactory>()
				.As<ITrayContextMenuItemFactory<RadiostationsGroup>>();
			builder.RegisterType<RadiostationSelectedCommand>().As<IRadiostationSelectedCommand>();
		}
	}
}