using System.Windows.Input;

namespace Gevlee.WinRadioTray.Core.ViewModel
{
	public interface ITrayIconViewModel
	{
		string IconSource { get; }
		ICommand ContextMenuCommand { get; }
	}
}