using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Gevlee.WinRadioTray.Core;

namespace Gevlee.WinRadioTray.MenuItems
{
	public class ExitTrayContextMenuItem : ITrayContextMenuItem
	{
		public ExitTrayContextMenuItem()
		{
			Name = "Exit";
			ClickCommand = new RelayCommand(() =>
			{
				
			});
		}
		public string Name { get; }
		public ICommand ClickCommand { get; }
	}
}