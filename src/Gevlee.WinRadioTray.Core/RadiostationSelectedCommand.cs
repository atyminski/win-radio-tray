using System;
using Gevlee.WinRadioTray.LocalStorage.Contract;

namespace Gevlee.WinRadioTray.Core
{
	public class RadiostationSelectedCommand : IRadiostationSelectedCommand
	{
		public RadiostationSelectedCommand(Radiostation radiostation, ITrayContextMenuItem menuItem)
		{
			Radiostation = radiostation;
			MenuItem = menuItem;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			//TODO
		}

		public event EventHandler CanExecuteChanged;
		public Radiostation Radiostation { get; }
		public ITrayContextMenuItem MenuItem { get; }
	}
}