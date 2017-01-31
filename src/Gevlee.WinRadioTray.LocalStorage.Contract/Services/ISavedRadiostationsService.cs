namespace Gevlee.WinRadioTray.LocalStorage.Contract.Services
{
	public interface ISavedRadiostationsService
	{
		SavedRadiostations Get();
		void Save(SavedRadiostations savedRadiostations);
	}
}