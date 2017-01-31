using System.Windows.Input;

namespace Gevlee.WinRadioTray.Core.ViewModel
{
	public interface ITrayIconViewModel
	{
		string IconSource { get; }
		ITrayIconContextMenuViewModel ContextMenuViewModel { get; }
		ICommand ContextMenuCommand { get; }
	}
}