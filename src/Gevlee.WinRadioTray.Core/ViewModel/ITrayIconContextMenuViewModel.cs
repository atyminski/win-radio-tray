using System.Collections.Generic;

namespace Gevlee.WinRadioTray.Core.ViewModel
{
	public interface ITrayIconContextMenuViewModel
	{
		IEnumerable<ITrayContextMenuItem> BottomItems { get; }
		IEnumerable<ITrayContextMenuItem> MiddleItems { get; }
		IEnumerable<ITrayContextMenuItem> TopItems { get; }
	}
}