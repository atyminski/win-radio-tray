using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Gevlee.WinRadioTray.Core;
using Gevlee.WinRadioTray.Core.ViewModel;

namespace Gevlee.WinRadioTray.ViewModel
{
	public class TrayIconViewModel :  ViewModelBase, ITrayIconViewModel
	{
		private string iconSource;

		public TrayIconViewModel(IEnumerable<ITrayContextMenuItem> trayContextMenuItems)
		{
			TrayContextMenuItems = trayContextMenuItems;
			ContextMenuCommand = new RelayCommand(() =>
			{
				
			});
			IconSource = "pack://application:,,,/Gevlee.WinRadioTray;component/Resources/main_icon.ico";
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

		public ICommand ContextMenuCommand { get; }
		public IEnumerable<ITrayContextMenuItem> TrayContextMenuItems { get; }
	}
}