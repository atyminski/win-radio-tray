using System.Linq;
using Gevlee.WinRadioTray.LocalStorage.Contract;

namespace Gevlee.WinRadioTray.Core
{
	public class RadiostationsGroupTrayContextMenuItemFactory : ITrayContextMenuItemFactory<RadiostationsGroup>
	{
		private readonly ITrayContextMenuItemFactory<Radiostation> radiostationTrayContextMenuItemFactory;

		public RadiostationsGroupTrayContextMenuItemFactory(ITrayContextMenuItemFactory<Radiostation> radiostationTrayContextMenuItemFactory)
		{
			this.radiostationTrayContextMenuItemFactory = radiostationTrayContextMenuItemFactory;
		}

		public ITrayContextMenuItem GetMenuItem(RadiostationsGroup context)
		{
			var item = new DefaultTrayContextMenuItem(context.Name)
			{
				ChildContextMenuItems = context.Radiostations.Select(r => radiostationTrayContextMenuItemFactory.GetMenuItem(r))
			};
			return item;
		}
	}
}