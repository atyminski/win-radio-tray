using System.Collections.Generic;
using GalaSoft.MvvmLight;
using Gevlee.WinRadioTray.Core;
using Gevlee.WinRadioTray.Core.ViewModel;
using Gevlee.WinRadioTray.LocalStorage.Contract.Services;

namespace Gevlee.WinRadioTray.ViewModel
{
	public class TrayIconContextMenuViewModel : ViewModelBase, ITrayIconContextMenuViewModel
	{
		private readonly ISavedRadiostationsService savedRadiostationsService;
		private IEnumerable<ITrayContextMenuItem> bottomItems;
		private IEnumerable<ITrayContextMenuItem> middleItems;
		private IEnumerable<ITrayContextMenuItem> topItems;

		public TrayIconContextMenuViewModel(IEnumerable<ITrayContextMenuItem> bottomMenuItems, ISavedRadiostationsService savedRadiostationsService)
		{
			this.savedRadiostationsService = savedRadiostationsService;
			savedRadiostationsService.Get();
			BottomItems = bottomMenuItems;
		}

		public IEnumerable<ITrayContextMenuItem> BottomItems
		{
			get { return bottomItems; }
			set
			{
				bottomItems = value; 
				RaisePropertyChanged();
			}
		}

		public IEnumerable<ITrayContextMenuItem> MiddleItems
		{
			get { return middleItems; }
			set
			{
				middleItems = value;
				RaisePropertyChanged();
			}
		}

		public IEnumerable<ITrayContextMenuItem> TopItems
		{
			get { return topItems; }
			set
			{
				topItems = value;
				RaisePropertyChanged();
			}
		}
	}
}