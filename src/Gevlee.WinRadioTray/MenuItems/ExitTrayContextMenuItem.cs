using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GevbenTeam.ResxSupport;
using Gevlee.WinRadioTray.Core;

namespace Gevlee.WinRadioTray.MenuItems
{
	public class ExitTrayContextMenuItem : ITrayContextMenuItem
	{
		public ExitTrayContextMenuItem()
		{
			ClickCommand = new RelayCommand(() =>
			{
				
			});
		}
		[Resx]
		public string Name { get; set; }
		public ICommand ClickCommand { get; }
		public IEnumerable<ITrayContextMenuItem> ChildContextMenuItems { get; }
		public bool IsEnabled { get; set; }
		public bool IsActive { get; set; }
	}
}