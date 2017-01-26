using System.Windows.Input;

namespace Gevlee.WinRadioTray.Core
{
	public interface ITrayContextMenuItem
	{
		string Name { get; }
		ICommand ClickCommand { get; }
	}
}