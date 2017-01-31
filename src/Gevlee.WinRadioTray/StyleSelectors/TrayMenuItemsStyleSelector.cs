using System.Windows;
using System.Windows.Controls;

namespace Gevlee.WinRadioTray.StyleSelectors
{
	public class TrayMenuItemsStyleSelector : StyleSelector
	{
		public Style DefaultMenuItemStyle { get; set; }
		public Style SepratorStyle { get; set; }

		public override Style SelectStyle(object item, DependencyObject container)
		{
			return item.GetType() == typeof(Separator) ? SepratorStyle : DefaultMenuItemStyle;
		}
	}
}