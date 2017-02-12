using System;
using Gevlee.WinRadioTray.LocalStorage.Contract;
using Gevlee.WinRadioTray.Player.Core;

namespace Gevlee.WinRadioTray.Core
{
	public class RadiostationSelectedCommand : IRadiostationSelectedCommand
	{
		private readonly IPlayerService playerService;

		public RadiostationSelectedCommand(Radiostation radiostation, ITrayContextMenuItem menuItem, IPlayerService playerService)
		{
			this.playerService = playerService;
			Radiostation = radiostation;
			MenuItem = menuItem;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			playerService.SwitchRadiostation(Radiostation.Url);
		}

		public event EventHandler CanExecuteChanged;
		public Radiostation Radiostation { get; }
		public ITrayContextMenuItem MenuItem { get; }
	}
}