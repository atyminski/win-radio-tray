using System.Collections.Generic;
using System.Windows.Input;

namespace Gevlee.WinRadioTray.Core
{
	public interface ITrayContextMenuItem
	{
		string Name { get; }
		ICommand ClickCommand { get; }
		IEnumerable<ITrayContextMenuItem> ChildContextMenuItems { get; }
		bool IsEnabled { get; set; }
		bool IsActive { get; set; }
	}
}