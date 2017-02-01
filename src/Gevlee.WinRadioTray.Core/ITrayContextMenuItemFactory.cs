namespace Gevlee.WinRadioTray.Core
{
	public interface ITrayContextMenuItemFactory<in TContext>
	{
		ITrayContextMenuItem GetMenuItem(TContext context);
	}
}