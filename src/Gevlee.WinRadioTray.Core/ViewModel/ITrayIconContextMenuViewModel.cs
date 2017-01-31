using System.Collections.Generic;

namespace Gevlee.WinRadioTray.Core.ViewModel
{
	public interface ITrayIconContextMenuViewModel
	{
		IEnumerable<ITrayContextMenuItem> BottomItems { get; set; }
		IEnumerable<ITrayContextMenuItem> MiddleItems { get; set; }
		IEnumerable<ITrayContextMenuItem> TopItems { get; set; }
	}
}