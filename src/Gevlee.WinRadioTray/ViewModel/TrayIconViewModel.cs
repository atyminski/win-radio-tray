using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Gevlee.WinRadioTray.Core.ViewModel;

namespace Gevlee.WinRadioTray.ViewModel
{
	public class TrayIconViewModel :  ViewModelBase, ITrayIconViewModel
	{
		private string iconSource;
		private ITrayIconContextMenuViewModel contextMenuViewModel;

		public TrayIconViewModel(ITrayIconContextMenuViewModel contextMenuViewModel)
		{
			ContextMenuViewModel = contextMenuViewModel;
			ContextMenuCommand = new RelayCommand(() =>
			{
				
			});
			IconSource = "pack://application:,,,/WinRadioTray;component/Resources/main_icon.ico";
		}

		public string IconSource
		{
			get { return iconSource; }
			private set
			{
				iconSource = value; 
				RaisePropertyChanged();
			}
		}

		public ITrayIconContextMenuViewModel ContextMenuViewModel
		{
			get { return contextMenuViewModel; }
			private set
			{
				contextMenuViewModel = value;
				RaisePropertyChanged();
			}
		}

		public ICommand ContextMenuCommand { get; }
	}
}