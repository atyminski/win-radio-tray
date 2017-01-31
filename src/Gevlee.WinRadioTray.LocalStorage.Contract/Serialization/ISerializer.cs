namespace Gevlee.WinRadioTray.LocalStorage.Contract.Serialization
{
	public interface ISerializer<TItem>
	{
		string SerializeToString(TItem item);
		byte[] SerializeToByteArray(TItem item);
		TItem DeserializeFromString(string str);
		TItem DeserializeFromByteArray(byte[] bytes);
	}
}