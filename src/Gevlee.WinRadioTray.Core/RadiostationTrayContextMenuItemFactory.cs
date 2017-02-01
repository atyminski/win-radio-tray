using Autofac;
using Gevlee.WinRadioTray.LocalStorage.Contract;

namespace Gevlee.WinRadioTray.Core
{
	public class RadiostationTrayContextMenuItemFactory : ITrayContextMenuItemFactory<Radiostation>
	{
		private readonly ILifetimeScope scope;

		public RadiostationTrayContextMenuItemFactory(ILifetimeScope scope)
		{
			this.scope = scope;
		}

		public ITrayContextMenuItem GetMenuItem(Radiostation context)
		{
			var item = new DefaultTrayContextMenuItem(context.Name);
			item.ClickCommand = scope.Resolve<IRadiostationSelectedCommand>(
				new TypedParameter(typeof(Radiostation), context),
				new TypedParameter(typeof(ITrayContextMenuItem), item));

			return item;
		}
	}
}