using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Gevlee.WinRadioTray.Core;

namespace Gevlee.WinRadioTray.MenuItems
{
	public class FavouritesTrayContextMenuItem : ITrayContextMenuItem
	{
		public FavouritesTrayContextMenuItem()
		{
			Name = "Favourites";
			ClickCommand = new RelayCommand(() =>
			{

			});
		}
		public string Name { get; }
		public ICommand ClickCommand { get; }
		public IEnumerable<ITrayContextMenuItem> ChildContextMenuItems { get; }
		public bool IsEnabled { get; set; }
		public bool IsActive { get; set; }
	}
}