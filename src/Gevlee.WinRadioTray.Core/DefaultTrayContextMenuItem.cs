using System.Collections.Generic;
using System.Windows.Input;

namespace Gevlee.WinRadioTray.Core
{
	public class DefaultTrayContextMenuItem : ITrayContextMenuItem
	{
		internal DefaultTrayContextMenuItem(string name)
		{
			Name = name;
		}

		public string Name { get; }
		public ICommand ClickCommand { get; internal set; }
		public IEnumerable<ITrayContextMenuItem> ChildContextMenuItems { get; internal set; }
		public bool IsEnabled { get; set; }
		public bool IsActive { get; set; }
	}
}