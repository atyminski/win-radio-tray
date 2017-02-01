using System.Windows.Input;
using Gevlee.WinRadioTray.LocalStorage.Contract;

namespace Gevlee.WinRadioTray.Core
{
	public interface IRadiostationSelectedCommand : ICommand
	{
		Radiostation Radiostation { get; }
		ITrayContextMenuItem MenuItem { get; }
	}
}